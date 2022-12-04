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
}