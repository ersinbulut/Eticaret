using Eticaret.Entity;
using Eticaret.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }

        public string ActivationCode { get; set; }//aktivasyon kodu

        /*Yeni Eklenen Alanlar*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }//dogum tarihi
        public string Gender { get; set; }//cinsiyet

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public string CartNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CartHasName { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }

        //[Required(ErrorMessage = "Lütfen Kart Numarası Giriniz..")]
        //[RegularExpression(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$", ErrorMessage = "Geçersiz Kart Numarası")]//visa için
        //[DisplayName("Kart Numarası")]
        //public string CartNumber { get; set; }
        //[Required(ErrorMessage = "Lütfen Güvenlik Numarası Giriniz..")]
        //[RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Geçersiz Güvenlik Numarası")]
        //[DisplayName("Güvenlik Numarası")]
        //public string SecurityNumber { get; set; }
        //[Required(ErrorMessage = "Lütfen Kart Sahibinin Adını Giriniz..")]
        //[DisplayName("Kart Üzerindeki İsim")]
        //public string CartHasName { get; set; }
        //[Required(ErrorMessage = "Lütfen Son Kullanma Yıl Giriniz..")]
        //[RegularExpression(@"\d{4}$", ErrorMessage = "Geçersiz Yıl Bilgisi")]
        //[DisplayName("Son Kullanma Yıl")]
        //public int ExpYear { get; set; }
        //[Required(ErrorMessage = "Lütfen Son Kullanma Ay Giriniz..")]
        //[RegularExpression(@"^[0-9]{1,2}", ErrorMessage = "Geçersiz Ay Bilgisi")]
        //[DisplayName("Son Kullanma Ay")]
        //public int ExpMonth { get; set; }
        /**/

        public virtual IEnumerable<Addres> Address { get; set; }

        public virtual IEnumerable<Pay> Pays { get; set; }
        //public virtual IEnumerable<Users> User { get; set; }

        //public virtual IEnumerable<Order> Orders { get; set; }

        //public string ActivationCode { get; set; }


    }
}