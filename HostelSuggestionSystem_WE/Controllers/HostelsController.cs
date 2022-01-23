using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HostelSuggestionSystem_WE.DAL;
using HostelSuggestionSystem_WE.Models;

namespace HostelSuggestionSystem_WE.Controllers
{
    public class HostelsController : Controller
    {
        // GET: Hostels
        public ActionResult Index()
        {
            HostelsEntity hostelsEntity = new HostelsEntity();
            List<Hostels> hostels = new List<Hostels>();
            hostels = hostelsEntity.GetHostels();
            return View(hostels);
        }
        public ActionResult AddHostel()
        {
            return View();
        }
        public ActionResult UpdateHostel(Int64 hostelId)
        {
            List<Hostels> list = new List<Hostels>();
            HostelsEntity entity = new HostelsEntity();
            list = entity.GetHostelsById(hostelId);
            return View(list[0]);
        }
        
        
        [HttpPost]
        public ActionResult AddHostel(Hostels hostel)
        {
            if(ModelState.IsValid)
            {
                int rowsAffected;
                HostelsEntity entity = new HostelsEntity();
                rowsAffected = entity.AddHostels(hostel);
                if(rowsAffected != 0)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "An exception occured";
            }
            return View(hostel);
        }
        [HttpPost]
        public ActionResult UpdateHostel(Hostels hostel)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected;
                HostelsEntity entity = new HostelsEntity();
                rowsAffected = entity.UpdateHostel(hostel);
                if (rowsAffected != 0)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "An exception occured";
            }
            return View(hostel);
        }
    }
}