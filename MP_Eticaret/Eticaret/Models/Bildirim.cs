using Eticaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Models
{
    public class Bildirim
    {
        DataContext db = new DataContext();
        public List<Order>SiparisBekleyenListe()
        {
            return db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
        }
        public List<Comments> OnayBekleyenListe()
        {
            return db.Comments.Where(i => i.IsApproved == false).ToList();
        }
    }
}