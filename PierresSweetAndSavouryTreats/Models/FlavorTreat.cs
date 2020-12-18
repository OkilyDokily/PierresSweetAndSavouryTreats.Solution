namespace PierresSweetAndSavouryTreats.Models
{
  public class FlavorTreat
  {
    public int Id { get; set; }

    public int FlavorId { get; set; }
    public virtual Flavor Flavor { get; set; }

    public int TreatId { get; set; }
    public virtual Treat Treat { get; set; }
  }
}