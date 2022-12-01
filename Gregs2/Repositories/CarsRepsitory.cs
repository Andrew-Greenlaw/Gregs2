using Gregs2.interfaces;

namespace Gregs2.Repositories;
public class CarsRepository : BaseRepository, IRepository<Car, int>
{
  public CarsRepository(IDbConnection db) : base(db)
  {
  }

  public Car Create(Car data)
  {
    string sql = @"
    INSERT INTO cars(make,model,year,price,description,imgUrl,creatorId)
    VALUES(@Make,@Model,@Year,@Price,@Description,@ImgUrl,@CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int carId = _db.ExecuteScalar<int>(sql, data);
    Car car = GetById(carId);
    return car;
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Car> Get()
  {
    throw new NotImplementedException();
  }

  public Car GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Car Update(Car data)
  {
    throw new NotImplementedException();
  }
}