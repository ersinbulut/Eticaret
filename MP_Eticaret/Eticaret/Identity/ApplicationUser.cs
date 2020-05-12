using Eticaret.Entity;
using Eticaret.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
        /**/

        public virtual IEnumerable<Addres> Address { get; set; }
        //public virtual IEnumerable<Users> User { get; set; }

        //public virtual IEnumerable<Order> Orders { get; set; }

        //public string ActivationCode { get; set; }


    }
}