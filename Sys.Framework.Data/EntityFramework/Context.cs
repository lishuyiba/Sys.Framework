using Sys.Framework.Model.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Data.EntityFramework
{
    public class Context : DbContext
    {
        public Context() : base("Robot")
        {
            Database.SetInitializer<Context>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<T_Sys_User> T_Sys_User { get; set; }
        public DbSet<T_Sys_Role> T_Sys_Role { get; set; }
        public DbSet<T_Sys_Accept> T_Sys_Accept { get; set; }
        public DbSet<T_Sys_Business> T_Sys_Business { get; set; }
    }
}
