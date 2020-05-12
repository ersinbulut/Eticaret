using Eticaret.Entity;
using Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urun = db.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 25 ? i.Description.Substring(0, 20) + "...":i.Description,//eğer description 25 karakterden büyükse 20. karakterin sonuna 3 nokta koy
                Price=i.Price,
                Stock=i.Stock,
                Image=i.Image,
                CategoryId=i.CategoryId
            }
            ).ToList();
            return View(urun);
        }
        public PartialViewResult _Slider()
        {
            return PartialView(db.Products.Where(x => x.Slider && x.IsApproved).Take(3).ToList());
        }
        public PartialViewResult FeaturedProductList()
        {
            return PartialView(db.Products.Where(x=>x.IsFeatured && x.IsApproved).Take(3).ToList());
        }
        public ActionResult ProductList(int categoryId, int subCategoryId)
        {
            var query = db.Products.AsQueryable();

            if (categoryId > 0)
                query = query.Where(i => i.CategoryId == subCategoryId);
            else
                query = query.Where(i => i.Category.ParentId == subCategoryId || i.CategoryId == subCategoryId);

            return View(query.ToList());
        }
        //public ActionResult ProductList1(int id)
        //{
        //    return View(db.Products.Where(i => i.CategoryId == id).ToList());
        //}
        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Search(string q)//Arama işlemi
        {
            var p = db.Products.Where(i => i.IsApproved == true);
            if (!string.IsNullOrEmpty(q))//eger q nun içerisi boş değilse
            {
                p = p.Where(i => i.Name.Contains(q) || i.Description.Contains(q));//name veya description kısmında arama kriteri varsa filtreler
            }
            return View(p.ToList());
        }
        public ActionResult Product()
        {
            var urun = db.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 25 ? i.Description.Substring(0, 20) + "..." : i.Description,//eğer description 25 karakterden büyükse 20. karakterin sonuna 3 nokta koy
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId
            }
           ).ToList();
            return View(urun);
        }
        public ActionResult Comment()
        {
            Comments yorum = new Comments();
            return View(yorum);
        }
        [HttpPost]
        public void Comment(Comments comment)
        {
            if (ModelState.IsValid)
            {
                comment.AddedDate = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                //return RedirectToAction("MesajGoster");
            }
            //return View();
        }
        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}