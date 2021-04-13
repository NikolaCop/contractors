using System;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
    public class ContractorsJobsService
    {
        private readonly ContractorsJobsRepository _repo;

        public ContractorsJobsService(ContractorsJobsRepository repo)
        {
            _repo = repo;
        }

        internal WishListProduct Create(WishListProduct newWLP)
        {
            //TODO if they are creating a wishlistproduct, make sure they are the creator of the list
            return _repo.Create(newWLP);

        }

        internal void Delete(int id)
        {
            //NOTE getbyid to validate its valid and you are the creator
            _repo.Delete(id);
        }
    }
}