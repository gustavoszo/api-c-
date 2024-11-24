using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{

    private MovieContext _movieContext;
    private IMapper _iMapper;

    public MovieController(MovieContext movieContext, IMapper iMapper)
    {
        _movieContext = movieContext;   
        _iMapper = iMapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateMovieDto createMovieDto)
    {
        Movie movie = _iMapper.Map<Movie>(createMovieDto);
        _movieContext.Movies.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<ResponseMovieDto> GetAll([FromQuery] int page)
    {
        if (page < 0) page = 0;
        return _iMapper.Map<List<ResponseMovieDto>>(_movieContext.Movies.Skip(5*page).Take(5));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound($"Movie com id '{id}' não encontrado'");
        return Ok(_iMapper.Map<ResponseMovieDto>(movie));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound($"Movie com id '{id}' não encontrado'");
        _iMapper.Map(updateMovieDto, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound($"Movie com id '{id}' não encontrado'");

        _movieContext.Movies.Remove(movie);

        _movieContext.SaveChanges();
        return NoContent();
    }

}
