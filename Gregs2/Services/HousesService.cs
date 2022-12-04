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
}