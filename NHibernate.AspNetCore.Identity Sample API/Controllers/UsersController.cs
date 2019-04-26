using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate.AspNetCore.Identity_Sample_API.DomainObject;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using NHibernate.AspNetCore.Identity_Sample_API.Models;

namespace NHibernate.AspNetCore.Identity_Sample_API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _manager;

        public UsersController(UserManager<ApplicationUser> session, IMapper mapper)
        {
            _manager = session;
            _mapper = mapper;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _manager = null;
        }

        [HttpGet("")]
        public ActionResult GetAll()
        {
            var users = _manager.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserModel userModel)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(userModel);
            var identityResult = Task.Run(async () => await _manager.CreateAsync(applicationUser,
                    userModel.password))
                .Result;
            return identityResult.Succeeded
                ? Ok(Task.Run(async () => await _manager.FindByEmailAsync(userModel.email))
                    .Result)
                : GetErrorResult(identityResult);
        }

        private IActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (result.Succeeded)
                return null;

            if (result.Errors == null)
                return BadRequest();
            var errors = result.Errors.Select(error => error.Description)
                .ToList();
            return BadRequest(errors);
        }
    }
}