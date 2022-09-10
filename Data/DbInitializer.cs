using JTS.Models;

namespace JTS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {

            if (!context.Tournaments.Any())
            {
                Tournament firstTournament = new Tournament
                {

                    Name = "First Tournament", 
                    Date = DateTime.Today,
                };

                context.Tournaments.Add(firstTournament);
                context.SaveChanges();
            }

            if (!context.Competitors.Any())
            {
                Competitor firstCompetitor = new Competitor
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Sex = 'm',
                    DateOfBirth = new DateTime(1996, 1, 17),
                    ExactWeight = 81.8m,
                    Club = "Shirai Ryu"
                }; 

                Competitor secondCompetitor = new Competitor
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Sex = 'f',
                    DateOfBirth = new DateTime(1996, 1, 17),
                    ExactWeight = 59.8m,
                    Club = "Lin Kuei"
                }; 

                context.Competitors.Add(firstCompetitor);
                context.Competitors.Add(secondCompetitor);
                context.SaveChanges();
            }

        }
    }
}