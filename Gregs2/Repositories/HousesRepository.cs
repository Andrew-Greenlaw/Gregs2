using Gregs2.interfaces;

namespace Gregs2.Repositories;
public class HousesRepository : BaseRepository, IRepository<House, int>
{
  public HousesRepository(IDbConnection db) : base(db)
  {
  }

  public House Create(House data)
  {
    string sql = @"
    INSERT INTO houses(bedrooms,bathrooms,levels,imgUrl,price,description,creatorId)
    VALUES(@Bedrooms,@Bathrooms,@Levels,@ImgUrl,@Price,@Description,@CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int houseId = _db.ExecuteScalar<int>(sql, data);
    return GetById(houseId);
  }

  public void Delete(int id)
  {
    string sql = "DELETE FROM houses WHERE id = @id;";
    _db.Execute(sql, new { id });
  }

  public List<House> Get()
  {
    string sql = @"
    SELECT
    h.*,
    a.*
    FROM houses h
    JOIN accounts a ON a.id = h.creatorId
    ;";
    return _db.Query<House, Profile, House>(sql, (h, p) =>
    {
      h.Creator = p;
      return h;
    }).ToList();
  }

  public House GetById(int id)
  {
    string sql = @"
    SELECT
    h.*,
    a.*
    FROM houses h
    JOIN accounts a ON a.id = h.creatorId
    WHERE id = @id
    ;";
    return _db.Query<House, Profile, House>(sql, (h, p) =>
    {
      h.Creator = p;
      return h;
    }, new { id }).FirstOrDefault();
  }

  // public House UpdateIsSold(){

  // }

  public House Update(House data)
  {
    string sql = @"
    UPDATE houses SET
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    levels = @Levels,
    imgUrl = @ImgUrl,
    price = @Price,
    description = @Description
    WHERE id = @Id
    ;";
    int rowsEffected = _db.Execute(sql, data);
    if (rowsEffected == 0)
    {
      throw new Exception("something went wrong nothing changed");
    }
    return data;
  }
}