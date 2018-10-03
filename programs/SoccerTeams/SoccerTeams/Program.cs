using System;

namespace SoccerTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minPlayers = 9;
            const int maxPlayers = 15;

            int players;
            int teamSize;
            int numTeams;
            int leftOver;

            teamSize = 0;
            while (teamSize < minPlayers || teamSize > maxPlayers)
            {
                //Get number of players per team
                Console.Write("Enter Players per team (between 9-15): ");
                teamSize = int.Parse(Console.ReadLine());
            }

            // Get the number of available players
            players = 0;
            while (players < 1)
            {
                Console.Write("Enter Number of available players: ");
                players = int.Parse(Console.ReadLine());
            }

            // Calculate the number of teams
            numTeams = players / teamSize;
            // Calculate the number of left over players
            leftOver = players % teamSize;

            // display results (teams, left over)
            Console.WriteLine($"\nNumber of Teams: {numTeams} \tNumber of Left Over Players: {leftOver}");
        }
    }
}
