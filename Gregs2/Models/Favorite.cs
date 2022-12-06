namespace Gregs2.Models;

using System;
using Gregs2.interfaces;
public class Favorite : IDbitem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string AccountId { get; set; }
  public int CarId { get; set; }
  public int JobId { get; set; }
  public int HouseId { get; set; }
}