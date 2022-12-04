using Gregs2.interfaces;
namespace Gregs2.Models;

public class Job : IHasCreator
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Company { get; set; }
  public string JobTitle { get; set; }
  public int Hours { get; set; }
  public int Rate { get; set; }
  public string Description { get; set; }

}
public class FavoritedJob : Job
{
  public int FavoriteId { get; set; }
}
