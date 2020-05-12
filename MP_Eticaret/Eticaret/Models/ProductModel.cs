using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }//bir ürünün bir kategorisi vardır bir kategorinin birden fazla ürünü olabilir.
        public int ParentId { get; internal set; }
        //public int SubCatId { get; set; }
    }
}