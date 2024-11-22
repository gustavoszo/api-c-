using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CineController : ControllerBase
    {

        private MovieContext _movieContext;
        private IMapper _iMapper;

        public CineController(MovieContext movieContext, IMapper iMapper)
        {
            _movieContext = movieContext;
            _iMapper = iMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCineDto createCineDto)
        {
            Address address = _iMapper.Map<Address>(createCineDto.Address);
            _movieContext.Addresses.Add(address);

            _movieContext.SaveChanges();

            Cine cine = _iMapper.Map<Cine>(createCineDto);

            cine.AddressId = address.Id;

            _movieContext.Cines.Add(cine);

            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cine.Id }, cine);
        }

        [HttpGet]
        public IEnumerable<ResponseCineDto> GetAll([FromQuery] int page)
        {
            if (page < 0) page = 0;
            return _iMapper.Map<List<ResponseCineDto>>(_movieContext.Cines.Skip(5 * page).Take(5).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cine = _movieContext.Cines.FirstOrDefault(cine => cine.Id == id);
            if (cine == null) return NotFound();
            return Ok(_iMapper.Map<ResponseCineDto>(cine));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCineDto updateCineDto)
        {
            var cine = _movieContext.Cines.FirstOrDefault(cine => cine.Id == id);
            if (cine == null) return NotFound($"Cine com id '{id} não encontrado'");
            _iMapper.Map(updateCineDto, cine);
            _movieContext.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateSessionDto> patch)
        {
            var session = _movieContext.Sessions.FirstOrDefault(c => c.Id == id);
            if (session == null) return NotFound($"Session com id '{id} não encontrado'");

            var sessionDto = _iMapper.Map<UpdateSessionDto>(session);

            patch.ApplyTo(sessionDto);

            if (!TryValidateModel(sessionDto))
            {
                return BadRequest(ModelState);
            }

            _iMapper.Map(sessionDto, session);

            _movieContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cine = _movieContext.Cines.FirstOrDefault(cine => cine.Id == id);
            if (cine == null) return NotFound($"Cine com id '{id} não encontrado'");

            Address address = cine.Address;

            _movieContext.Addresses.Remove(address);
            _movieContext.Cines.Remove(cine);

            _movieContext.SaveChanges();
            return NoContent();
        }

    }
}
