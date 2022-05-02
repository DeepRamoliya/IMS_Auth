using IMS_Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Auth.Controllers
{
    public class UserMasterController : Controller
    {
        Entities db = new Entities();
        // GET: UserMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayUserMasters()
        {
            List<UserMaster> list = db.UserMasters.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserMaster user)
        {
            db.UserMasters.Add(user);
            user.CreatedOn = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("DisplayUserMasters");
        }

        public ActionResult EditUserMasters(int id)
        {
            UserMaster ur = db.UserMasters.Where(x => x.Id == id).SingleOrDefault();
            return View(ur);
        }

        [HttpPost]
        public ActionResult EditUserMasters(int id, UserMaster user)
        {
            UserMaster ur = db.UserMasters.Where(x => x.Id == id).SingleOrDefault();
            ur.UserName = user.UserName;
            ur.Name = user.Name;
            ur.Email = user.Email;
            ur.Role = user.Role;
            ur.Designation = user.Designation;
            ur.MobileNo = user.MobileNo;
            //ur.PhoneNo = user.PhoneNo;
            ur.UpdatedBy = user.UpdatedBy;
            ur.UpdatedOn = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("DisplayUserMasters");
        }

        public ActionResult Delete(int id)
        {
            UserMaster user = db.UserMasters.Where(x => x.Id == id).SingleOrDefault();
            return View(user);
        }


        [HttpPost]
        public ActionResult Delete(int id, UserMaster user)
        {
            UserMaster u = db.UserMasters.Where(x => x.Id == id).SingleOrDefault();
            db.UserMasters.Remove(u);
            db.SaveChanges();
            return RedirectToAction("DisplayUserMasters");
        }

    }
}