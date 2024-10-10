using System;
using System.Reflection.PortableExecutable;

namespace FootBallGameSimulator
{
	public static class UserInterface
	{
        public static void PrintFootballPlayers()
        {

            string multilineString = @"
                                                                 ___
                                             o__        o__     |   |\
                                            /|          /\      |   |X\
                                            / > o        <\     |   |XX\
                                    
            ";
           // Console.SetCursorPosition(Console.WindowWidth /2, Console.CursorTop);
            Console.WriteLine(multilineString);
        }

        public static void PrintPrize()
        {

            string multilineString = @"
             
                                    
            ";
            Console.WriteLine(multilineString);
        }

        public static void PrintGoal()
        {

            string multilineString = @"
             
                               +---------------------------+   
                              |\                          |\  
                              | \    @ \_    /            | \
                              |  \  /  \_o--<_/           | o\
______________________________|___|/______________________|-|\|__________________
         /                   /    /              _ o     / /|_                /
        /                   /  _o'------------- / / \ ----/                  /
       /                   /  /|_                /\    /                    /
      /                   /_ /\ _______________ / / __/                    /
     /                      / /                                           /
    /                                                                    /
   /                                                                    /
  /                                                                    /
 /____________________________________________________________________/                  
            ";
            Console.WriteLine(multilineString);
        }

        public static void PrintVictory()
        {

            string multilineString = @"
             
                                                           ____
                                                          ( () )
                                                           \  /
                                                            ||
                                                            ||
                                                           [__]
                                                          /)  (\
                                                         (( () ))
                                                          \\__//
                                                           `..'
                                                            ||
                                                            ||    
                                                           //\\__
                                                        _ ((  `--'
                                                       (_) \)
                                                   """"""""""""""""""""""""""""""""""                       
            ";
            Console.WriteLine(multilineString);
        }
    }
}
