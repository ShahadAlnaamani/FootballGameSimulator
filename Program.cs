﻿namespace FootBallGameSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Alligning the tital of the page to the middle of the console 
            Console.WriteLine("\n");
            string Header = "F O O T B A L L   G A M E   S I M U L A T O R";
            Console.SetCursorPosition((Console.WindowWidth - Header.Length) /2, Console.CursorTop); 
            Console.WriteLine(Header);
            Console.WriteLine("\n");
            string Welcome = "Welcome to the Codeline playoffs (keep an eye out and see who you can spot from the team!)";
            Console.SetCursorPosition((Console.WindowWidth - Welcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(Welcome);

            //Getting user input for the team names 
            Console.Write("\nEnter name for Team 1: "); //write and not writeline so that user will input on the same line as text 
            string Team1 = Console.ReadLine();
            Console.Write("\nEnter name for Team 2: ");
            string Team2 = Console.ReadLine();
            Console.WriteLine();

            //Creating instances of the Teams class 
            Team team1 = new Team (Team1);
            Team team2 = new Team(Team2);

            //Generating players
            TeamGenerator teamGenerator = new TeamGenerator();
            team1.GeneratePlayers();
            team2.GeneratePlayers();
            Console.WriteLine("Generating players for both teams...\n");

            //Displaying teams 
            team1.DisplayPlayers();
            Console.WriteLine();
            team2.DisplayPlayers();

            //Start Match 
            Console.WriteLine("\n\n\n--- First Half ---");
            Half FirstHalf = new Half(team1, team2); //Creating the first half of the match 

             Team Starting = FirstHalf.CoinToss();

            if (Starting == team1) 
            { FirstHalf.Turn(Starting, team2, 1); }

            else
            { FirstHalf.Turn(Starting, team1, 1); }
            

            Console.WriteLine("\n\n\n--- Second Half ---");
            Half SecondHalf = new Half(team1, team2); //Creating the second half of the match 
            
            Team SecondStart = SecondHalf.CoinToss();

            if (SecondStart == team1)
            { SecondHalf.Turn(SecondStart, team2, (FirstHalf.HalfMatch+1)); } //Starting with half match so the number of the turn continues and does not restart from 1 

            else
            { SecondHalf.Turn(SecondStart, team1, (FirstHalf.HalfMatch+1)); }

        }
    }
}
