using MVC.Models;
using System.Data.Entity;

namespace MVC.DataContext
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext() : base("name=Catalog")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAttribute> ItemAttributes { get; set; }
    }
}