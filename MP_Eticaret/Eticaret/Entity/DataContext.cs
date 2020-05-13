using Eticaret.Identity;
using Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        /**/
        public DbSet<Addres> Addres { get; set; }

        public DbSet<Pay> Pays { get; set; }
        //public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }

        //public DbSet<Messages> Messages { get; set; }
        //public DbSet<MessageReplies> MessageReplies { get; set; }



    }
}