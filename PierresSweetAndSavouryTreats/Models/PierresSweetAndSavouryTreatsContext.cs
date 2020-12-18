using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresSweetAndSavouryTreats.Models
{
  public class PierresSweetAndSavouryTreatsContext : IdentityDbContext
  {
    public virtual DbSet<Treat> Treats { get; set; }
    public virtual DbSet<Flavor> Flavors { get; set; }
    public virtual DbSet<FlavorTreat> FlavorTreats { get; set; }

    //public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public PierresSweetAndSavouryTreatsContext(DbContextOptions options) : base(options) { }
  }
}