using Gregs2.interfaces;
namespace Gregs2.Models;

public class Car : IHasCreator
{
  public string Make { get; set; }
  public string Model { get; set; }
  public int Year { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public string ImgUrl { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public bool IsSold { get; set; }
}
public class FavoritedCar : Car
{
  public int FavoriteId { get; set; }
}