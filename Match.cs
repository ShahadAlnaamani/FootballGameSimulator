using System;

namespace FootBallGameSimulator
{
	public abstract class Match
	{
		//Attributes
		public int TotalTurns { get; private set; }
		public Team Team1 { get; private set; }
		public Team Team2 { get; private set; }
		public int Team1Score { get; private set; }
		public int Team2Score { get; private set; }

		//Constructor
		public Match(Team team1, Team team2)
		{
			TotalTurns = 10; // Assuming that the length of one match is 10 turns 
			Team1 = team1;
			Team2 = team2;
			Team1Score = 0;
            Team2Score = 0;
        }

		//Methods
		public Team CoinToss() //Cointoss randomly chooses who will start as the attacker 
		{
			Team StartingTeam;
			int Random = RandomInt.GetRandom();

			if (Random == 1)
			{
				StartingTeam = Team1;
			}

			else 
			{
				StartingTeam = Team2;
			}
			return StartingTeam;
		}

		public int AddScore(Team team)
		{
			if (team == Team1)
			{
				Team1Score++;
				return 1;
			}

			else if (team == Team2)
			{
				Team2Score++;
				return 1;
			}

			else
			{
				return 0; //Means an issue happened and will print an error message from program
			}
		}
	}
}