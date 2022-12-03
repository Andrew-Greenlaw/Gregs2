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
    string sql = @"
    SELECT
    j.*,
    a.*
    FROM jobs j
    JOIN accounts a ON a.id = j.creatorId
    ;";
    return _db.Query<Job, Profile, Job>(sql, (j, p) =>
    {
      j.Creator = p;
      return j;
    }).ToList();
  }

  public Job GetById(int id)
  {
    string sql = @"
    SELECT
    j.*,
    a.*
    FROM jobs j
    JOIN accounts a ON a.id = j.creatorId
    WHERE id = @id
    ;";
    return _db.Query<Job, Profile, Job>(sql, (j, p) =>
    {
      j.Creator = p;
      return j;
    }, new { id }).FirstOrDefault();
  }

  public Job Update(Job data)
  {
    string sql = @"
    UPDATE jobs SET
    company = @Company,
    jobTitle = @JobTitle,
    hours = @Hours,
    rate = @Rate,
    description = @Description
    WHERE id = @Id
    ;";
    _db.Execute(sql, data);
    return data;
  }
}