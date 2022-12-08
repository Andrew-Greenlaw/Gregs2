namespace Gregs2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _cs;
  private readonly Auth0Provider _auth0;

  public CarsController(CarsService cs, Auth0Provider auth0)
  {
    _cs = cs;
    _auth0 = auth0;
  }
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Car>> CreateCar([FromBody] Car carData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      carData.CreatorId = userInfo.Id;
      Car car = _cs.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _cs.GetAllCars();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}")]
  public ActionResult<Car> GetCarById(int id)
  {
    try
    {
      Car car = _cs.GetCarById(id);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Car>> UpdateCar([FromBody] Car carData, int id)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      carData.Id = id;
      Car car = _cs.UpdateCar(carData, userInfo?.Id);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteCar(int id)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _cs.DeleteCar(id, userInfo?.Id);
      return Ok("you succesfully deleted this car");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}