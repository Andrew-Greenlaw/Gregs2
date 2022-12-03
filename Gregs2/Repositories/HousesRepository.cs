using Gregs2.interfaces;

namespace Gregs2.Repositories;
public class HousesRepository : BaseRepository, IRepository<House, int>
{
  public HousesRepository(IDbConnection db) : base(db)
  {
  }

  public House Create(House data)
  {
    throw new NotImplementedException();
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<House> Get()
  {
    throw new NotImplementedException();
  }

  public House GetById(int id)
  {
    throw new NotImplementedException();
  }

  public House Update(House data)
  {
    throw new NotImplementedException();
  }
}