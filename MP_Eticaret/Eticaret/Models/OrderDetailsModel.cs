using Eticaret.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }//sipariş durumu

        public string UserName { get; set; }

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public int UserAddressID { get; set; }
        public virtual Addres UserAddress { get; set; }

        //public virtual List<Addres> Addres { get; set; }

        //*//*/

        [Required(ErrorMessage = "Lütfen Kart Numarası Giriniz..")]
        [RegularExpression(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$", ErrorMessage = "Geçersiz Kart Numarası")]//visa için
        public string CartNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Güvenlik Numarası Giriniz..")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Geçersiz Güvenlik Numarası")]
        public string SecurityNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Kart Sahibinin Adını Giriniz..")]
        public string CartHasName { get; set; }
        [Required(ErrorMessage = "Lütfen Son Kullanma Yıl Giriniz..")]
        [RegularExpression(@"\d{4}$", ErrorMessage = "Geçersiz Yıl Bilgisi")]
        public int ExpYear { get; set; }
        [Required(ErrorMessage = "Lütfen Son Kullanma Ay Giriniz..")]
        [RegularExpression(@"^[0-9]{1,2}", ErrorMessage = "Geçersiz Ay Bilgisi")]
        public int ExpMonth { get; set; }
        //*//*/

        public virtual List<OrderLineModel> OrderLines { get; set; }
    }
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
      
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}