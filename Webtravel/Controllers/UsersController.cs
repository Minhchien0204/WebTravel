using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Webtravel.Models;
using Webtravel.Service;

namespace Webtravel.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        /*private readonly WebtravelContext _context;*/

        private IUserService _userService;
        public UsersController(
            WebtravelContext context,
            IUserService userService
            )
        {
           /* _context = context;*/
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Authenticate authenticate)
        {
            var user = _userService.Authenticate(authenticate.UserNames, authenticate.Passwords);

            if (user == null)
                return BadRequest(new { message = " username hoac password khong chinh xac!" });

            return Ok(user);
        }
        [Authorize(Roles = Role.Admin)]
        // GET: api/Users
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // chi co admin moi co the xem ho so cua ng khac
            var currentUserId = int.Parse(User.Identity.Name);
            if ( id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        /*public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

       
        

        // DELETE: api/Users/5
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
       public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
       /* private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.IdUser == id);
        }*/
    }
}
