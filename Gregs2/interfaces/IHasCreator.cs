namespace Gregs2.interfaces;
public interface IHasCreator : IDbitem<int>
{
  string CreatorId { get; set; }
  Profile Creator { get; set; }
}