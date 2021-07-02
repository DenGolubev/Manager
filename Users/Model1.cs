using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Manager.Users
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ManagerModelDB")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
