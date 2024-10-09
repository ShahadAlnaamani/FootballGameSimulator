namespace FootBallGameSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Alligning the tital of the page to the middle of the console 
            string Welcome = "F O O T B A L L   G A M E   S I M U L A T O R";
            Console.SetCursorPosition((Console.WindowWidth - Welcome.Length) /2, Console.CursorTop); 
            Console.WriteLine(Welcome);

            //Getting user input for the team names 
            Console.Write("\nEnter name for Team 1: "); //write and not writeline so that user will input on the same line as text 
            string Team1 = Console.ReadLine();
            Console.Write("\nEnter name for Team 2: ");
            string Team2 = Console.ReadLine();

            RandomInt.GetRandom();
            //Call class and then generate the teams -> generation should be done in team class 
        }
    }
}
