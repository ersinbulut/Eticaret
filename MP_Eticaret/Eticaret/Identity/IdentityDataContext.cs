using Eticaret.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext():base("IdentityConnection")
        {

        }

        public System.Data.Entity.DbSet<Eticaret.Identity.ApplicationRole> IdentityRoles { get; set; }


        //public System.Data.Entity.DbSet<Eticaret.Identity.ApplicationUser> IdentityUsers { get; set; }
    }
}