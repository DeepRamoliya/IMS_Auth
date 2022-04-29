﻿using IMS_Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Auth.Controllers
{
    public class FormMasterController : Controller
    {
        Entities db = new Entities();
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayFormMaster()
        {
            List<FormMaster> list = db.FormMasters.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormMaster form)
        {
            db.FormMasters.Add(form);
            form.CreatedOn = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("DisplayFormMaster");
        }

        public ActionResult EditFormMaster(int id)
        {
            FormMaster pr = db.FormMasters.Where(x => x.Id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult EditFormMaster(int id, FormMaster role)
        {
            FormMaster pr = db.FormMasters.Where(x => x.Id == id).SingleOrDefault();
            pr.Name = role.Name;
            pr.NavigateURL = role.NavigateURL;
            pr.ParentFormId = role.ParentFormId;
            pr.FormAccessCode = role.FormAccessCode;
            pr.DisplayOrder = role.DisplayOrder;
            //pr.Icon = role.Icon;
            //pr.IsDisplayMenu = role.IsDisplayMenu;
            //pr.IsDeleted = role.IsDeleted;
            pr.CreatedBy = role.CreatedBy;
            pr.UpdatedBy = role.UpdatedBy;
            pr.UpdatedOn = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("DisplayFormMaster");
        }

        public ActionResult Delete(int id)
        {
            FormMaster form = db.FormMasters.Where(x => x.Id == id).SingleOrDefault();
            return View(form);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormMaster form)
        {
            FormMaster f = db.FormMasters.Where(x => x.Id == id).SingleOrDefault();
            db.FormMasters.Remove(f);
            db.SaveChanges();
            return RedirectToAction("DisplayFormMaster");
        }
    }
}