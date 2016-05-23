using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class AgentMaster : MonoBehaviour
{
	public static AgentMaster self;

	[SerializeField] private bool my_optimise;
	[SerializeField] private string my_domain_name;

	public Dictionary<string, Agent> my_agent_types;
	public List<List<Agent>> my_running_agent_batches;

	public string Domain
	{
		get
		{
			return my_domain_name;
		}
	}

	public enum EGoal
	{ None, GetError, GetBuilding }

	public interface IGoal
	{
		string[] Write_Goal();
	}

	[Serializable] public class BuildingGoal: IGoal
	{
		public EBuilding TheBuilding;
		public string TheDestination;

		public string[] Write_Goal()
		{
			string[] returner = new string[1];

			returner[0] = ("has-" + Building_To_String(TheBuilding) + " " + TheDestination);
			return returner;
		}
	}

	[Serializable] public class OrGoal: IGoal
	{
		public EBuilding TheBuilding;
		public Building[] TheDestinations;

		public string[] Write_Goal()
		{
			return (from rep_building in TheDestinations
					where rep_building.TheResource == EResource.None && rep_building.TheType == EBuilding.None
					select "has-" + Building_To_String (TheBuilding) + " " + rep_building.TheName).ToArray();
		}
	}

	public static Building[] Convert_Locations_To_Building(Location[] its_locations)
	{
		return its_locations.Select(repLocation => repLocation.TheSelf).ToArray();
	}

	public static Person[] Convert_PlayerBehaviour_To_People(PlayerBehaviour[] its_people)
	{
		return its_people.Select(repPerson => repPerson._self).ToArray();
	}

	private List<Agent> my_active_agents;

	[Serializable] public struct Person
	{
		public string TheName;
		public EJob TheJob;
		public string TheLocation;
	}

	[Serializable] public struct Building
	{
		public string TheName;
		public EBuilding TheType;
		public EResource TheResource;
	}

	[Serializable] public struct Resources
	{
		public int TheTimber;
		public int TheWood;
		public int TheStone;
		public int TheCoal;
		public int TheOre;
		public int TheIron;
	}

	public struct AgentCommands
	{
		public string TheAgentName;
		public string[] TheAgentActions;
	}

	public enum EJob
	{
		Unknown,
		Labourer,
		Carpenter,
		Lumberjack,
		Miner,
		Blacksmith,
		Teacher
	}
	
	public enum EBuilding
	{
		None,
		Turfhut,
		House,
		School,
		Barracks,
		Storage,
		Coalmine,
		Oremine,
		Smelter,
		Quary,
		Sawmill,
		Refinery,
		MarketStall
	}

	public enum EResource
	{ None, Timber, Wood, Coal, Ore, Iron, Stone }

	/// <summary> Converts an EJob to a string representation </summary>
	/// <returns>A string of the given EJob</returns>
	/// <param name="its">The job type to be converted to a string</param>
	public static string Job_To_String(EJob its)
	{
		return its.ToString().ToLower();
	}
	
	/// <summary> Converts an EBuilding to a string representation </summary>
	/// <returns>A string of the given EBuilding</returns>
	/// <param name="its">The building type to be converted to a string</param>
	public static string Building_To_String(EBuilding its)
	{
		// Explicit enum to string.
		switch (its)
		{
			case EBuilding.Coalmine:
			return "coalMine";

			case EBuilding.Oremine:
			return "oreMine";

			case EBuilding.MarketStall:
			return "marketStall";
		}

		return its.ToString().ToLower();
	}
	
	public static string Resource_To_String(EResource its)
	{
		return its.ToString().ToLower();
	}

	public static string Location_To_String(EResource its)
	{
		// Explicit enum to string.
		switch (its)
		{
			case EResource.Coal:
			return "miningResource";

			case EResource.Ore:
			return "miningResource";

			case EResource.None:
			return "location";

			case EResource.Timber:
			return "forest";
		}

		return its.ToString().ToLower();
	}
	
	[UsedImplicitly] private void Awake()
	{
		self = this;
		my_active_agents = new List<Agent>();
		my_running_agent_batches = new List<List<Agent>>();
		my_agent_types = new Dictionary<string, Agent>();

		/*serialised_person_names = new List<string>();
		serialised_person_jobs = new List<EJob>();
		serialised_person_locations = new List<string>();
		
		serialised_building_names = new List<string>();
		serialised_building_types = new List<EBuilding>();
		serialised_building_resources = new List<EResource>();

		my_person_incriment = 0;
		my_building_incriment = 0;*/
	}

	public static void Register_Agent_Type(Agent its_agent, string its_name)
	{
		self.my_agent_types.Add(its_name, its_agent);
	}

	public static Agent Obtain_Agent_Copy(string its_name)
	{
		if (self.my_agent_types.ContainsKey(its_name))
			return self.my_agent_types[its_name];

		Debug.LogError("Agent of type " + its_name + " is missing!");
		return new Agent();
	}
	
	public static void Add_Agent_Batch(Agent[] its_new_batch)
	{
		List<Agent> quick_agent = new List<Agent>();
		quick_agent.AddRange(its_new_batch);
		self.my_running_agent_batches.Add(quick_agent);
		self.my_running_agent_batches[self.my_running_agent_batches.Count-1][0].Call_Start();
	}


	public static void Add_Agent(Agent its_new_agent)
	{
		self.my_active_agents.Add(its_new_agent);
		its_new_agent.Call_Start();
	}
	
	public static void Abort_Agent(Agent its_agent)
	{
		self.my_active_agents.Remove(its_agent);
		its_agent.Call_End();
	}
	
	// Update is called once per frame
	[UsedImplicitly] private void Update ()
	{
		for (int rep_agent_batch = 0; rep_agent_batch < self.my_running_agent_batches.Count; rep_agent_batch++)
		{
			List<Agent> quick_batch = self.my_running_agent_batches[rep_agent_batch];

			if (!quick_batch[0].Call_Update()) continue;

			quick_batch.RemoveAt(0);

			if (quick_batch.Count > 0)
			{
				quick_batch[0].Call_Start();
			}
			else
			{
				self.my_running_agent_batches.RemoveAt(rep_agent_batch);
				rep_agent_batch--;
			}
		}
	}

	/// <summary>
	///  Generates a PDDL problem to be solved
	///  It adds together several splits between the phases of writing a problem and
	/// combines them into a string to save as a separate file.
	/// </summary>
	public static void Write_Problem(string its_file, Resources its_resources, Person[] its_scoped_people, Building[] its_scoped_buildings, IGoal[] its_goal)
	{
		//using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/Resources/" + its_file + "-problem.pddl"))
		using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/PDDL/Metric-FF/" + its_file + "-problem.pddl"))
		{
			Problem_Writing_Intro(quick_writer, its_file, "prob1");
			Problem_Writing_Objects(quick_writer, its_scoped_people, its_scoped_buildings);
			Problem_Writing_Initialising(quick_writer, its_resources, its_scoped_people, its_scoped_buildings);
			Problem_Writing_Goal(quick_writer, its_goal);
			Problem_Writing_Outro(quick_writer);

			Debug.Log ("File " + Application.dataPath + "/Resources/" + its_file + ".pddl" + " created");
		}
	}

	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private static void Problem_Writing_Intro(StreamWriter its_stream, string its_file_name, string its_problem_name)
	{
		//First the top line
		its_stream.WriteLine("(define (problem " + its_file_name + "-" + its_problem_name + ")");
		its_stream.WriteLine("\t(:domain " + its_file_name + ")");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private static void Problem_Writing_Objects(StreamWriter its_stream, IList<Person> its_scoped_people, IList<Building> its_scoped_buildings)
	{
		its_stream.WriteLine("\t(:objects");

		//Go through each person listed in the list of people
		for (int rep_person = 0; rep_person < its_scoped_people.Count; rep_person++)
		{
			its_stream.WriteLine("\t\t" + its_scoped_people[rep_person].TheName + " - person");
		}

		//Go through each location listed in the list of locations
		for (int rep_building = 0; rep_building < its_scoped_buildings.Count; rep_building++)
		{
			its_stream.WriteLine("\t\t" + its_scoped_buildings[rep_building].TheName + " - " + Location_To_String(its_scoped_buildings[rep_building].TheResource));
		}

		//its_stream.WriteLine("\t\t" + "X" + " - " + Location_To_String(EResource.None));

		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private static void Problem_Writing_Initialising(StreamWriter its_stream, Resources its_resources, IList<Person> its_scoped_people, IList<Building> its_scoped_buildings)
	{
		its_stream.WriteLine("\t(:init");

		//Looping through people jobs and assigning them
		for (int rep_person = 0; rep_person < its_scoped_people.Count; rep_person++)
		{
			its_stream.WriteLine("\t\t(is-" + Job_To_String(its_scoped_people[rep_person].TheJob)+ " " + its_scoped_people[rep_person].TheName + ")");
			its_stream.WriteLine("\t\t(at " + its_scoped_people[rep_person].TheName + " " + its_scoped_people[rep_person].TheLocation + ")");
		}

		//Looping through each building and assigning their resource
		for (int rep_building = 0; rep_building < its_scoped_buildings.Count; rep_building++)
		{
			if (its_scoped_buildings[rep_building].TheType != EBuilding.None)
				its_stream.WriteLine("\t\t(has-" + Building_To_String(its_scoped_buildings[rep_building].TheType) + " " + its_scoped_buildings[rep_building].TheName + ")");

			if (its_scoped_buildings[rep_building].TheResource != EResource.None)
				its_stream.WriteLine("\t\t(has-" + Resource_To_String(its_scoped_buildings[rep_building].TheResource) + " " + its_scoped_buildings[rep_building].TheName + ")");
		}

		//Set the number of each resource
		its_stream.WriteLine("\t\t(=(labourCost) " + "0" + ")");
		its_stream.WriteLine("\t\t(=(timber) " + its_resources.TheTimber + ")");
		its_stream.WriteLine("\t\t(=(wood) " + its_resources.TheWood + ")");
		its_stream.WriteLine("\t\t(=(stone) " + its_resources.TheStone + ")");
		its_stream.WriteLine("\t\t(=(coal) " + its_resources.TheCoal + ")");
		its_stream.WriteLine("\t\t(=(ore) " + its_resources.TheOre + ")");
		its_stream.WriteLine("\t\t(=(iron) " + its_resources.TheIron + ")");
		its_stream.WriteLine("\t\t(=(population) " + its_scoped_people.Count + ")");

		//End the resource writing
		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	private static void Problem_Writing_Goal(StreamWriter its_stream, IGoal[] its_goal)
	{
		its_stream.WriteLine("\t(:goal");
		its_stream.WriteLine("\t\t(and");

		//This will probably hold a list of conditions
		foreach (IGoal rep_goal in its_goal)
		{
			its_stream.WriteLine("\t\t\t(or");
			foreach (string rep_line in rep_goal.Write_Goal())
			{
				its_stream.WriteLine("\t\t\t\t(" + rep_line + ")");
			}
			its_stream.WriteLine("\t\t\t)");
		}


		its_stream.WriteLine("\t\t\t)");

		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");

		if (self.my_optimise)
			its_stream.WriteLine("\t\t(:metric minimize (labourCost))");

		its_stream.WriteLine("");

	}

	/// <summary>
	/// Writes the end of a file
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	private static void Problem_Writing_Outro(StreamWriter its_stream)
	{
		//First the top line
		its_stream.WriteLine(")");
	}
	
	public string Read_Solution(string its_filename)
	{
		return "";
	}

	public static void Call_Start()
	{
		self.GetComponent<TaskPlannerProcess>().CallStart();
	}

	public static AgentCommands[] Get_Generated_Plan()
	{
		string[] quick_list = self.GetComponent<TaskPlannerProcess>().todoList;
		AgentCommands[] returner = new AgentCommands[quick_list.Length];

		for (int rep_action = 0; rep_action < quick_list.Length; rep_action++)
		{
			char[] quick_splitter = new char[1];
			quick_splitter[0] = ' ';
			string[] quick_splits = quick_list[rep_action].Split(quick_splitter);
			returner[rep_action].TheAgentName = quick_splits[1].Remove(0,1);
			returner[rep_action].TheAgentActions = new string[quick_splits.Length - 4];

			for (int rep_agent = 0; rep_agent < quick_splits.Length - 4; rep_agent++)
			{
				returner[rep_action].TheAgentActions[rep_agent] = quick_splits[rep_agent + 2];
			}
		}

		return returner;
	}

	public static Agent[] Get_Agent_Batch(AgentCommands[] its_commands)
	{
		Agent[] returner = new Agent[its_commands.Length];

		for (int rep_agent = 0; rep_agent < its_commands.Length; rep_agent++)
		{
			returner[rep_agent] = Obtain_Agent_Copy(its_commands[rep_agent].TheAgentName);
			returner[rep_agent].TheActions = its_commands[rep_agent].TheAgentActions;
		}

		return returner;
	}
}