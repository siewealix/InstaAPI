using Microsoft.EntityFrameworkCore;
using InstawebAPI.Models;

namespace InstawebAPI.Data
{
    public class MydbContext : DbContext
    {
        public MydbContext(DbContextOptions<MydbContext> options) : base(options)
        {


        }

       public DbSet<Produit> Produits { get; set; }
       public DbSet<User> Users { get; set; }


    }
}
