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
        public ActionResult CreateRoleMaster()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoleMaster(RoleMaster role)
        {
             db.RoleMasters.Add(role);
            role.CreatedOn = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("DisplayRoleMaster");
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
            pr.UpdatedOn = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("DisplayRoleMaster");
        }

        public ActionResult ManageFormControll( int id)
        {
            List<FormRoleMapping> list = db.FormRoleMappings.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }
       /* public ActionResult DeleteRoleMaster(int id)
        {
            RoleMaster pro = db.RoleMasters.Where(x => x.RoleId == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult DeleteRoleMaster(int id, Product pro)
        {
            RoleMaster p = db.RoleMasters.Where(x => x.RoleId == id).SingleOrDefault();
            db.RoleMasters.Remove(p);
            db.SaveChanges();
            return RedirectToAction("DisplayRoleMaster");
        }*/

    }
}