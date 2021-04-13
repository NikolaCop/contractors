using System.Threading.Tasks;
using contractors.Models;
using contractors.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsJobsController : ControllerBase
    {
        private readonly ContractorsJobsService _service;

        public ContractorsJobsController(ContractorsJobsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<WishListProduct>> CreateAsync([FromBody] WishListProduct newWLP)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newWLP.CreatorId = userInfo.Id;
                return Ok(_service.Create(newWLP));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("deleted");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}