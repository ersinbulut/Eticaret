using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    public class Comments
    {
        public int Id { get; set; }
        public string Yorum { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
        public string UserName { get; set; }
        public System.DateTime AddedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}