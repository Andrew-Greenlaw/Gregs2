namespace Gregs2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
  private readonly JobsService _js;
  private readonly Auth0Provider _auth0;
}