namespace Gregs2.Services;
public class CarsService
{
  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  public Car CreateCar(Car carData)
  {
    return _repo.Create(carData);
  }

  public List<Car> GetAllCars()
  {
    return _repo.Get();
  }
}