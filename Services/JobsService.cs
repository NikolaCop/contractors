using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Repositories;

namespace contractors.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<Job> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Job GetById(string id)
        {
            Job jobs = _repo.Get(id);
            if (jobs == null)
            {
                throw new Exception("invalid id");
            }
            return jobs;
        }


        //CREATE/POST
        internal Job Create(Job newJobs)
        {
            return _repo.Create(newJobs);
        }

        //EDIT/PUT
        internal Job Edit(Job editJobs)
        {
            Job original = GetById(editJobs.jobId);

            original.Title = editJobs.Title != null ? editJobs.Title : original.Title;
            original.Description = editJobs.Description != null ? editJobs.Description : original.Description;

            return _repo.Edit(original);
        }

        //DELORT
        internal Job Delete(string id)
        {
            Job original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}