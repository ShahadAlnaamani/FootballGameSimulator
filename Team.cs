using System;

namespace FootBallGameSimulator
{
	public class Team
	{
		//Attributes
		public string TeamName { get; private set; }
		public List<Player> Players { get; private set; }


		//Constructor
        public Team(string teamName)
		{
			//Players = new < Players > ();
			TeamName = teamName;
		}


        //Methods
        public void GeneratePlayers() //Creates a list of players [1 Goalie, 3 Defenders, 4 Midfielders, 3 Forward]
        {
           Players = TeamGenerator.Players(this);
        }

        public void DisplayPlayers()
        {
            int i = 1;

            Console.WriteLine(TeamName + " players: ");
            foreach (Player player in Players) 
            {
                Console.WriteLine($"{i}. {player.Name} - {player.position} (Skill: {player.SkillLevel})");
                i++;
            }
        }

        public void Attack()
        { }

        public void Defend()
        { }
    }
}
