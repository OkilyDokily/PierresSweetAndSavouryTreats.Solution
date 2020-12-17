using System.Collections.Generic;

namespace PierresSweetAndSavouryTreats.Models
{
  public class Flavor
  {
    public int Id;
    public string Name { get; set; }
    public virtual IEnumerable<FlavorTreats> Treats {get;set;}

    public Flavor()
    {
        this.Treats = new HashSet<FlavorTreats>();
    }
  }
}