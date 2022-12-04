using Gregs2.interfaces;
namespace Gregs2.Models;

public class House : IHasCreator
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int Bedrooms { get; set; }
  public int Bathrooms { get; set; }
  public int Levels { get; set; }
  public string ImgUrl { get; set; }
  public int Price { get; set; }
  public string Description { get; set; }
  public bool IsSold { get; set; }
}
public class FavoritedHouse : House
{
  public int FavoriteId { get; set; }
}