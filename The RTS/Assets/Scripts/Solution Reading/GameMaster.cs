using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _self;

    [SerializeField] private List<Player> my_players;
    [SerializeField] private List<Location> my_locations;

    public static void Register_Player(Player itsPlayer)
    {
        _self.my_players.Add(itsPlayer);
    }

    public static void Register_Location(Location itsLocation)
    {
        _self.my_locations.Add(itsLocation);
    }
    public static Location[] Get_Locations_Of_Neutral()
    {
        return Get_Locations_Of_Player(-1);
    }

    /// <summary>
    /// Obtains all the locations that are of neutral alliance or of the player's alliance
    /// </summary>
    /// <param name="itsPlayer"></param>
    /// <returns></returns>
    public static Location[] Get_Locations_Of_Player(int itsPlayer)
    {
	    return _self.my_locations.Where(repLocation => repLocation.TheAlliance == -1 || repLocation.TheAlliance == itsPlayer).ToArray();
    }

    void Awake()
    {
        _self = this;

        Set_Players();
    }

    private void Set_Players()
    {
        for (int repPlayer = 0; repPlayer < my_players.Count; repPlayer++)
        {
            my_players[repPlayer].TheAlliance = repPlayer;
        }
    }

    public static PlayerBehaviour Get_Person_By_Name(string its_name)
    {
        foreach (PlayerBehaviour repPerson in _self.my_players.SelectMany(repPlayer => repPlayer.my_people.Where(repPerson => repPerson._self.TheName == its_name)))
        {
	        return repPerson;
        }

        Debug.LogError("Person " + its_name + " does not exist!");
        return new PlayerBehaviour();
    }

    public static Location Get_Location_By_Name(string its_name)
    {
        foreach (Location repLocation in _self.my_locations.Where(repLocation => repLocation.TheSelf.TheName == its_name))
        {
	        return repLocation;
        }

        Debug.LogError("Location "+ its_name + " does not exist!");
        return new Location();
    }

	public static Player Get_Player(int its_alliance)
	{
		return _self.my_players[its_alliance];
	}
}
