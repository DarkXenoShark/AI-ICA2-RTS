using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public List<PlayerBehaviour> my_people;

    public AgentMaster.Resources TheResources;

    private int my_alliance;

    public int TheAlliance
    {
        get
        {
            return my_alliance;
        }

        set
        {
            my_alliance = value;
        }
    }

    public string Get_First_Empty_Loaction()
    {
        Location[] quick_locations = GameMaster.Get_Locations_Of_Player(my_alliance);

        foreach (Location rep_location in quick_locations)
        {
            if (rep_location.TheSelf.TheResource == AgentMaster.EResource.None &&
                rep_location.TheSelf.TheType == AgentMaster.EBuilding.None)
                return rep_location.TheSelf.TheName;
        }

        //If it reaches this point, there is no empty location registered
        return "Error";
    }


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
