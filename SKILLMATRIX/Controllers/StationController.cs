using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SKILLMATRIX.Repo.Interfaces;
using SKILLMATRIX.Repo.ViewModels;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKILLMATRIX.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationRepo _stationRepo;
        private readonly ILineRepo _lineRepo;


        public StationController(IStationRepo stationRepo, ILineRepo lineRepo)
        {
            _stationRepo = stationRepo;
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
                dt = _stationRepo.GetDataTable();
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
            #region Create Line List using dt
            DataTable linedt = _lineRepo.GetDataTable();
            List<itemlist> list = new List<itemlist>();
            foreach (DataRow row in linedt.Rows)
            {
                var items = new itemlist();
                items.Line_Id = Convert.ToInt32(row["Line_Id"]);
                items.Line_Name = row["Line_Name"].ToString();
                list.Add(items);
            }
            ViewBag.Line = new SelectList(list, "Line_Id", "Line_Name");
            #endregion

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StationViewModel vm)
        {
            try
            {
                if (!string.IsNullOrEmpty(vm.Station_Name))
                {
                    var vms = new StationViewModel
                    {
                        Station_Name = vm.Station_Name,
                        Line_Id=vm.Line_Id
                    };
                    var msg = _stationRepo.Save(vms);
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
                #region Create Line List using dt
                DataTable linedt = _lineRepo.GetDataTable();
                List<itemlist> list = new List<itemlist>();
                foreach (DataRow row in linedt.Rows)
                {
                    var items = new itemlist();
                    items.Line_Id = Convert.ToInt32(row["Line_Id"]);
                    items.Line_Name = row["Line_Name"].ToString();
                    list.Add(items);
                }
                ViewBag.Line = new SelectList(list, "Line_Id", "Line_Name");
                #endregion

                DataTable dt = _stationRepo.GetById(id);
                StationViewModel vm = new StationViewModel
                {
                    Station_Id = Convert.ToInt32(dt.Rows[0]["Station_Id"]),
                    Station_Name = dt.Rows[0]["Station_Name"].ToString(),
                    Line_Id = Convert.ToInt32(dt.Rows[0]["LINE_Id"])
                };
                return View(vm);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StationViewModel vm)
        {
            try
            {
                StationViewModel vms = new StationViewModel();
                vms.Station_Id = vm.Station_Id;
                vms.Station_Name = vm.Station_Name;
                vms.Line_Id = vm.Line_Id;
                var msg = _stationRepo.Update(vms);
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
                    var msg = _stationRepo.Delete(id);
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


public class itemlist
{
    public int Line_Id { get; set; }
    public string Line_Name { get; set; }
	public int Department_Id { get; set; }
	public string Department_Name { get; set; }
	public int Skill_Id { get; set; }
	public string Skill_Name { get; set; }
    public int Education_Id { get; set; }  
    public string Education_Name { get; set; }

}
