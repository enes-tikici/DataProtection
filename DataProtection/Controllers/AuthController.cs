using DataProtection.Context;
using DataProtection.DataProtection;
using DataProtection.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly DataProtectionDbContext _context;
        private readonly IDataProtection _protector;
        public AuthController(DataProtectionDbContext context, IDataProtection protector)
        {
            _context = context;
            _protector = protector;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserEntity entity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == entity.Email);

            if (existingUser != null)
            {
                return BadRequest("bu email zaten kayıtlı");
            }

            var user = new UserEntity
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = _protector.Protected.(entity.Password),
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("Kayıt başarılı");
        }

    }
}
