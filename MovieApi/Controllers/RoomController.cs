using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoomController : ControllerBase
    {

        private MovieContext _movieContext;
        private IMapper _iMapper;

        public RoomController(MovieContext movieContext, IMapper iMapper)
        {
            _movieContext = movieContext;
            _iMapper = iMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRoomDto createRoomDto)
        {
            
            Cine cine = _movieContext.Cines.FirstOrDefault(c => c.Id == createRoomDto.CineId);
            if (cine == null) return NotFound($"Cine id '{createRoomDto.CineId} não encontrado'");

            Room room = _iMapper.Map<Room>(createRoomDto);
            _movieContext.Rooms.Add(room);

            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Room room = _movieContext.Rooms.FirstOrDefault(m => m.Id == id);
            if (room == null) return NotFound($"Room com id '{id} não encontrado'");
            return Ok(room);
        }

    }
}
