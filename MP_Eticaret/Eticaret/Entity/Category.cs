using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
        public int ParentId { get; set; }
        //public List<Category> SubCategories { get; internal set; }
    }
}