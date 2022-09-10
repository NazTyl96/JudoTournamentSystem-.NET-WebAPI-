using JTS.Models;
using JTS.Data;
using JTS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JTS.Repositories;

public class CompetitorRepository : ICompetitorRepository<Competitor>
{
    private readonly Context _context;

    public CompetitorRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Competitor>> GetAll()
    {
        return await _context.Competitors.AsNoTracking().ToListAsync();
    }

    public async Task<Competitor?> GetById(int id)
    {
        return await _context.Competitors.AsNoTracking()
                                         .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<int> Create(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();

        return competitor.Id;
    }

    public async Task<bool> Update(Competitor competitor)
    {
        Competitor? curCompetitor = await GetById(competitor.Id);
        if(curCompetitor is null)
            return false;
    
        _context.Update(competitor);
        await _context.SaveChangesAsync();        
    
        return true;
    }

    public async Task<bool> DeleteMany(List<int> ids)
    {
        List<Competitor> competitorsToDelete = await _context.Competitors
                                                             .Where(t => ids.Contains(t.Id))
                                                             .ToListAsync();
        if(competitorsToDelete.Any())
        {
            _context.Competitors.RemoveRange(competitorsToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        else
            return false;
    }
}