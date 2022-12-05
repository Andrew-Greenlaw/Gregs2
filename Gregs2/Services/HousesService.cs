namespace Gregs2.Services;
public class HousesService
{
  private readonly HousesRepository _repo;

  public HousesService(HousesRepository repo)
  {
    _repo = repo;
  }

  internal House CreateHouse(House houseData)
  {
    return _repo.Create(houseData);
  }

  internal List<House> GetAllHouses()
  {
    return _repo.Get();
  }

  internal House GetById(int id)
  {
    House house = _repo.GetById(id);
    if (house == null)
    {
      throw new Exception("Invalid or Bad Id");
    }
    return house;
  }

  internal House UpdateHouse(House houseData, string userId)
  {
    House house = GetById(houseData.Id);
    if (house.CreatorId != userId)
    {
      throw new Exception("You do not have permision to edit this house");
    }
    house.Bathrooms = houseData.Bathrooms > 0 ? houseData.Bathrooms : house.Bathrooms;
    house.Bedrooms = houseData.Bedrooms > 0 ? houseData.Bedrooms : house.Bedrooms;
    house.ImgUrl = houseData.ImgUrl ?? house.ImgUrl;
    house.Description = houseData.Description ?? house.Description;
    return _repo.Update(house);
  }
}