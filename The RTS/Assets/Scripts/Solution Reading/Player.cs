using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<PlayerBehaviour> my_people;
    public AgentMaster.Resources TheResources;

	public int TheAlliance { get; set; }

	public string Get_First_Empty_Loaction()
    {
        Location[] quickLocations = GameMaster.Get_Locations_Of_Player(TheAlliance);

        foreach (Location repLocation in quickLocations.Where(repLocation => repLocation.TheSelf.TheResource == AgentMaster.EResource.None &&
                                                                                repLocation.TheSelf.TheType == AgentMaster.EBuilding.None))
        {
	        return repLocation.TheSelf.TheName;
        }

        //If it reaches this point, there is no empty location registered
        return "Error";
    }

	public void Set_New_Goal()
	{
		AgentMaster.BuildingGoal quick_goal = new AgentMaster.BuildingGoal
		{
			TheBuilding = (AgentMaster.EBuilding.Storage),
			TheDestination = Get_First_Empty_Loaction()
		};

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
}
