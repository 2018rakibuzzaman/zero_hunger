﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;

namespace zero_hunger.Controllers
{
    public class CollectRequestController : Controller
    {
        private Icollect_request icollect_request;
        public CollectRequestController()
        {
            this.icollect_request = new RepositoryCollect_requestClass(new zero_hungerEntities());
        }

        // GET: CollectRequest
        public ActionResult Index()
        {
            var collect_requestlist = icollect_request.GetCollect_request();
            return View(collect_requestlist);
        }

        // GET: CollectRequest/Details/5
        public ActionResult Details(int id)
        {
            collect_request collect_Request = icollect_request.GetCollect_requestById(id);
            return View(collect_Request);
        }

        // GET: CollectRequest/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new collect_request());
        }

        // POST: CollectRequest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,collect_request collect_Request)
        {
            try
            {
                // TODO: Add insert logic here                
                icollect_request.InsertCollect_requestRecord(collect_Request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CollectRequest/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            collect_request collect_Request = icollect_request.GetCollect_requestById(id);
            return View(collect_Request);
        }

        // POST: CollectRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(collect_request collect_Request, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                icollect_request.UpdateCollect_requestRecord(collect_Request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CollectRequest/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            collect_request collector_request = icollect_request.GetCollect_requestById(id);
            return View(collector_request);
        }

        // POST: CollectRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                icollect_request.DeleteCollect_requestRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
