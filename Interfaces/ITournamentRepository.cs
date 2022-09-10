namespace JTS.Interfaces;

public interface ITournamentRepository<Tournament>
{
    Task<List<Tournament>> GetAll();
    Task<Tournament?> GetById(int id);
    Task<int> Create(Tournament tournament);
    Task<bool> Update(Tournament tournament);
    //Task<IActionResult> Delete(int id);
    Task<bool> DeleteMany(List<int> ids);
}