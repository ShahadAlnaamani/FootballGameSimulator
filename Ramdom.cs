using System;

namespace FootBallGameSimulator
{
    //Generates random numbers 
	public static class RandomInt
	{
        //Method overloading used so that we can carry out the same function (getting random number) in a different way so that all parts of the system can use the same class 
        
        
        public  static int GetRandom() 
        {
            Random random = new Random();
            int randomNumber = random.Next();
            Console.WriteLine("Random number " + randomNumber);
            return randomNumber;
        }

        
        public static int GetRandom(int Min, int Max) //This override will be used to get a random Skill level 
        {
            Random random = new Random();
            int randomInRange = random.Next(Min, Max);

            
            Console.WriteLine("Random number between 1 and 99: " + randomInRange);
            return randomInRange;
        }
    }
}
