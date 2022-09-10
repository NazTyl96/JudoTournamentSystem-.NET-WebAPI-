using JTS.Services;
using JTS.Interfaces;
using JTS.Models;
using Microsoft.AspNetCore.Mvc;

namespace JTS.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentsController : ControllerBase
{
    private ITournamentRepository<Tournament> _repository ;
    private TournamentService _service;
    
    public TournamentsController(TournamentService service, ITournamentRepository<Tournament> repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpGet]
    public async Task<List<Tournament>> GetAll()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tournament>> GetById(int id)
    {
        Tournament? curTournament = await _repository.GetById(id);

        if (curTournament == null)
            return NotFound();
        else
            return curTournament;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tournament newTournament)
    {
        int id = await _repository.Create(newTournament);
        return CreatedAtAction(nameof(GetById), new {id = id}, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Tournament tournament)
    {
        if (id != tournament.Id)
            return BadRequest();

        bool result = await _repository.Update(tournament);
            
        if(result)
            return NoContent();
        else
            return NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMany(List<int> ids)
    {
        bool result = await _repository.DeleteMany(ids);

        if (result)
            return Ok();
        else
            return NotFound();
    }
}