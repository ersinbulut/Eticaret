using Eticaret.Identity;
using Eticaret.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    public class Addres
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Tanımını Giriniz..")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Giriniz..")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen İl Giriniz..")]
        public string Il { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe Giriniz..")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Giriniz..")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodu Giriniz..")]
        public string PostaKodu { get; set; }

        //public virtual Order Order { get; set; }

        //public virtual List<OrderDetailsModel> OrderDetailsModel { get; set; }



    }
}