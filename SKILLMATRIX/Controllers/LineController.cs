using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class LineController : Controller
    {
        private readonly ILineRepo _lineRepo;

        public LineController(ILineRepo lineRepo)
        {
            _lineRepo = lineRepo;
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
                dt = _lineRepo.GetDataTable();
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
        public IActionResult Create(LineViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Line_Name))
                {
                    var vms = new LineViewModel
                    {
                        Line_Name = vm.Line_Name,
                        Line_NO = vm.Line_NO
                    };
                    var msg = _lineRepo.Save(vms);
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
                DataTable dt = _lineRepo.GetById(id);
                LineViewModel vm = new LineViewModel
                {
                    Line_Id = Convert.ToInt32(dt.Rows[0]["Line_Id"]),
                    Line_Name = dt.Rows[0]["Line_Name"].ToString(),
                   Line_NO = Convert.ToInt32(dt.Rows[0]["LINE_NO"])
                };
                return View(vm);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LineViewModel vm)
        {
            try
            {
                LineViewModel vms = new LineViewModel();
                vms.Line_Id = vm.Line_Id;
                vms.Line_Name = vm.Line_Name;
                vms.Line_NO = vm.Line_NO;
                var msg = _lineRepo.Update(vms);
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
                    var msg = _lineRepo.Delete(id);
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
