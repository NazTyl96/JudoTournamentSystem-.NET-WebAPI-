using JTS.Services;
using JTS.Interfaces;
using JTS.Models;
using Microsoft.AspNetCore.Mvc;

namespace JTS.Controllers;

[ApiController]
[Route("[controller]")]

public class CompetitorsController : ControllerBase
{
    private ICompetitorRepository<Competitor> _repository ;
    
    public CompetitorsController(ICompetitorRepository<Competitor> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<List<Competitor>> GetAll()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Competitor>> GetById(int id)
    {
        Competitor? curCompetitor = await _repository.GetById(id);

        if (curCompetitor == null)
            return NotFound();
        else
            return curCompetitor;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Competitor newCompetitor)
    {
        int id = await _repository.Create(newCompetitor);
        return CreatedAtAction(nameof(GetById), new {id = id}, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Competitor competitor)
    {
        if (id != competitor.Id)
            return BadRequest();

        bool result = await _repository.Update(competitor);
            
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