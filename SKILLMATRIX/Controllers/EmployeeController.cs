using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SKILLMATRIX.Repo.Implementations;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
		private readonly IDepartmentRepo _departmentRepo;
		private readonly ISkillRepo _SkillRepo;
		private readonly IEducationRepo _educationRepo;

		public EmployeeController(IEmployeeRepo employeeRepo,IDepartmentRepo departmentRepo,ISkillRepo skillRepo, IEducationRepo educationRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
			_SkillRepo = skillRepo;
			_educationRepo = educationRepo;

		}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Results()
        {
            DataTable dt = null;
            try
            {
                dt = _employeeRepo.GetDataTable();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return Json(new { data = dt });
                    }
                }
                return Json(null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            #region Create Deptt List using dt
            DataTable deptdt = _departmentRepo.GetDataTable();
            List<itemlist> list = new List<itemlist>();
            foreach (DataRow row in deptdt.Rows)
            {
                var items = new itemlist();
                items.Department_Id = Convert.ToInt32(row["Department_Id"]);
                items.Department_Name = row["Department_Name"].ToString();
                list.Add(items);
            }
            ViewBag.dept = new SelectList(list, "Department_Id", "Department_Name");
			#endregion



			#region Create Skill List using dt
			DataTable skilldt = _SkillRepo.GetDataTable();
			List<itemlist> list1 = new List<itemlist>();
			foreach (DataRow row in skilldt.Rows)
			{
				var items = new itemlist();
				items.Skill_Id = Convert.ToInt32(row["Skill_Id"]);
				items.Skill_Name = row["Skill_Name"].ToString();
				list1.Add(items);
			}
			ViewBag.skill = new SelectList(list1, "Skill_Id", "Skill_Name");

			#endregion


			#region Create Education List using dt
			DataTable edudt = _educationRepo.GetDataTable();
			List<itemlist> list2 = new List<itemlist>();
			foreach (DataRow row in edudt.Rows)
			{
				var items = new itemlist();
				items.Education_Id = Convert.ToInt32(row["Education_Id"]);
				items.Education_Name = row["Education_Name"].ToString();
				list2.Add(items);
			}
			ViewBag.educ = new SelectList(list2, "Education_Id", "Education_Name");

			#endregion

			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Employee_Name_F))
                {
                    var vms = new EmployeeViewModel
                    {
                        Employee_Code=vm.Employee_Code,
                        Employee_Department=vm.Employee_Department,
                        Employee_Name_F = vm.Employee_Name_F,
                        Employee_Name_M = vm.Employee_Name_M,
                        Employee_Name_L = vm.Employee_Name_L,
                        Employee_Address = vm.Employee_Address,
                        Employee_MobileNo = vm.Employee_MobileNo,
                        Employee_Education = vm.Employee_Education,
                        Employee_type=vm.Employee_type,
                        Skill_Id = vm.Skill_Id,


                    };
                    var msg = _employeeRepo.Save(vms);
                    if (msg != null)
                        TempData["SuccessMessage"] = "Add Successfully";
                    else
                        TempData["SuccessMessage"] = "Date Not Add Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Error " + ex.Message;
            }
            //return RedirectToAction("Index");
            return View("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {

				#region Create Deptt List using dt
				DataTable deptdt = _departmentRepo.GetDataTable();
				List<itemlist> list = new List<itemlist>();
				foreach (DataRow row in deptdt.Rows)
				{
					var items = new itemlist();
					items.Department_Id = Convert.ToInt32(row["Department_Id"]);
					items.Department_Name = row["Department_Name"].ToString();
					list.Add(items);
				}
				ViewBag.dept = new SelectList(list, "Department_Id", "Department_Name");
				#endregion



				#region Create Skill List using dt
				DataTable skilldt = _SkillRepo.GetDataTable();
				List<itemlist> list1 = new List<itemlist>();
				foreach (DataRow row in skilldt.Rows)
				{
					var items = new itemlist();
					items.Skill_Id = Convert.ToInt32(row["Skill_Id"]);
					items.Skill_Name = row["Skill_Name"].ToString();
					list1.Add(items);
				}
				ViewBag.skill = new SelectList(list1, "Skill_Id", "Skill_Name");

				#endregion


				#region Create Education List using dt
				DataTable edudt = _educationRepo.GetDataTable();
				List<itemlist> list2 = new List<itemlist>();
				foreach (DataRow row in edudt.Rows)
				{
					var items = new itemlist();
					items.Education_Id = Convert.ToInt32(row["Education_Id"]);
					items.Education_Name = row["Education_Name"].ToString();
					list2.Add(items);
				}
				ViewBag.educ = new SelectList(list2, "Education_Id", "Education_Name");

				#endregion

				DataTable dt = _employeeRepo.GetById(id);
                EmployeeViewModel vm = new EmployeeViewModel
                {
                    Employee_Id = Convert.ToInt32(dt.Rows[0]["Employee_Id"]),
                    
                    Employee_Code = dt.Rows[0]["Employee_Code"].ToString(),
                    Employee_Department = dt.Rows[0]["Employee_Department"].ToString(),
                    Employee_Name_F = dt.Rows[0]["Employee_Name_F"].ToString(),
                    Employee_Name_M = dt.Rows[0]["Employee_Name_M"].ToString(),
                    Employee_Name_L = dt.Rows[0]["Employee_Name_L"].ToString(),
                    Employee_Address = dt.Rows[0]["Employee_Address"].ToString(),
                    Employee_MobileNo = dt.Rows[0]["Employee_MobileNo"].ToString(),
                    Employee_Education = dt.Rows[0]["Employee_Education"].ToString(),
                    Employee_type = dt.Rows[0]["Employee_type"].ToString(),
                    Skill_Id = Convert.ToInt32(dt.Rows[0]["Skill_Id"]),

                };
                return View(vm);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel vm)
        {
            try
            {
                EmployeeViewModel vms = new EmployeeViewModel();
                vms.Employee_Id = vm.Employee_Id;
                vms.Employee_Code = vm.Employee_Code;
                vms.Employee_Department = vm.Employee_Department;
                vms.Employee_Name_F = vm.Employee_Name_F;
                vms.Employee_Name_M = vm.Employee_Name_M;
                vms.Employee_Name_L = vm.Employee_Name_L;
                vms.Employee_Address = vm.Employee_Address;
                vms.Employee_MobileNo = vm.Employee_MobileNo;
                vms.Employee_Education = vm.Employee_Education;
                vms.Employee_type = vm.Employee_type;
                vms.Skill_Id = vm.Skill_Id;

                var msg = _employeeRepo.Update(vms);
                if (msg != null)
                    TempData["SuccessMessage"] = "Update Successfully";
                else
                    TempData["SuccessMessage"] = "Date Not Add Successfully";
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Error " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    var msg = _employeeRepo.Delete(id);
                    if (msg != null)
                        TempData["SuccessMessage"] = "Add Successfully";
                    else
                        TempData["SuccessMessage"] = "Date Not Add Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Error " + ex.Message;
            }
            //return RedirectToAction("Index");
            return View("Index");
        }
    }
}

