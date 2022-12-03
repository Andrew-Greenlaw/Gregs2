namespace Gregs2.Services;
public class JobsService
{
  private readonly JobsRepository _repo;

  internal Job CreateJob(Job jobData)
  {
    return _repo.Create(jobData);
  }

  internal void DeleteJob(int id, string userId)
  {
    Job job = _repo.GetById(id);
    if (job.CreatorId != userId)
    {
      throw new Exception("you do not have permision to delete this job");
    }
    _repo.Delete(id);
  }

  internal List<Job> GetAllJobs()
  {
    return _repo.Get();
  }

  internal Job GetJobById(int id)
  {
    return _repo.GetById(id);
  }

  internal Job UpdateJob(Job jobData, string userId)
  {
    Job job = GetJobById(jobData.Id);
    if (job.CreatorId != userId)
    {
      throw new Exception("you do not have permision to change this job");
    }
    job.Company = jobData.Company ?? job.Company;
    job.JobTitle = jobData.JobTitle ?? job.JobTitle;
    job.Hours = jobData.Hours > 0 ? jobData.Hours : job.Hours;
    job.Rate = jobData.Rate > 0 ? jobData.Rate : job.Rate;
    job.Description = jobData.Description ?? job.Description;
    job.CreatedAt = job.CreatedAt;
    Job updatedJob = _repo.Update(job);
    return updatedJob;
  }
}