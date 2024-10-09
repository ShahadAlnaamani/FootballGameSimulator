using System;

namespace FootBallGameSimulator
{
	public sealed class Player
	{
		//Attibutes 
		public int PlayerID { get; private set; }
		public string Name { get; private set; }
        public Team team { get; private set; }
		public int SkillLevel { get; private set; }
		public enum Position { Forward, Midfielder, Defender, GoalKeeper}
		public Position position { get; private set; }

        //Constructor 
        public Player(int playerID, string name, Team team, Position position, int Skill)
		{
			PlayerID = playerID;
			Name = name;
			this.team = team;
			this.position = position;
			SkillLevel = Skill;
		}
		
	}
}
