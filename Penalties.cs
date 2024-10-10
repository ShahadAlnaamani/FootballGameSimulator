using System.ComponentModel.Design;

namespace FootBallGameSimulator
{

	public class Penalties : Match
	{
		//Attributes 
		public int PenaltyKicks { get; private set; }
        public int T1PenGoals { get; private set; }
        public int T2PenGoals { get; private set; }

		//Constructor
        public Penalties(Team team1, Team team2) : base (team1, team2)
		{
            PenaltyKicks = 10; //Number of tries to score - 5 each 
		}

		//Methods 
		public void PenaltyShots() //Actual proccess of penalties
		{
            Team AttackingTeam = CoinToss();
			Team DefendingTeam;

            for (int i = 0; i < PenaltyKicks; i++)
			{
				//Penalties will be one Attacker [Forward and Mid] against the Goalie of the opposing team 
                Console.Write($"\nShot {i}: {AttackingTeam.TeamName} shooting... ");
                Player Attacker = GetAttacker(AttackingTeam);

				//Identifying which team is which
				if (AttackingTeam == Team1)
				{
					DefendingTeam = Team2;
				}

				else
				{
                    DefendingTeam = Team1;
                }

                Player GoalKeeper = DefendingTeam.Players[i]; //Assigning random player as a place holder will be changed below

                //Getting the goalie of the defending team
                for (int j = 0; j < DefendingTeam.Players.Count; j++) 
				{
					if (DefendingTeam.Players[j].position == Player.Position.GoalKeeper)
					{
						GoalKeeper = DefendingTeam.Players[j];
						break;
					}
				}


				//Comparing the skill levels and adding points if goal scored 
				if ((Attacker.SkillLevel- 10) > GoalKeeper.SkillLevel) //Penalty scored 
				{
					if (AttackingTeam == Team1)
					{
						T1PenGoals = T1PenGoals + 1;
                    }

                    else
                    {
                        T2PenGoals = T2PenGoals + 1;
                    }
                    Console.Write($"Penalty scored! [Score: {Team1.TeamName} {T1PenGoals} | {Team2.TeamName} {T2PenGoals}]\n");
				}

				else //Saved 
				{
					Console.Write($"Saved! [Score: {Team1.TeamName} {T1PenGoals} | {Team2.TeamName} {T2PenGoals}]\n");
				}

				//Swap teams for next turn 
                Team X = DefendingTeam;
                DefendingTeam = AttackingTeam;
                AttackingTeam = X;

            }
			PrintResults();
		}

		public Player GetAttacker(Team team) //Gets a random attacker from the team 
		{
			List<Player> attackers = new List<Player>();
			attackers = team.Attack();

            int player = RandomInt.GetRandom(0, attackers.Count);
            Player ChosenAttacker = attackers[player];

			return ChosenAttacker; 
		}

		public void PrintResults()
		{
			Console.WriteLine($"\n\nFINAL SCORE \n{Team1.TeamName}: {T1PenGoals} | {Team2.TeamName}: {T2PenGoals}");

			if (T1PenGoals > T2PenGoals)
			{
				Console.WriteLine($"{Team1.TeamName} is the winner!!");
			}

			else if (T1PenGoals < T2PenGoals)
			{
                Console.WriteLine($"{Team2.TeamName} is the winner!!");
            }

			else //draw again 
			{
				Console.WriteLine("It's a draw again, looks like both teams are great!");
			}
		}
	}
}
