namespace Gregs2.Services;
public class JobsService
{
  private readonly JobsRepository _repo;

  internal Job CreateJob(Job jobData)
  {
    return _repo.Create(jobData);
  }

  internal List<Job> GetAllJobs()
  {
    return _repo.Get();
  }
}