using System.ComponentModel.DataAnnotations;

namespace DiscountAPI.Models;
 
public class Discount
{
  [Key]
  public string  id { get; set; }
  public string name { get; set; }
  public DateTime startDate { get; set; }
  public DateTime endDate { get; set; }
  public string type { get; set; }
  public float value { get; set; }
  public string timerId { get; set; }
  public Guid[] listProductId { get; set; }
  public virtual List<DiscountProduct> discountProducts { get; set; }
}
