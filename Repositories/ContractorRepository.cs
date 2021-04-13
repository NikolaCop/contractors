using System.Collections.Generic;
using System.Data;
using Dapper;
using contractors.Models;

namespace contractors.Repositories
{
    public class ContractorsRepository
    {
        public readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Contractor> Get()               //GET
        {
            string sql = "SELECT * FROM contractors;";
            return _db.Query<Contractor>(sql);
        }

        internal Contractor Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM contractorss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Contractor>(sql, new { Id });
        }

        internal Contractor Create(Contractor newContractor)             //POST
        {
            string sql = @"
      INSERT INTO contractorss
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newContractor);
            newContractor.id = id;
            return newContractor;
        }

        internal Contractor Edit(Contractor contractorsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE contractorss
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM contractorss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Contractor>(sql, contractorsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM contractorss WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}