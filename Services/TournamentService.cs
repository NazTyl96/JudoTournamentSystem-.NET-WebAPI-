using JTS.Models;
using JTS.Data;
using Microsoft.EntityFrameworkCore;

namespace JTS.Services;

public class TournamentService
{
    private readonly Context _context;

    public TournamentService(Context context)
    {
        _context = context;
    }

    //here will go methods with complex logic like creating fights for the tournament

}