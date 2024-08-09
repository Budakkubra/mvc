using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UrumsalWeb.Models.Model;

namespace UrumsalWeb.Models.DataContext
{
    public class UrumsalDBContext:DbContext
    {
        public UrumsalDBContext():base("UrumsalWebDB")
        {
            
        }
        public DbSet<Admin> Admin{ get;set; }
        public DbSet<Blog>Blog{ get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Hizmet>Hizmet{get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kimlik>Kimlik{ get; set; }
        public DbSet<Slider> Slider { get; set; }




    }
}