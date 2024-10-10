using FootBallGameSimulator;
using System;
using System.ComponentModel.Design;

public class TeamGenerator
{
    public static Dictionary<int, string> PlayerPool = new Dictionary<int, string>();

    //Constructor and will only be executed once when class is first called
    public  TeamGenerator()
    {
        //Adding values to dictionary
        AddTeam();
        /*
        PlayerPool.Add(1, "AlShibli");
        PlayerPool.Add(2, "Abdullah");
        PlayerPool.Add(3, "Fatma");
        PlayerPool.Add(4, "Kareem");
        PlayerPool.Add(5, "Afra7");
        PlayerPool.Add(6, "Montaha");
        PlayerPool.Add(7, "Amer");
        PlayerPool.Add(8, "Shahad");
        PlayerPool.Add(9, "Budoor");
        PlayerPool.Add(10, "Alanoud");
        PlayerPool.Add(11, "Tasneem");
        PlayerPool.Add(12, "Amani");
        PlayerPool.Add(13, "Azza");
        PlayerPool.Add(14, "Afraa");
        PlayerPool.Add(15, "Ibrahim");
        PlayerPool.Add(16, "Rashid");
        PlayerPool.Add(17, "Saleh");
        PlayerPool.Add(18, "Mohammed");
        PlayerPool.Add(19, "Zubair");
        PlayerPool.Add(20, "Yazen");
        PlayerPool.Add(21, "Duha");
        PlayerPool.Add(22, "Azzan");
        */
    }

    public static List<Player> Players(Team team)
    {
        //Dictionary of PlayerIDs | PlayerNames
        List<Player> NewTeam = new List<Player>();
        List<Player> OtherTeam = new List<Player>();
        int Skill;
        int ID;


        if (PlayerPool.Count == 22) //CODE FOR FIRST TEAM
        {
            //Each team will have: 1 Goalie, 3 Defenders, 4 Midfielders, 3 Forward

            //CREATING GOALIE x1
            for (int i = 0; i < 1; i++) //Added a for loop in case ID generated is already in use then we will need to repear 
            {
                ID = RandomInt.GetRandom(1, 23); //Dictionary has 22 values 
                if (PlayerPool.ContainsKey(ID))
                {
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Goalie = new Player(ID, PlayerPool[ID], team, Player.Position.GoalKeeper, Skill);
                    PlayerPool.Remove(ID); //Removing the player so that they don't get used again by accident 
                    NewTeam.Add(Goalie);
                }
                else { i--; } //Player wasn't added so we want the system to try again 
            }

            //CREATING DEFENDERS x3
            for (int i = 0; i < 3; i++)
            {
                ID = RandomInt.GetRandom(1, 23);
                if (PlayerPool.ContainsKey(ID))
                {
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Def = new Player(ID, PlayerPool[ID], team, Player.Position.Defender, Skill);
                    PlayerPool.Remove(ID); //Removing the player so that they don't get used again by accident 
                    NewTeam.Add(Def);
                }
                else { i--; } //Player wasn't added so we want the system to try again 
            }

            //CREATING MIDFIELDERS x4
            for (int i = 0; i < 4; i++)
            {
                ID = RandomInt.GetRandom(1, 23);
                if (PlayerPool.ContainsKey(ID))
                {
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Mid = new Player(ID, PlayerPool[ID], team, Player.Position.Midfielder, Skill);
                    PlayerPool.Remove(ID); //Removing the player so that they don't get used again by accident 
                    NewTeam.Add(Mid);
                }
                else { i--; } //Player wasn't added so we want the system to try again 
            }

            //CREATING FORWARD x3
            for (int i = 0; i < 3; i++)
            {
                ID = RandomInt.GetRandom(1, 23);
                if (PlayerPool.ContainsKey(ID))
                {
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Forward = new Player(ID, PlayerPool[ID], team, Player.Position.Forward, Skill);
                    PlayerPool.Remove(ID); //Removing the player so that they don't get used again by accident 
                    NewTeam.Add(Forward);
                }
                else { i--; } //Player wasn't added so we want the system to try again 
            }

            return NewTeam;
        }

        else //CODE FOR SECOND TEAM
        {

            int i = 0;
            foreach (KeyValuePair<int, string> player in PlayerPool)
            {
                if (i < 1)
                {
                    //CREATING GOALIE x1 
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Goalie = new Player(player.Key, PlayerPool[player.Key], team, Player.Position.GoalKeeper, Skill);
                    PlayerPool.Remove(player.Key);
                    OtherTeam.Add(Goalie);
                    i++;
                }
                else { break; }
            }



            i = 0;
            foreach (KeyValuePair<int, string> player in PlayerPool)
            {
                if (i < 2)
                {
                    //CREATING DEFENDERS x2
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Def = new Player(player.Key, PlayerPool[player.Key], team, Player.Position.Defender, Skill);
                    PlayerPool.Remove(player.Key);
                    OtherTeam.Add(Def);
                    i++;
                }
                else { break; }
            }

            i = 0;
            foreach (KeyValuePair<int, string> player in PlayerPool)
            {
                if (i < 3)
                {
                    //CREATING MIDFIELDERS x3
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Mid = new Player(player.Key, PlayerPool[player.Key], team, Player.Position.Midfielder, Skill);
                    PlayerPool.Remove(player.Key);
                    OtherTeam.Add(Mid);
                    i++;
                }
            }

            i = 0;
            foreach (KeyValuePair<int, string> player in PlayerPool)
            {
                if (i < 3)
                {
                    //CREATING FORWARD x3
                    Skill = RandomInt.GetRandom(1, 101);
                    Player Forward = new Player(player.Key, PlayerPool[player.Key], team, Player.Position.Forward, Skill);
                    PlayerPool.Remove(player.Key);
                    OtherTeam.Add(Forward);
                    i++;
                }
                else { break; }
            }
        
        
            return OtherTeam;
        }
	}

    public static void AddTeam()
    {
        PlayerPool.Clear();
        //Adding values to dictionary
        PlayerPool.Add(1, "AlShibli");
        PlayerPool.Add(2, "Abdullah");
        PlayerPool.Add(3, "Fatma");
        PlayerPool.Add(4, "Kareem");
        PlayerPool.Add(5, "Afra7");
        PlayerPool.Add(6, "Montaha");
        PlayerPool.Add(7, "Amer");
        PlayerPool.Add(8, "Shahad");
        PlayerPool.Add(9, "Budoor");
        PlayerPool.Add(10, "Alanoud");
        PlayerPool.Add(11, "Tasneem");
        PlayerPool.Add(12, "Amani");
        PlayerPool.Add(13, "Azza");
        PlayerPool.Add(14, "Afraa");
        PlayerPool.Add(15, "Ibrahim");
        PlayerPool.Add(16, "Rashid");
        PlayerPool.Add(17, "Saleh");
        PlayerPool.Add(18, "Mohammed");
        PlayerPool.Add(19, "Zubair");
        PlayerPool.Add(20, "Yazen");
        PlayerPool.Add(21, "Duha");
        PlayerPool.Add(22, "Azzan");
    }
}
