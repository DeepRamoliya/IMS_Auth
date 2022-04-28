using IMS_Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Auth.Controllers
{
    public class RoleMasterController : Controller
    {
        Entities db = new Entities();
        // GET: RoleMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayRoleMaster()
        {
            List<RoleMaster> list = db.RoleMasters.OrderByDescending(x => x.RoleId).ToList();
            return View(list);
        }

        public ActionResult EditRoleMaster(int id )
        {
            RoleMaster pr = db.RoleMasters.Where(x => x.RoleId == id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult EditRoleMaster(int id, RoleMaster role)
        {
            RoleMaster pr = db.RoleMasters.Where(x => x.RoleId == id).SingleOrDefault();
            pr.RoleName = role.RoleName;
            pr.RoleCode = role.RoleCode;
            pr.CreatedBy = role.CreatedBy;
            pr.UpdatedBy = role.UpdatedBy;
            pr.UpdatedOn = DateTime.Today;

            db.SaveChanges();
            return RedirectToAction("DisplayRoleMaster");
        }

    }
}