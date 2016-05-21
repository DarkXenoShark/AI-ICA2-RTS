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

	public void Set_New_Goal()
	{
		AgentMaster.BuildingGoal quick_goal = new AgentMaster.BuildingGoal();
		quick_goal.TheBuilding = (AgentMaster.EBuilding.Storage);
		quick_goal.TheDestination = Get_First_Empty_Loaction();
		
		AgentMaster.Write_Problem(
			"rts", 
			TheResources,
			AgentMaster.Convert_PlayerBehaviour_To_People(my_people.ToArray()), 
			AgentMaster.Convert_Locations_To_Building(GameMaster.Get_Locations_Of_Player(TheAlliance)), 
			quick_goal);
		AgentMaster.Call_Start();
		foreach (AgentMaster.AgentCommands rep_string in AgentMaster.Get_Generated_Plan())
		{
			Debug.Log(rep_string.TheAgentName);
		}

		Agent[] quick_commands = AgentMaster.Get_Agent_Batch(AgentMaster.Get_Generated_Plan());
		AgentMaster.Add_Agent_Batch(quick_commands);
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
