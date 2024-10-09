using System;

namespace FootBallGameSimulator
{
	public class Half : Match
	{
		//Attributes 
		public int Team1Skills { get; private set; }
		public int Team2Skills { get; private set; }
		public int HalfMatch { get; private set; }

		//Constructor
		public Half(Team team1, Team team2) : base (team1, team2)
		{
			HalfMatch = base.TotalTurns / 2;
		}

		//Methods 

		//Turn will be represented as instances in a loop 
		public void Turn (Team Attacking, Team Defending)
		{ 
			for(int i = 1; i <= HalfMatch; i++)
			{
                int AttackerSkills = CalculateTeamSkill(Attacking);
				int DefenderSkills = CalculateTeamSkill(Defending);
				bool Goal = CompareSkills(AttackerSkills, DefenderSkills);
				
                Console.Write($"\nTurn {i}: {Attacking.TeamName} are attacking... ");
                if (Goal) { Console.Write("Goal!"); }
                else { Console.Write("Defended successfully!"); }

				//Now teams will swap places Attackers will become Defenders and vice versa 
				Team X = Defending; 
			    Defending = Attacking;
				Attacking = X;
            }
		}

        public int CalculateTeamSkill(Team team)
		{
			int TotalSkill = 0;

			for (int i = 0; i < team.Players.Count; i++) //Going through team players and tallying their skills 
			{
				TotalSkill =+ team.Players[i].SkillLevel;
			}

			return TotalSkill;
		}

		public bool CompareSkills(int AttackerSkills, int DefenderSkills) //Boolean returned true=goal, false=saved
		{
			if (AttackerSkills < DefenderSkills)
			{
				return false; //Goal saved 
			}

			else if (AttackerSkills > DefenderSkills)
			{
				if ((AttackerSkills - 10) >= DefenderSkills) //If attackers has at least 10 more skill points than defenders they will score a goal
				{
					return true;
				}

				else //Goal saved 
				{
					return false;	
				}
				
			}

			else
			{
				return false; //Goal not scored 
			}
		}
	}
}
