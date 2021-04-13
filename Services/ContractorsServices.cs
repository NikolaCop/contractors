using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<Contractor> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Contractor GetById(string id)
        {
            Contractor contractors = _repo.Get(id);
            if (contractors == null)
            {
                throw new Exception("invalid id");
            }
            return contractors;
        }


        //CREATE/POST
        internal Contractor Create(Contractor newContractors)
        {
            return _repo.Create(newContractors);
        }

        //EDIT/PUT
        internal Contractor Edit(Contractor editContractors)
        {
            Contractor original = GetById(editContractors.contractorId);

            original.Name = editContractors.Name != null ? editContractors.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELORT
        internal Contractor Delete(string id)
        {
            Contractor original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}