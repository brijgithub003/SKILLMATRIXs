using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantRepo _plantRepo;

        public PlantController(IPlantRepo plantRepo)
        {
            _plantRepo = plantRepo;
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
                dt = _plantRepo.GetDataTable();
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
        public IActionResult Create(PlantViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Plant_Name))
                {
                    var vms = new PlantViewModel
                    {
                        Plant_Name = vm.Plant_Name,
                        Plant_Code=vm.Plant_Code
                    };
                    var msg = _plantRepo.Save(vms);
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
                DataTable dt = _plantRepo.GetById(id);
                PlantViewModel vm = new PlantViewModel
                {
                    Plant_Id = Convert.ToInt32(dt.Rows[0]["Plant_Id"]),
                    Plant_Name = dt.Rows[0]["Plant_Name"].ToString(),
                    Plant_Code = dt.Rows[0]["Plant_Code"].ToString()
                };
                return View(vm);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlantViewModel vm)
        {
            try
            {
                PlantViewModel vms = new PlantViewModel();
                vms.Plant_Id = vm.Plant_Id;
                vms.Plant_Name = vm.Plant_Name;
                vms.Plant_Code= vm.Plant_Code;
                var msg = _plantRepo.Update(vms);
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
                    var msg = _plantRepo.Delete(id);
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
