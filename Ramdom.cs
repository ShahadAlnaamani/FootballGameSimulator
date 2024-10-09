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
            return randomNumber;
        }

        
        public static int GetRandom(int Min, int Max) //This override will be used to get a random Skill level and for when generating players for teams 
        {
            Random random = new Random();
            int randomInRange = random.Next(Min, Max);
            return randomInRange;
        }
    }
}
