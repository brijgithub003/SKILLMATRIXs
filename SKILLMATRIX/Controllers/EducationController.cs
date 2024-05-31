using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepo _educationRepo;

        public EducationController(IEducationRepo educationRepo)
        {
            _educationRepo = educationRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Results(string action)
        {
            DataTable dt = null;
            try
            {
                dt = _educationRepo.GetDataTable();
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
        public IActionResult Create(EducationViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Education_Name))
                {
                    var vms = new EducationViewModel
                    {
                        Education_Name = vm.Education_Name
                    };
                    var msg = _educationRepo.Save(vms);
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
                DataTable dt = _educationRepo.GetById(id);
                EducationViewModel vm = new EducationViewModel
                {
                    Education_Id = Convert.ToInt32(dt.Rows[0]["Education_Id"]),
                    Education_Name = dt.Rows[0]["Education_Name"].ToString()
                };
                return View(vm);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EducationViewModel vm)
        {
            try
            {
                EducationViewModel vms = new EducationViewModel();
                vms.Education_Id = vm.Education_Id;
                vms.Education_Name = vm.Education_Name;
                var msg = _educationRepo.Update(vms);
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
                    var msg = _educationRepo.Delete(id);
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
