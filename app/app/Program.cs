using app;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        FootballSchoolSystem schoolSystem = new FootballSchoolSystem();

        while (true)
        {
            Console.WriteLine("1. Add School");
            Console.WriteLine("2. Add Team");
            Console.WriteLine("3. Register Student");
            Console.WriteLine("4. Organize Competition");
            Console.WriteLine("5. Schedule Match");
            Console.WriteLine("6. Display Information");
            Console.WriteLine("7. Display Matches");
            Console.WriteLine("8. Exit");

            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter school name: ");
                    string schoolName = Console.ReadLine();
                    schoolSystem.AddSchool(schoolName);
                    break;

                case "2":
                    Console.Write("Enter team name: ");
                    string teamName = Console.ReadLine();
                    schoolSystem.AddTeam(teamName);
                    break;

                case "3":
                    Console.Write("Enter student name: ");
                    string studentName = Console.ReadLine();
                    Console.Write("Enter student age: ");
                    int studentAge = int.Parse(Console.ReadLine());
                    Console.Write("Enter team name: ");
                    string studentTeam = Console.ReadLine();

                    schoolSystem.RegisterStudent(studentName, studentAge, studentTeam);
                    break;

                case "4":
                    Console.Write("Enter competition name: ");
                    string competitionName = Console.ReadLine();
                    schoolSystem.OrganizeCompetition(competitionName);
                    break;

                case "5":
                    Console.Write("Enter first team name: ");
                    string team1Name = Console.ReadLine();
                    Console.Write("Enter second team name: ");
                    string team2Name = Console.ReadLine();
                    Console.Write("Enter match date (yyyy-MM-dd): ");
                    DateTime matchDate = DateTime.Parse(Console.ReadLine());

                    schoolSystem.ScheduleMatch(team1Name, team2Name, matchDate);
                    break;

                case "6":
                    schoolSystem.DisplayInformation();
                    break;

                case "7":
                    schoolSystem.DisplayMatches();
                    break;

                case "8":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}









