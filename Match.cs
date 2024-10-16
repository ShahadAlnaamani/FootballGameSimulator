﻿using System;

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

		public void AddScore(Team team)
		{
			if (team == Team1)
			{
				Team1Score++; //Doccuments the half match score 
				team.AddScore(); //Doccuments the total score 
			}

			else if (team == Team2)
			{
				Team2Score++; //Doccuments the half match score 
                team.AddScore(); //Doccuments the total score 
			}

			else
			{
				Console.WriteLine("<!>Error occured when trying to add goal for team " + team.TeamName + "<!>");    
			}
		}
	}
}