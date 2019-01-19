namespace GroupTrip.Shared.Models
{
  public class Payment
  {
    public int Id { get; set; }
    public double Value { get; set; }
    public int PersonId { get; set; }
    public int GroupId { get; set; }
  }
}