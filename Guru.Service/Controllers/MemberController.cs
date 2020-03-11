using Guru.Core.Entities;
using Guru.Service.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guru.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly MemberRepo _repo;

        public MemberController(ILogger<MemberController> logger, MemberContainer container)
        {
            _logger = logger;
            _repo = new MemberRepo(container);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var single = _repo.Single(id);
            return single != null ? Ok(single) : BadRequest() as IActionResult;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.Get());
        }
        
        [HttpPost]
        public IActionResult AddOrUpdate([FromBody] Member member)
        {
            return _repo.AddOrUpdate(member) ? Ok() : BadRequest() as IActionResult;
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _repo.Delete(id) ? Ok() : BadRequest() as IActionResult;
        }
    }
}
