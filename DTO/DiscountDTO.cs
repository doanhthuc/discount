namespace DiscountAPI.DTO;
public class DiscountDTO
{
  public string id { get; set; }
  public string name { get; set; }
  public DateTime startDate { get; set; }
  public DateTime endDate { get; set; }
  public string type { get; set; }
  public string[] listProductId { get; set; }
  public float value { get; set; }

 
}