using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using API_WEB.Models;

namespace API_WEB.DAO
{
    public class NinjaContext : DbContext
    {
        public NinjaContext(DbContextOptions<NinjaContext> options) : base(options)
        {

        }

        public DbSet<Ninja> Ninjas { get; set; } = null;

        public DbSet<API_WEB.Models.Cla> Cla { get; set; }

        public DbSet<API_WEB.Models.KekkeiGenkai> KekkeiGenkai { get; set; }

        public DbSet<API_WEB.Models.Village> Village { get; set; }
    }
}
