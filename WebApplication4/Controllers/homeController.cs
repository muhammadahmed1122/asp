using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class homeController : Controller
    {
        ahmedEntities db = new ahmedEntities();
        //
        // GET: /home/
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(product pro)
        {
            db.products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("SHOW");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
             if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(product pro)
        {
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("SHOW");
        }


    [HttpGet]
        public ActionResult det(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("SHOW");
        }

        [HttpGet]
    public ActionResult detl(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        product product = db.products.Find(id);
        if (product == null){
        
            return HttpNotFound();
        }
            return View(product);
    }

        [HttpGet]
        public ActionResult SHOW(string searching)
        {
            return View(db.products.Where(a => a.name.Contains(searching) || searching == null).ToList());
        } 

	}

}