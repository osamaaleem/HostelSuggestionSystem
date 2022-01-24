using HostelSuggestionSystem_WE.DAL;
using HostelSuggestionSystem_WE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelSuggestionSystem_WE.Controllers
{
    public class HostelsController : Controller
    {
        // GET: Hostels
        public ActionResult Index(String search,string filterBy)
        {
            HttpCookie cookie = new HttpCookie("UserData");
            cookie["UserName"] = "-1";
            if (Session["login"] != null)
            {
                Users user = new Users();
                user.UserName = Session["login"].ToString();
                cookie["UserName"] = user.UserName;
                cookie["LoginData"] = DateTime.Now.ToString();
            }
            HostelsEntity hostelsEntity = new HostelsEntity();
            List<Hostels> hostels = new List<Hostels>();
            if (search != null)
            {
                hostels = hostelsEntity.GetHostelsByFilter("Name", search);
            }
            else if(filterBy != null)
            {
                hostels = hostelsEntity.GetHostelsByFilter(filterBy,null);
            }
            else
            {
                hostels = hostelsEntity.GetHostels();
            }
            Response.Cookies.Add(cookie);
           // cookie.Expires = DateTime.Now.AddYears(1);
            return View(hostels);
        }
        public ActionResult AddHostel()
        {
            return View();
        }
        public ActionResult UpdateHostel(Int64 Id)
        {
            List<Hostels> list = new List<Hostels>();
            HostelsEntity entity = new HostelsEntity();
            list = entity.GetHostelsById(Id);
            Hostels hostels = new Hostels();
            hostels = list[0];
            return View(hostels);
        }
        [HttpPost]
        public ActionResult UpdateHostel(Hostels hostel)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected = 0;
                var path = Path.Combine(Server.MapPath("~/Images"), hostel.HostelImage.FileName);
                hostel.HostelImageUrl = hostel.HostelImage.FileName;
                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                var ext = Path.GetExtension(hostel.HostelImage.FileName);
                if (allowedExtensions.Contains(ext))
                {
                    HostelsEntity entity = new HostelsEntity();
                    rowsAffected = entity.UpdateHostel(hostel);
                }
                if (rowsAffected != 0)
                {
                    hostel.HostelImage.SaveAs(path);
                }

                return RedirectToAction("Index");
            }
            ViewBag.Message = "An exception occured";

            return View(hostel);
        }

        [HttpPost]
        public ActionResult AddHostel(Hostels hostel)
        {
            
            if (ModelState.IsValid)
            {
                int rowsAffected = 0;
                var path = Path.Combine(Server.MapPath("~/Images"), hostel.HostelImage.FileName);
                hostel.HostelImageUrl = hostel.HostelImage.FileName;
                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                var ext = Path.GetExtension(hostel.HostelImage.FileName);
                if (allowedExtensions.Contains(ext))
                {
                    HostelsEntity entity = new HostelsEntity();
                    rowsAffected = entity.AddHostels(hostel);
                }
                if (rowsAffected != 0)
                {
                    hostel.HostelImage.SaveAs(path);
                }

                return RedirectToAction("Index");
            }
            ViewBag.Message = "An exception occured";

            return View(hostel);
        }
        //[HttpPost]
        //public ActionResult UpdateHostel(Hostels hostel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int rowsAffected;
        //        HostelsEntity entity = new HostelsEntity();
        //        rowsAffected = entity.UpdateHostel(hostel);
        //        if (rowsAffected != 0)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.Message = "An exception occured";
        //    }
        //    return View(hostel);
        //}
        public ActionResult HostelDetails(Int64 id)
        {
            List<Hostels> list = new List<Hostels>();
            HostelsEntity entity = new HostelsEntity();
            list = entity.GetHostelsById(id);
            Hostels hostels = new Hostels();
            hostels = list[0];
            return View(hostels);
        }
        public ActionResult DeleteHostel(Int64 Id)
        {
            HostelsEntity entity = new HostelsEntity();
            entity.DeleteHostel(Id);
            return RedirectToAction("Index");
        }
    }
    
}