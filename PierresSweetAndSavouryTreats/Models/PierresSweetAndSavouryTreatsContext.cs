using Microsoft.EntityFrameworkCore;

namespace PierresSweetAndSavouryTreats.Models
{
  public class PierresSweetAndSavouryTreatsContext : DbContext
  {
    public virtual DbSet<Treat> Treats {get;set;}
    public virtual DbSet<Flavor> Flavors {get;set;}
    public virtual DbSet<FlavorTreats> FlavorTreats {get;set;}
    public PierresSweetAndSavouryTreatsContext(DbContextOptions options):base(options){}
  }
}