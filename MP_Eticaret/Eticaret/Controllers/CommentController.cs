using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entity;

namespace Eticaret.Controllers
{
    public class CommentController : Controller
    {
        private DataContext db = new DataContext();

        //// GET: Comment
        //public ActionResult Index()
        //{
        //    var comments = db.Comments.Include(c => c.Products);
        //    return View(comments.ToList());
        //}

        // GET: Comment/OnayliYorum
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult OnayliYorum()
        {
            return View(db.Comments.Where(x => x.IsApproved).ToList());
        }

        // GET: Comment/OnaysizYorum
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult OnaysizYorum()
        {
            return View(db.Comments.Where(x => x.IsApproved == false).ToList());
        }

        //// GET: Comment/Details/5
        //[Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comments comments = db.Comments.Find(id);
        //    if (comments == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comments);
        //}

        //// GET: Comment/Create
        //[Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        //public ActionResult Create()
        //{
        //    ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
        //    return View();
        //}

        //// POST: Comment/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        //public ActionResult Create([Bind(Include = "Id,Yorum,Name,ProductId,UserName,AddedDate,IsApproved")] Comments comments)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Comments.Add(comments);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", comments.ProductId);
        //    return View(comments);
        //}

        // GET: Comment/Edit/5
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", comments.ProductId);
            return View(comments);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult Edit([Bind(Include = "Id,Yorum,Name,ProductId,UserName,AddedDate,IsApproved")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OnaysizYorum");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", comments.ProductId);
            return View(comments);
        }

        // GET: Comment/Delete/5
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult DeleteConfirmed(int id)
        {
            Comments comments = db.Comments.Find(id);
            db.Comments.Remove(comments);
            db.SaveChanges();
            return RedirectToAction("OnayliYorum");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
