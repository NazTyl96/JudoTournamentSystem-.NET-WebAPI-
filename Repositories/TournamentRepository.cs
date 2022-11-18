using JTS.Models;
using JTS.Data;
using JTS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JTS.Repositories;

public class TournamentRepository : ITournamentRepository<Tournament>
{
    private readonly Context _context;

    public TournamentRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Tournament>> GetAll()
    {
        return await _context.Tournaments.AsNoTracking().ToListAsync();
    }

    public async Task<Tournament?> GetById(int id)
    {
        return await _context.Tournaments.Include(t => t.Competitors)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<int> Create(Tournament tournament)
    {
        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();

        return tournament.Id;
    }

    public async Task<bool> Update(Tournament tournament)
    {
        Tournament? curTournament = await GetById(tournament.Id);
        if(curTournament is null)
            return false;
    
        _context.Update(tournament);
        await _context.SaveChangesAsync();        
    
        return true;
    }

    public async Task<bool> DeleteMany(List<int> ids)
    {
        List<Tournament> tournamentsToDelete = await _context.Tournaments
                                                             .Where(t => ids.Contains(t.Id))
                                                             .ToListAsync();
        if(tournamentsToDelete.Any())
        {
            _context.Tournaments.RemoveRange(tournamentsToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        else
            return false;
    }

}