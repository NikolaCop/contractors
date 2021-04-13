using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;


        public JobsController(JobsService service)
        {
            _service = service;
        }



        [HttpGet] //Get
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{jobsId}")] //Get By ID
        public ActionResult<Job> GetById(string jobsId)
        {
            try
            {
                return Ok(_service.GetById(jobsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{jobsId}")] //EDIT
        public ActionResult<Job> editJobs(string jobId, Job editJobs)
        {
            try
            {
                editJobs.jobId = jobId;
                return Ok(_service.Edit(editJobs));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Job> Create([FromBody] Job newJobs)
        {
            try
            {
                return Ok(_service.Create(newJobs));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteJobs(string id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}