using Gregs2.interfaces;

namespace Gregs2.Repositories;
public class JobsRepository : BaseRepository, IRepository<Job, int>
{
  public JobsRepository(IDbConnection db) : base(db)
  {

  }

  public Job Create(Job data)
  {
    string sql = @"
    INSERT INTO jobs(company,jobTitle,hours,rate,description,creatorId)
    VALUES(@Company,@JobTitle,@Hours,@Rate,@Description,@CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int jobId = _db.ExecuteScalar<int>(sql, data);
    Job job = GetById(jobId);
    return job;
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Job> Get()
  {
    throw new NotImplementedException();
  }

  public Job GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Job Update(Job data)
  {
    throw new NotImplementedException();
  }
}