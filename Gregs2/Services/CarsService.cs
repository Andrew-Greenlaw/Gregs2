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

  internal Car GetCarById(int id)
  {

    Car car = _repo.GetById(id);
    if (car == null)
    {
      throw new Exception("Invalid Car Id");
    }
    return car;
  }

  internal Car UpdateCar(Car carData, string userId)
  {
    Car car = GetCarById(carData.Id);
    if (car.CreatorId != userId)
    {
      throw new Exception("You Do not have permision to edit this car");
    }
    car.Make = carData.Make ?? car.Make;
    car.Model = carData.Model ?? car.Model;
    // car.Year = carData.Year ?? car.Year;
    // car.Price = carData.Price ?? car.Price;

    Car updatedCar = _repo.Update(car);
    return updatedCar;
  }
}