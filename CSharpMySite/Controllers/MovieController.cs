using CSharpMySite.Data;
using CSharpMySite.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CSharpMySite.Controllers;

[ApiController]
[EnableCors("AllowAll")]
[Route("api/[controller]")] //Surfa till /api/product
public class MovieController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MovieController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]  // api/movie
    public IEnumerable<MovieDTO> Get()
    {
        return _context.Movies.Select(e => new MovieDTO
        {
            Id = e.Id,
            GenreName = e.Genre.Name,
            Title = e.Title,
            Director = e.Director,
            Year = e.Year,
        });
    }

    [HttpGet]  // api/movie/12
    [Route("{id}")]
    public IActionResult GetSingle(int id)
    {
        var product = _context.Movies.Where(e=>e.Id == id).Select(e => new MovieDTO
        {
            Id = e.Id,
            GenreName = e.Genre.Name,
            Title = e.Title,
            Director = e.Director,
            Year = e.Year,
        }).FirstOrDefault();
        if (product == null)
            return NotFound();
        return Ok(product);
    }


}