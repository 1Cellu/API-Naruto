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
    }
}
