using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    class FootballSchoolSystem
    {
        private List<School> schools;
        private List<Team> teams;
        private List<Student> students;
        private List<Competition> competitions;
        private List<Match> matches;

        private const string DatabaseFile = "football_database.txt";

        public FootballSchoolSystem()
        {
            schools = new List<School>();
            teams = new List<Team>();
            students = new List<Student>();
            competitions = new List<Competition>();
            matches = new List<Match>();

            LoadDataFromDatabase();
        }

        public void AddSchool(string name)
        {
            School school = new School(name);
            schools.Add(school);
            SaveDataToDatabase();
        }

        public void AddTeam(string name)
        {
            Team team = new Team(name);
            teams.Add(team);
            SaveDataToDatabase();
        }

        public void RegisterStudent(string name, int age, string teamName)
        {
            Team team = teams.Find(t => t.Name == teamName);
            if (team != null)
            {
                Student student = new Student(name, age, team);
                students.Add(student);
                SaveDataToDatabase();
            }
            else
            {
                Console.WriteLine("Team not found.");
            }
        }

        public void OrganizeCompetition(string name)
        {
            Competition competition = new Competition(name);
            competitions.Add(competition);
            SaveDataToDatabase();
        }

        public void DisplayInformation()
        {
            Console.WriteLine("Schools:");
            foreach (var school in schools)
            {
                Console.WriteLine($"- {school.Name}");
            }

            Console.WriteLine("\nTeams:");
            foreach (var team in teams)
            {
                Console.WriteLine($"- {team.Name}");
            }

            Console.WriteLine("\nStudents:");
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.Name}, Age: {student.Age}, Team: {student.Team.Name}");
            }

            Console.WriteLine("\nCompetitions:");
            foreach (var competition in competitions)
            {
                Console.WriteLine($"- {competition.Name}");
            }
        }

        private void LoadDataFromDatabase()
        {
            if (File.Exists(DatabaseFile))
            {
                string[] lines = File.ReadAllLines(DatabaseFile);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    string type = parts[0];

                    switch (type)
                    {
                        case "School":
                            schools.Add(new School(parts[1]));
                            break;

                        case "Team":
                            teams.Add(new Team(parts[1]));
                            break;

                        case "Student":
                            Team studentTeam = teams.Find(t => t.Name == parts[3]);
                            students.Add(new Student(parts[1], int.Parse(parts[2]), studentTeam));
                            break;

                        case "Competition":
                            competitions.Add(new Competition(parts[1]));
                            break;
                    }
                }
            }
        }

        private void SaveDataToDatabase()
        {
            List<string> lines = new List<string>();

            foreach (var school in schools)
            {
                lines.Add($"School;{school.Name}");
            }

            foreach (var team in teams)
            {
                lines.Add($"Team;{team.Name}");
            }

            foreach (var student in students)
            {
                lines.Add($"Student;{student.Name};{student.Age};{student.Team.Name}");
            }

            foreach (var competition in competitions)
            {
                lines.Add($"Competition;{competition.Name}");
            }

            File.WriteAllLines(DatabaseFile, lines);
        }
        public void ScheduleMatch(string team1Name, string team2Name, DateTime date)
        {
            Team team1 = teams.Find(t => t.Name == team1Name);
            Team team2 = teams.Find(t => t.Name == team2Name);

            if (team1 != null && team2 != null)
            {
                Match match = new Match(team1, team2, date);
                matches.Add(match);
                SaveDataToDatabase();
            }
            else
            {
                Console.WriteLine("One or both teams not found.");
            }
        }

        public void DisplayMatches()
        {
            Console.WriteLine("Scheduled Matches:");
            foreach (var match in matches)
            {
                match.DisplayMatchDetails();
            }
        }
    }
}
