using Gregs2.interfaces;
namespace Gregs2.Models;

public class House : IHasCreator
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}