using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate.AspNetCore.Identity_Sample_API.DomainObject;
using System.Linq;

namespace NHibernate.AspNetCore.Identity_Sample_API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _manager;

        public UsersController(UserManager<ApplicationUser> session)
        {
            _manager = session;
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
    }
}