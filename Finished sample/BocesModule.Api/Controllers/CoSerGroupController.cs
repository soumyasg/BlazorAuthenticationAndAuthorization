using BocesModule.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BocesModule.Api.Controllers
{
    [Route("api/cosergroups")]
    [ApiController]
    public class CoSerGroupController : Controller
    {
        private readonly ICoSerGroupRepository _coSerGroupRepository;

        public CoSerGroupController(ICoSerGroupRepository coSerGroupRepository)
        {
            _coSerGroupRepository = coSerGroupRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        [Authorize(Policy = BocesModule.Shared.Policies.CanManageCoSerGroups)]
        public IActionResult GetCoSerGroups()
        {
            return Ok(_coSerGroupRepository.GetAllCoSerGroups());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCoSerGroupById(int id)
        {
            return Ok(_coSerGroupRepository.GetCoSerGroupById(id));
        }
    }
}
