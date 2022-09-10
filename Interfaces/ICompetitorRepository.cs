namespace JTS.Interfaces;

public interface ICompetitorRepository<Competitor>
{
    Task<List<Competitor>> GetAll();
    Task<Competitor?> GetById(int id);
    Task<int> Create(Competitor competitor);
    Task<bool> Update(Competitor competitor);
    //Task<IActionResult> Delete(int id);
    Task<bool> DeleteMany(List<int> ids);
}