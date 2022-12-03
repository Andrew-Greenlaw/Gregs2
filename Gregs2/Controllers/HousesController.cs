namespace Gregs2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _hs;
  private readonly Auth0Provider _auth0;
}