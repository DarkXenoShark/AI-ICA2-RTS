using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using SandTiger;

public class GameMaster : MonoBehaviour
{
    private static GameMaster self;

    [SerializeField] private List<Player> my_players;
    [SerializeField] private List<Location> my_locations;

    public static void Register_Player(Player its_player)
    {
        self.my_players.Add(its_player);
    }

    public static void Register_Location(Location its_location)
    {
        self.my_locations.Add(its_location);
    }
    public static Location[] Get_Locations_Of_Neutral()
    {
        return Get_Locations_Of_Player(-1);
    }

    /// <summary>
    /// Obtains all the locations that are of neutral alliance or of the player's alliance
    /// </summary>
    /// <param name="its_player"></param>
    /// <returns></returns>
    public static Location[] Get_Locations_Of_Player(int its_player)
    {
        List<Location> returner = new List<Location>();

        foreach (Location rep_location in self.my_locations)
        {
            if (rep_location.TheAlliance == -1 || rep_location.TheAlliance == its_player)
                returner.Add(rep_location);
        }

        return returner.ToArray();
    }

    void Awake()
    {
        self = this;

        Set_Players();
    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void Set_Players()
    {
        for (int rep_player = 0; rep_player < my_players.Count; rep_player++)
        {
            my_players[rep_player].TheAlliance = rep_player;
        }
    }

    public static PlayerBehaviour Get_Person_By_Name(string its_name)
    {
        foreach (Player rep_player in self.my_players)
        {
            foreach (PlayerBehaviour rep_person in rep_player.my_people)
            {
                if (rep_person._self.TheName == its_name)
                    return rep_person;
            }
        }

        Debug.LogError("Person " + its_name + " does not exist!");
        return new PlayerBehaviour();
    }

    public static Location Get_Location_By_Name(string its_name)
    {
        foreach (Location rep_location in self.my_locations)
        {
            if (rep_location.TheSelf.TheName == its_name)
                return rep_location;
        }

        Debug.LogError("Location "+ its_name + " does not exist!");
        return new Location();
    }
}
