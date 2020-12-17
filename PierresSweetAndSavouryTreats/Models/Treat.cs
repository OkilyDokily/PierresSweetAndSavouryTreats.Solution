using System.Collections.Generic;

namespace PierresSweetAndSavouryTreats.Models
{
  public class Treat
  {
    public int Id;
    public string Name { get; set; }
    public virtual IEnumerable<FlavorTreats> Flavors{get;set;}
    public Treat()
    {
        this.Flavors = new HashSet<FlavorTreats>();
    }
  }
}