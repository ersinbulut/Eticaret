using Eticaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public int AdresId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }//sipariş durumu

        //public string Image { get; set; }
    }
}