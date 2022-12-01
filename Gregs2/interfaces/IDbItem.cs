namespace Gregs2.interfaces;

public interface IDbitem<T>
{
  T Id { get; set; }
  DateTime CreatedAt { get; set; }
  DateTime UpdatedAt { get; set; }

}