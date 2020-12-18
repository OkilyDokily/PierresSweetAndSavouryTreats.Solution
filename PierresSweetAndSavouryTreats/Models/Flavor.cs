using System.Collections.Generic;

namespace PierresSweetAndSavouryTreats.Models
{
  public class Flavor
  {
    public int Id{get;set;}
    public string Name { get; set; }
    public virtual IEnumerable<FlavorTreat> Treats {get;set;}

    public Flavor()
    {
        this.Treats = new HashSet<FlavorTreat>();
    }
  }
}