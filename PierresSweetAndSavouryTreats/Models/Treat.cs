using System.Collections.Generic;

namespace PierresSweetAndSavouryTreats.Models
{
  public class Treat
  {
    public int Id {get;set;}
    public string Name { get; set; }
    public virtual IEnumerable<FlavorTreat> Flavors{get;set;}
    public Treat()
    {
        this.Flavors = new HashSet<FlavorTreat>();
    }
  }
}