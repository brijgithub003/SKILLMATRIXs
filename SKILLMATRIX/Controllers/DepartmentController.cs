using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
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
                dt = _departmentRepo.GetDataTable();
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Department_Name))
                {
                    var vms = new DepartmentViewModel
                    {
                        Department_Name = vm.Department_Name
                    };
                    var msg = _departmentRepo.Save(vms);
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
				DataTable dt = _departmentRepo.GetById(id);
				DepartmentViewModel vm = new DepartmentViewModel
				{
					Department_Id = Convert.ToInt32(dt.Rows[0]["Department_Id"]),
					Department_Name = dt.Rows[0]["Department_Name"].ToString()
				};
				return View(vm);
			}
			return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel vm)
        {
			try
			{
                DepartmentViewModel vms = new DepartmentViewModel();
                vms.Department_Id = vm.Department_Id;
                vms.Department_Name = vm.Department_Name;
				var msg =  _departmentRepo.Update(vms);
                if(msg != null)
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
                    var msg = _departmentRepo.Delete(id);
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
