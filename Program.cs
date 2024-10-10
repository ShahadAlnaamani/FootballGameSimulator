namespace FootBallGameSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Running = true;

            do
            {
                Console.Clear();
                //Alligning the tital of the page to the middle of the console 
                Console.WriteLine("\n");
                string Header = "F O O T B A L L   G A M E   S I M U L A T O R";
                Console.SetCursorPosition((Console.WindowWidth - Header.Length) / 2, Console.CursorTop);
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
                Team team1 = new Team(Team1);
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

                Half FirstHalf = new Half(team1, team2); //Creating the first half of the match 
                Half SecondHalf = new Half(team1, team2); //Creating the second half of the match, put these one after the other so score does not get affected when new instance created 

                Team Starting = FirstHalf.CoinToss();
                Team SecondStart = SecondHalf.CoinToss();

                Console.WriteLine("\n\n\n--- First Half ---");

                if (Starting == team1)
                { FirstHalf.Turn(Starting, team2, 1); }

                else
                { FirstHalf.Turn(Starting, team1, 1); }


                Console.WriteLine("\n\n\n--- Second Half ---");

                Console.WriteLine("Current total points 1 , 2 " + FirstHalf.Team1Score + FirstHalf.Team2Score);
                if (SecondStart == team1)
                { SecondHalf.Turn(SecondStart, team2, (FirstHalf.HalfMatch + 1)); } //Starting with half match so the number of the turn continues and does not restart from 1 

                else
                {
                    SecondHalf.Turn(SecondStart, team1, (FirstHalf.HalfMatch + 1));
                }


                //Display final score 
                Console.WriteLine("\n\nFINAL SCORE:");
                Console.WriteLine($"{SecondHalf.Team1.TeamName}: {team1.TeamScore} | {SecondHalf.Team2.TeamName}: {team2.TeamScore}");

                //Display result
                if (SecondHalf.Team2Score > SecondHalf.Team1Score)
                {
                    Console.WriteLine($"{team2.TeamName} are the winners!");
                }

                else if (SecondHalf.Team2Score < SecondHalf.Team1Score)
                { Console.WriteLine($"{team1.TeamName} are the winners!"); }

                else { Console.WriteLine("It's a draw!"); }


                

                int Continue = 0;
                bool ValidChoice;
                do
                {
                    ValidChoice = false;
                    Console.WriteLine("\n\nWould you like to play again?");
                    Console.WriteLine("1. Yes , 2. No");
                    Console.Write("Enter: ");
                    try
                    {
                        Continue = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("<!>" + e.Message + "<!>");
                    }

                    if (Continue == 1)
                    {
                        TeamGenerator.AddTeam(); //Regenerating Player pool as players were deleted from it when they are placed in teams 
                        ValidChoice = true;
                    }

                    else if (Continue == 2)
                    {
                        Console.WriteLine("\n\nThank you for joining in the Codeline championships! \nByeeeee!!!");
                        ValidChoice = true;
                        Running = false;
                    }

                    else //In case a int is inputted but is not one of the options
                    {
                        Console.WriteLine("<!>Please input a valid option<!>");
                    }
                } while (ValidChoice != true);

            } while (Running != false);
        }
    }
}
