using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HostelSuggestionSystem_WE.Models;
using HostelSuggestionSystem_WE.DAL;

namespace HostelSuggestionSystem_WE.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            if(ModelState.IsValid)
            {
                UsersEntity entity = new UsersEntity();
                if (entity.IsValidUser(user))
                {
                    Session["login"] = user;
                    return RedirectToAction("Index", "Hostels");
                }
                else
                {
                    ViewBag.Message = "Invalid Login";
                }
            }
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                int count = 0;
                UsersEntity entity = new UsersEntity();
                count = entity.RegisterUser(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }
}