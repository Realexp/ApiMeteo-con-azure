using ApiMeteo.Data;
using ApiMeteo.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WatherDbContext _ctx;
        private readonly Mapper _mapper;
        private Random _random = new Random();

        public UserController(WatherDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_ctx.Users.ToList().ConvertAll(_mapper.mapDataToDTO));
        }
        [HttpGet("{Email}")]
        public IActionResult getOne(string Email) {
            var u = _ctx.Users.SingleOrDefault(s => s.EmailUser.Equals(Email));
            if (u == null)
                return BadRequest("User not found");
            return Ok(u);
        }

        [HttpGet("{Email}/prevision")]
        public IActionResult getPrevision(string Email)
        {
            var p = _ctx.Preferences.Include(s => s.User).Where(s => s.EmailUser.Equals(Email)).Select(s => new
            {
                City = s.City.NameCity,
                Temp = _random.Next(-5, 41),
            });

            if (p == null)
                return BadRequest();

            return Ok(p);
        }

        [HttpPost]
        public IActionResult post([FromBody] UserDTO user) { 
            User addUser = _mapper.mapDTOToData(user);
            _ctx.Users.Add(addUser);
            _ctx.SaveChanges();
            return Created("", addUser);
        }

        [HttpPut]
        public IActionResult put([FromBody] UserDTO user) {
            var s = _ctx.Users.Find(user.EmailUser);
            s = _mapper.mapDTOToData(user);
            return _ctx.SaveChanges() == 1
                   ? Ok(_mapper.mapDTOToData(user))
                   : BadRequest();
        }

        
    }
}
