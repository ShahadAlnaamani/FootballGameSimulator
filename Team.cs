using System;

namespace FootBallGameSimulator
{
	public class Team
	{
		//Attributes
		public string TeamName { get; private set; }
		public List<Player> Players { get; private set; }
        public int TeamScore { get; private set; }


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

        public List<Player> Attack() //Generates team members to play when team is attacking 
        {
            //Chooses a random number 1 - 7 (total number of forward + mid )
            int NumAttackers = RandomInt.GetRandom(1, 7); //Total number of attackers that will be chosen 

            //Chooses random players (must be forward and mid) to a total of NumAttackers
            List<Player> Attackers = new List<Player>(); //All eligible players 
            List<Player> ChosenAttackers = new List<Player>();//Final random choice of attackers

            for (int i = 0; i < Players.Count; i++) //Finding eligable attackers 
            {
                if (Players[i].position == Player.Position.Forward || Players[i].position == Player.Position.Midfielder) 
                {
                    Attackers.Add(Players[i]);
                }
            }

            for (int i = 0; i < NumAttackers; i++) //Randomly choosing a group of attackers 
            {
                int player = RandomInt.GetRandom(1, Attackers.Count);
                ChosenAttackers.Add(Players[player]);
            }
            
            return ChosenAttackers;
        }

        public List<Player> Defend() //Generates team members to play when team is defending 
        {
            //choose a random number 1 - 5 (total number of Goalie + defenders)
            int NumDefenders = RandomInt.GetRandom(1, 5); //Total number of defenders that will be chosen 

            //Get one goalie and add defenders till previous number reached 
            List<Player> Defenders = new List<Player>(); //All eligible players 
            List<Player> ChosenDefenders = new List<Player>();//Final random choice of defenders

            for (int i = 0; i < Players.Count;i++) 
            {
                if (Players[i].position == Player.Position.GoalKeeper) 
                {
                    ChosenDefenders.Add(Players[i]);
                    NumDefenders--; //To take account for the goalie 
                }

                if (Players[i].position == Player.Position.Defender) //Collecting all defenders 
                {
                    Defenders.Add(Players[i]);
                }
            }

            for (int i = 0; i < NumDefenders; i++) //Randomly choosing a group of attackers 
            {
                int player = RandomInt.GetRandom(1, Defenders.Count);
                ChosenDefenders.Add(Players[player]);
            }

            return ChosenDefenders;

        }

        public void AddScore()
        {
            TeamScore = TeamScore+1;
        }
    }
}
