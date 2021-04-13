
using System;
using System.Data;
using contractors.Models;
using Dapper;

namespace contractors.Repositories
{
    public class ContractorsJobsRepository
    {
        private readonly IDbConnection _db;
        public ContractorsJobsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal WishListProduct Create(WishListProduct newWLP)
        {
            string sql = @"
      INSERT INTO contractorsjobs 
      (productId, wishlistId, creatorId) 
      VALUES 
      (@ProductId, @WishListId, @CreatorId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newWLP);
            newWLP.Id = id;
            return newWLP;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractorsjobs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });

        }
    }
}