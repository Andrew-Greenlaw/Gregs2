namespace Gregs2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
  private readonly JobsService _js;
  private readonly Auth0Provider _auth0;

  public JobsController(JobsService js, Auth0Provider auth0)
  {
    _js = js;
    _auth0 = auth0;
  }
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Job>> CreateJob([FromBody] Job jobData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      jobData.CreatorId = userInfo?.Id;
      Job job = _js.CreateJob(jobData);
      return Ok(job);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet]
  public ActionResult<List<Job>> GetAllJobs()
  {
    try
    {
      List<Job> jobs = _js.GetAllJobs();
      return Ok(jobs);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}")]
  public ActionResult<Job> GetJobById(int id)
  {
    try
    {
      Job job = _js.GetJobById(id);
      return Ok(job);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Job>> UpdateJob([FromBody] Job jobData, int id)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      jobData.Id = id;
      Job job = _js.UpdateJob(jobData, userInfo?.Id);
      return Ok(job);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteJob(int id)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _js.DeleteJob(id, userInfo.Id);
      return Ok("you succesfully deleted this job");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}