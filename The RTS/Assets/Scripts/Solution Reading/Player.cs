using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using SandTiger;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<PlayerBehaviour> my_people;
    public AgentMaster.Resources TheResources;
	public AgentMaster.EBuilding[] TheGoal;

	public GameObject AttachedPerson;


	public int TheAlliance { get; set; }

	[UsedImplicitly] void Start()
	{
		foreach (PlayerBehaviour rep_person in my_people)
		{
			rep_person._alliance = TheAlliance;
		}
	}

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
	public string Get_Empty_Loaction_Index(int its_empty)
    {
        Location[] quickLocations = GameMaster.Get_Locations_Of_Player(TheAlliance);

        foreach (Location repLocation in quickLocations.Where(repLocation => repLocation.TheSelf.TheResource == AgentMaster.EResource.None &&
                                                                                repLocation.TheSelf.TheType == AgentMaster.EBuilding.None))
        {
	        its_empty--;
			if (its_empty <= 0)
				return repLocation.TheSelf.TheName;
        }

        //If it reaches this point, there is no empty location registered
        return "Error";
    }

	public void Create_Person(string its_location)
	{
		Location quick_location = GameMaster.Get_Location_By_Name(its_location);

		PlayerBehaviour quick_person = GameObject.Instantiate(AttachedPerson).GetComponent<PlayerBehaviour>();
		quick_person.SetTilePosition(new IVector2((int)quick_location.transform.position.x,(int)quick_location.transform.position.y));
		quick_person._alliance = TheAlliance;
		quick_person._self.TheLocation = its_location;
		quick_person._self.TheJob = AgentMaster.EJob.Labourer;
	}

	public void Set_New_Goal()
	{
		AgentMaster.BuildingGoal[] quick_goals = new AgentMaster.BuildingGoal[TheGoal.Length];
		for (int rep_goal = 0; rep_goal < TheGoal.Length; rep_goal++)
		{
			quick_goals[rep_goal]= new AgentMaster.BuildingGoal
		{
			TheBuilding = TheGoal[rep_goal],
			TheDestination = Get_Empty_Loaction_Index(rep_goal+1)
		};

		}


		AgentMaster.Write_Problem(
			"rts", 
			TheResources,
			AgentMaster.Convert_PlayerBehaviour_To_People(my_people.ToArray()), 
			AgentMaster.Convert_Locations_To_Building(GameMaster.Get_Locations_Of_Player(TheAlliance)), 
			quick_goals);
		AgentMaster.Call_Start();
		foreach (AgentMaster.AgentCommands rep_string in AgentMaster.Get_Generated_Plan())
		{
			Debug.Log(rep_string.TheAgentName);
		}

		Agent[] quick_commands = AgentMaster.Get_Agent_Batch(AgentMaster.Get_Generated_Plan());
		AgentMaster.Add_Agent_Batch(quick_commands);
	}
}
