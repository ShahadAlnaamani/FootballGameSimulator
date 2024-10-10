using System;

namespace FootBallGameSimulator
{
	public class Half : Match
	{
		//Attributes 
		public int Team1Skills { get; private set; }
		public int Team2Skills { get; private set; }
		public int HalfMatch { get; private set; }
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }

        //Constructor
        public Half(Team team1, Team team2) : base (team1, team2)
		{

            HalfMatch = base.TotalTurns / 2;
			Team1 = team1;
			Team2 = team2;
		}

		//Methods 

		//Turn will be represented as instances in a loop 
		public void Turn (Team Attacking, Team Defending, int turn) //Actual process of the game 
        {
            for (int i = 0; i < HalfMatch; i++)
			{

                int AttackerSkills = CalculateTeamSkill(Attacking.Attack());//Generating new mix of players from the team that will participate in the turn and calculating the skill level
                int DefenderSkills = CalculateTeamSkill(Defending.Defend());
				bool Goal = CompareSkills(AttackerSkills, DefenderSkills);

                Console.Write($"\nTurn {turn}: {Attacking.TeamName} are attacking... ");
                turn++;
                if (Goal)
				{ 
					Console.Write("Goal!");
					AddScore(Attacking);
				}
                else { Console.Write("Defended successfully!"); }

                //Finding leading team 
                if (Team1.TeamScore > Team2.TeamScore)
				{
					Console.Write($" Team {Team1.TeamName} is winning");
				}

				else if (Team1.TeamScore < Team2.TeamScore)
				{
                    Console.Write($" Team {Team2.TeamName} is winning");
                }

				else
				{
					Console.Write("The teams are tied");
				}

                Console.Write($" score: [Team {Team1.TeamName} {Team1.TeamScore}] [Team {Team2.TeamName} {Team2.TeamScore}]\n");

                //Now teams will swap places Attackers will become Defenders and vice versa 
                Team X = Defending; 
			    Defending = Attacking;
				Attacking = X;

				
            }

            Console.WriteLine($"\nTotal Goals scored in this half: Team {Team1.TeamName} Score {Team1Score} | Team {Team2.TeamName} Score {Team2Score} ");
        } 

        public int CalculateTeamSkill(List<Player> players) //Calculates the skills of players playing in a turn 
        {
			int TotalSkill = 0;

			for (int i = 0; i < players.Count; i++) //Going through team players and tallying their skills 
			{
				TotalSkill = TotalSkill + players[i].SkillLevel;
			}

			return TotalSkill;
		} 

		public bool CompareSkills(int AttackerSkills, int DefenderSkills) //Boolean returned true=goal, false=saved
		{
			if (AttackerSkills < DefenderSkills)
			{
				return false; //Goal saved 
			}

			else if ((AttackerSkills-10) > DefenderSkills)//If attackers has at least 10 more skill points than defenders they will score a goal
            {
				return true;
			}

			else
			{
				return false; //Goal not scored 
			}
		}
	}
}
