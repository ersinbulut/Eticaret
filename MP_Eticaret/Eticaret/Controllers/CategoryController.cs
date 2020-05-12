using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entity;
using Eticaret.Models;

namespace Eticaret.Controllers
{
    public class CategoryController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Category
        [Authorize(Roles ="admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult Index()
        {
            return View(db.Categories.ToList().OrderByDescending(x=>x.Id));
        }
        public PartialViewResult _CategoryList()
        {
            var kategoriler = db.Categories.Include(i => i.Products).Select(x => new CategoryModel()
            //var kategoriler = db.Categories.Select(x => new Category()
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Name = x.Name,
                Count = x.Products.Count()
            }
            ).ToList();
            return PartialView(kategoriler);

            //List<Category> all = new List<Category>();
            //all = db.Categories.OrderBy(a => a.ParentId).ToList();
            //return PartialView(all);
        }

        // GET: Category/Details/
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Create
        [Authorize(Roles = "admin")]
        public ActionResult SubCreate()
        {
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult SubCreate([Bind(Include = "Id,Name,Description,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            var categories = db.Categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            categories.Add(new SelectListItem()
            {
                Value = "0",
                Text = "Ana Kategori",
                Selected = true
            });
            ViewBag.Categories = categories;
            return View(cat);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ParentId")] Category category)
        {
            if (category.Id > 0)
            {
                var cat = db.Categories.FirstOrDefault(x => x.Id == category.Id);
                cat.Description = category.Description;
                cat.Name = category.Name;

                if (category.ParentId > 0)
                    cat.ParentId = category.ParentId;
                else
                    cat.ParentId = 0;
            }
            else
            {
                if (category.ParentId == 0)
                    category.ParentId = 0;
                db.Entry(category).State = System.Data.Entity.EntityState.Added;

            }
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // GET: Category/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
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
