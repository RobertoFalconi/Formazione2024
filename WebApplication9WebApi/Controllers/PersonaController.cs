using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9WebApi.Handlers.QueryHandlers;
using WebApplication9WebApi.Models.DB;

namespace WebApplication9WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    private readonly FormazioneDbContext _context;

    private readonly IMediator _mediator;

    public PersonaController(FormazioneDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    // GET: api/Persona
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
    {
        var result = await _mediator.Send(new GetPersonaConDapperQuery());
        return result;
    }

    // GET: api/Persona/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona>> GetPersona(int id)
    {
        var result = await _mediator.Send(new GetPersonaByIdConDapperQuery(id));
        return result;
    }

    // PUT: api/Persona/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersona(int id, Persona persona)
    {
        if (id != persona.Id)
        {
            return BadRequest();
        }

        _context.Entry(persona).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Persona
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Persona>> PostPersona(Persona persona)
    {
        _context.Persona.Add(persona);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
    }

    // DELETE: api/Persona/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(int id)
    {
        var persona = await _context.Persona.FindAsync(id);
        if (persona == null)
        {
            return NotFound();
        }

        _context.Persona.Remove(persona);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonaExists(int id)
    {
        return _context.Persona.Any(e => e.Id == id);
    }
}
