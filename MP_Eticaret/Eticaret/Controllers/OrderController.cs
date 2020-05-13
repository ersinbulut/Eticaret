using Eticaret.Entity;
using Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName=i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.Addres.AdresBasligi,
                Adres = i.Addres.Adres,
                Il = i.Addres.Il,
                Ilce = i.Addres.Ilce,
                Mahalle = i.Addres.Mahalle,
                PostaKodu = i.Addres.PostaKodu,
                UserAddressID =i.UserAddressID,
                /*kart bilgileri*/
                CartNumber = i.Pay.CartNumber,
                SecurityNumber = i.Pay.SecurityNumber,
                CartHasName = i.Pay.CartHasName,
                ExpYear = i.Pay.ExpYear,
                ExpMonth = i.Pay.ExpMonth,
                /**/
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.Image,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["mesaj"] = "bilgileriniz kaydedildi";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index"); 
        }
        public ActionResult BekleyenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
            return View(orders);
        }
        public ActionResult KargolananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı).ToList();
            return View(orders);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Paketlendi).ToList();
            return View(orders);
        }
     
    }
}