using ApiMeteo.Data;
using ApiMeteo.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly WatherDbContext _ctx;
        private readonly Mapper _mapper;

        public CityController(WatherDbContext dbContext, Mapper mappers)
        {
            _ctx = dbContext;
            _mapper = mappers;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_ctx.Cities.ToList().ConvertAll(_mapper.mapDataToDTO));
        }

        [HttpGet("{ID}")]
        public IActionResult getOne(int ID)
        {
            var u = _ctx.Cities.SingleOrDefault(s => s.IDCity == ID);
            if (u == null)
                return BadRequest();
            return Ok(u);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CityDTO city)
        {
            City c = _mapper.mapDTOToData(city);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] CityDTO city) {
            var c = _ctx.Cities.Find(city.IDCity);

            if (c == null)
                return BadRequest("City not found");
            c = _mapper.mapDTOToData(city);
            return _ctx.SaveChanges() == 1
                   ? Ok(_mapper.mapDTOToData(city))
                   : BadRequest();
        }
    }
}
