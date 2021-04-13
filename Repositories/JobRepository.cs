using System.Collections.Generic;
using System.Data;
using Dapper;
using contractors.Models;

namespace contractors.Repositories
{
    public class JobsRepository
    {
        public readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Job> Get()               //GET
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }

        internal Job Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM jobss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { Id });
        }

        internal Job Create(Job newJob)             //POST
        {
            string sql = @"
      INSERT INTO jobss
      (make, model, year)
      VALUES
      (@Make, @Model, @Year);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newJob);
            newJob.id = id;
            return newJob;
        }

        internal Job Edit(Job jobsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE jobs
      SET
          make = @Make,
          model = @Model,
          year = @Year
          WHERE id = @Id;
          SELECT * FROM jobs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Job>(sql, jobsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}