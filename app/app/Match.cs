using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    class Match
    {
        public Team Team1 { get; }
        public Team Team2 { get; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public DateTime Date { get; set; }

        public Match(Team team1, Team team2, DateTime date)
        {
            Team1 = team1;
            Team2 = team2;
            Date = date;
        }

        public void DisplayMatchDetails()
        {
            Console.WriteLine($"Match between {Team1.Name} and {Team2.Name}");
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Score: {Team1.Name} {ScoreTeam1} - {ScoreTeam2} {Team2.Name}");
            Console.WriteLine();
        }
    }

}
