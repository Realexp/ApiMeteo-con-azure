using ApiMeteo.Data;
using ApiMeteo.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WatherDbContext _ctx;
        private readonly Mapper _mapper;
        private Random _random = new Random();
        private const string APIKEY = "53c1c64150dac444c40e54c4f1f7c78e";
        //private string url = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, APIKEY);
        public WebClient web = new WebClient();

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
                Temp = "NoElaborated",
            });

            if (p == null)
                return BadRequest();

            return Ok(p);
        }
        [HttpGet("{Email}/openWather")]
        public IActionResult getPrevision2(string Email)
        {
            try
            {
                var CityTemp = getPrevision(Email);
                if (CityTemp == null)
                    return BadRequest();


                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
