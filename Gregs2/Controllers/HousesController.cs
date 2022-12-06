namespace Gregs2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _hs;
  private readonly Auth0Provider _auth0;

  public HousesController(HousesService hs, Auth0Provider auth0)
  {
    _hs = hs;
    _auth0 = auth0;
  }
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<House>> CreateHouse([FromBody] House houseData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      houseData.CreatorId = userInfo?.Id;
      House house = _hs.CreateHouse(houseData);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<House>> GetAllHouses()
  {
    try
    {
      List<House> houses = _hs.GetAllHouses();
      return Ok(houses);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<House> GetHouseById(int id)
  {
    try
    {
      House house = _hs.GetById(id);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<House>> UpdateHouse([FromBody] int id, House houseData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      houseData.Id = id;
      House house = _hs.UpdateHouse(houseData, userInfo?.Id);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteHouse(int id)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _hs.DeleteHouse(id, userInfo.Id);
      return Ok("You Successfully Deleted this House");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}