using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SessionController : ControllerBase
    {
        private MovieContext _movieContext;
        private IMapper _iMapper;

        public SessionController(MovieContext movieContext, IMapper iMapper)
        {
            _movieContext = movieContext;
            _iMapper = iMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSessionDto createSessionDto)
        {
            Session session = _iMapper.Map<Session>(createSessionDto);
            Cine cine = _movieContext.Cines.FirstOrDefault(c => c.Id == createSessionDto.CineId);
            Room room = _movieContext.Rooms.FirstOrDefault(r => r.Id == createSessionDto.RoomId);
            Movie movie = _movieContext.Movies.FirstOrDefault(m => m.Id == createSessionDto.MovieId);

            if (cine == null) return NotFound($"Cine id '{createSessionDto.CineId}' não encontrado");
            if (room == null) return NotFound($"Room id '{createSessionDto.RoomId}' não encontrado");
            if (movie == null) return NotFound($"Movie id '{createSessionDto.MovieId}' não encontrado");

            bool valid = cine.Rooms.Any(cineRoom => cineRoom.Id == room.Id);
            if (!valid) return BadRequest($"A Room '{room.Id}' não pertence ao cinema '{cine.Id}'");

            try
            {
                session.Time = DateTime.Parse(createSessionDto.Time);
            } catch(FormatException ex)
            {
                return BadRequest("Time inválido");
            }

            _movieContext.Sessions.Add(session);
            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
        }

        [HttpGet]
        public IEnumerable<ResponseSessionDto> GetAll([FromQuery] int page)
        {
            if (page < 0) page = 0;
            return _iMapper.Map<List<ResponseSessionDto>>(_movieContext.Sessions.Skip(5 * page).Take(5).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var session = _movieContext.Sessions.FirstOrDefault(session => session.Id == id);
            if (session == null) return NotFound($"Session com id '{id}' não encontrado'");
            return Ok(_iMapper.Map<ResponseSessionDto>(session));
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateSessionDto> patch)
        {
            var session = _movieContext.Sessions.FirstOrDefault(c => c.Id == id);
            if (session == null) return NotFound($"Session com id '{id}' não encontrado'");

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
            var session = _movieContext.Sessions.FirstOrDefault(session => session.Id == id);
            if (session == null) return NotFound($"Session com id '{id}' não encontrado'");

            _movieContext.Sessions.Remove(session);

            _movieContext.SaveChanges();
            return NoContent();
        }

    }
}
