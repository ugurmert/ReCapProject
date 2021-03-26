using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server --> Server adresi "(localdb)\mssqllocaldb"
            //Database --> Veritabanı adı "ReCapProjectDB"
            //Trusted_Connection=true --> Şifre gerektirmeden bağlanmayı etkin kılmak içik kullandık.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProjectDB;Trusted_Connection=true");
        }

        //DbSet<> --> class'ı veritabanındaki tabloya bağlamak için kullanıyoruz.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
