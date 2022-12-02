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
    string sql = @"
    SELECT
    c.*,
    a.*
    FROM cars c
    JOIN accounts a ON a.id = c.creatorId
    ;";
    return _db.Query<Car, Profile, Car>(sql, (c, p) =>
    {
      c.Creator = p;
      return c;
    }).ToList();
  }

  public Car GetById(int id)
  {
    string sql = @"
    SELECT
    c.*,
    a.*
    FROM cars c
    JOIN accounts a ON a.id = c.creatorId
    WHERE c.id = @id
    ;";
    return _db.Query<Car, Profile, Car>(sql, (c, p) =>
    {
      c.Creator = p;
      return c;
    }, new { id }).FirstOrDefault();
  }

  public Car Update(Car data)
  {
    throw new NotImplementedException();
  }
}