﻿using System.Globalization;
using System.Xml.Serialization;

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
                UserInterface.PrintFootballPlayers();
                Console.SetCursorPosition((Console.WindowWidth - Welcome.Length) / 2, Console.CursorTop);
                Console.WriteLine(Welcome);



                //Getting user input for the team names 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter name for Team 1: "); //write and not writeline so that user will input on the same line as text 
                string Team1 = Console.ReadLine();
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write("\nEnter name for Team 2: ");
                string Team2 = Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();


                //Creating instances of the Teams class 
                Team team1 = new Team(Team1);
                Team team2 = new Team(Team2);



                //Generating players
                TeamGenerator teamGenerator = new TeamGenerator();
                team1.GeneratePlayers();
                team2.GeneratePlayers();
                Console.WriteLine("Generating players for both teams...\n");



                //Displaying teams 
                PrintLines();
                string DisplayTeam = "T E A M S:";
                Console.SetCursorPosition((Console.WindowWidth - DisplayTeam.Length) / 2, Console.CursorTop);
                Console.WriteLine(DisplayTeam);
                Console.ForegroundColor = ConsoleColor.Yellow;
                team1.DisplayPlayers();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                team2.DisplayPlayers();
                Console.ResetColor();



                //Start Match 
                Half FirstHalf = new Half(team1, team2); //Creating the first half of the match 
                Half SecondHalf = new Half(team1, team2); //Creating the second half of the match, put these one after the other so score does not get affected when new instance created 

                Team Starting = FirstHalf.CoinToss();
                Team SecondStart = SecondHalf.CoinToss();

                PrintLines();
                string Half1Message = "F I R S T   H A L F:";
                Console.SetCursorPosition((Console.WindowWidth - Half1Message.Length) / 2, Console.CursorTop);
                Console.WriteLine(Half1Message);

                if (Starting == team1)
                { FirstHalf.Turn(Starting, team2, 1); }

                else
                { FirstHalf.Turn(Starting, team1, 1); }

                PrintLines();
                string HalfTimeMessage = "H A L F   T I M E:";
                Console.SetCursorPosition((Console.WindowWidth - HalfTimeMessage.Length) / 2, Console.CursorTop);
                Console.WriteLine(HalfTimeMessage);

                UserInterface.PrintGoal(); //ASCII art

                PrintLines();
                string Half2Message = "S E C O N D   H A L F:";
                Console.SetCursorPosition((Console.WindowWidth - Half2Message.Length) / 2, Console.CursorTop);
                Console.WriteLine(Half2Message);

                if (SecondStart == team1)
                { SecondHalf.Turn(SecondStart, team2, (FirstHalf.HalfMatch + 1)); } //Starting with half match so the number of the turn continues and does not restart from 1 

                else
                {
                    SecondHalf.Turn(SecondStart, team1, (FirstHalf.HalfMatch + 1));
                }



                //Display final score 
                PrintLines();
                string FinalScoreMessage = "F I N A L   S C O R E:";
                Console.SetCursorPosition((Console.WindowWidth - FinalScoreMessage.Length) / 2, Console.CursorTop);
                Console.WriteLine(FinalScoreMessage);
                UserInterface.PrintVictory(); //ASCII art
                string Score = $"{SecondHalf.Team1.TeamName}: {team1.TeamScore} | {SecondHalf.Team2.TeamName}: {team2.TeamScore}";
                Console.SetCursorPosition((Console.WindowWidth - Score.Length) / 2, Console.CursorTop);
                Console.WriteLine(Score);


                //Display result
                string Results = " ";
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (team2.TeamScore > team1.TeamScore)
                {
                    
                    Results = $"{team2.TeamName} are the winners!";
                    Console.SetCursorPosition((Console.WindowWidth - Results.Length) / 2, Console.CursorTop);
                    Console.WriteLine(Results);
                    Console.ResetColor();
                }

                else if (team2.TeamScore < team1.TeamScore)
                {
                     Results = $"{team1.TeamName} are the winners!";
                    Console.SetCursorPosition((Console.WindowWidth - Results.Length) / 2, Console.CursorTop);
                    Console.WriteLine(Results);
                    Console.ResetColor();
                }

                //Penalty option 
                else
                {
                    bool ChoiceMade;
                    do
                    {
                        ChoiceMade = true;

                        Console.WriteLine("It's a draw!");
                        Console.WriteLine("\n\nWould you like to go into penalties? \n1. Yes 2. No");
                        Console.Write("Enter: ");
                        int Choice = 0;

                        try
                        {
                            Choice = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine("<!>" + e.Message + "<!>");
                            ChoiceMade = false;
                        }

                        //Choosing to go ahead with penalties 
                        if (Choice == 1)
                        {
                            Penalties penalties = new Penalties(team1, team2);
                            penalties.PenaltyShots();
                        }

                    } while (ChoiceMade != true);
                }

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
                        PrintLines();
                        string PenaltyMessage = "P E N A L T I E S:";
                        Console.SetCursorPosition((Console.WindowWidth - PenaltyMessage.Length) / 2, Console.CursorTop);
                        Console.WriteLine(PenaltyMessage);
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

        public static void PrintLines()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \n");
        }
    }
}
