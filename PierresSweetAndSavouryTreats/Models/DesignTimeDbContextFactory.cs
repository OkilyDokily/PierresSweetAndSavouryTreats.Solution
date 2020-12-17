using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresSweetAndSavouryTreats.Models
{
  public class PierresSweetAndSavourTreatsContextFactory : IDesignTimeDbContextFactory<PierresSweetAndSavouryTreatsContext>
  {

    PierresSweetAndSavouryTreatsContext IDesignTimeDbContextFactory<PierresSweetAndSavouryTreatsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<PierresSweetAndSavouryTreatsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PierresSweetAndSavouryTreatsContext(builder.Options);
    }
  }
}