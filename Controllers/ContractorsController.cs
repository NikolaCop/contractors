using System;
using System.Collections.Generic;
using contractors.Models;
using contractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _service;


        public ContractorsController(ContractorsService service)
        {
            _service = service;
        }



        [HttpGet] //Get
        public ActionResult<IEnumerable<Contractor>> Get()
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

        [HttpGet("{contractorsId}")] //Get By ID
        public ActionResult<Contractor> GetById(string contractorsId)
        {
            try
            {
                return Ok(_service.GetById(contractorsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{contractorsId}")] //EDIT
        public ActionResult<Contractor> editContractors(string contractorId, Contractor editContractors)
        {
            try
            {
                editContractors.contractorId = contractorId;
                return Ok(_service.Edit(editContractors));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Contractor> Create([FromBody] Contractor newContractors)
        {
            try
            {
                return Ok(_service.Create(newContractors));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteContractors(string id)
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