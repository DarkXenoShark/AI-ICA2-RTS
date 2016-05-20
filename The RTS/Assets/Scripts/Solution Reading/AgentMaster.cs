using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class AgentMaster : MonoBehaviour
{
	public static AgentMaster self;

	[SerializeField] private string my_domain_name;

	[SerializeField] private List<Person> my_people;
	[SerializeField] private List<Building> my_buildings;

	[SerializeField] private int my_resource_timber;
	[SerializeField] private int my_resource_wood;
	[SerializeField] private int my_resource_stone;
	[SerializeField] private int my_resource_ore;
	[SerializeField] private int my_resource_coal;
	[SerializeField] private int my_resource_iron;

	[SerializeField] private EBuilding serialized_goal_building;
	[SerializeField] private string serialized_goal_destination;

	public string Domain
	{
		get
		{
			return my_domain_name;
		}
	}

	public enum EGoal
	{
		None,
		GetError,
		GetBuilding
	}

	public interface Goal
	{
		string[] Write_Goal();
	}

	[Serializable]
	public class BuildingGoal: Goal
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

	/// <summary>
	/// Converts the serialised information into a struct array for reading
	/// </summary>
	/// <value>The people.</value>
	public Person[] People
	{
		get
		{
			return my_people.ToArray();
		}
	}

	/// <summary>
	/// Converts the serialised information into a struct array for reading
	/// </summary>
	/// <value>The buildings.</value>
	public Building[] Buildings
	{
		get
		{
			return my_buildings.ToArray();
		}
	}

	private List<Agent> my_active_agents;
	private TaskPlannerProcess my_planner;

	[Serializable]
	public struct Person
	{
		public string TheName;
		public EJob TheJob;
		public string TheLocation;
	}

	[Serializable]
	public struct Building
	{
		public string TheName;
		public EBuilding TheType;
		public EResource TheResource;
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
	{
		None,
		Timber,
		Coal,
		Ore,
		Stone
	}

	/// <summary>
	/// Converts an EJob to a string representation
	/// </summary>
	/// <returns>A string of the given EJob</returns>
	/// <param name="its_job">The job type to be converted to a string</param>
	public static string Job_To_String(EJob its_job)
	{
		switch (its_job)
		{
		case EJob.Labourer:
			return "labourer";
		case EJob.Carpenter:
			return "carpenter";
		case EJob.Lumberjack:
			return "lumberjack";
		case EJob.Miner:
			return "miner";
		case EJob.Blacksmith:
			return "blacksmith";
		case EJob.Teacher:
			return "teacher";
		}
		
		//It should not reach this point
		return "errorjob";
	}
	
	
	/// <summary>
	/// Converts an EBuilding to a string representation
	/// </summary>
	/// <returns>A string of the given EBuilding</returns>
	/// <param name="its_job">The building type to be converted to a string</param>
	public static string Building_To_String(EBuilding its_building)
	{
		switch (its_building)
		{
		case EBuilding.Turfhut:
			return "turfhut";
		case EBuilding.House:
			return "house";
		case EBuilding.School:
			return "school";
		case EBuilding.Barracks:
			return "barracks";
		case EBuilding.Storage:
			return "storage";
		case EBuilding.Coalmine:
			return "coalMine";
		case EBuilding.Oremine:
			return "oreMine";
		case EBuilding.Smelter:
			return "smelter";
		case EBuilding.Quary:
			return "quary";
		case EBuilding.Sawmill:
			return "sawmill";
		case EBuilding.Refinery:
			return "refinery";
		case EBuilding.MarketStall:
			return "marketStall";
		}
		
		//It should not reach this point
		return "errorbuilding";
	}
	
	public static string Resource_To_String(EResource its_resource)
	{
		switch (its_resource)
		{
		case EResource.Timber:
			return "timber";
		case EResource.Coal:
			return "coal";
		case EResource.Ore:
			return "ore";
		case EResource.Stone:
			return "stone";
		}

		//It should not reach this point
		return "location";
	}

	public static string Location_To_String(EResource its_resource)
	{
		switch (its_resource)
		{
		case EResource.Timber:
			return "forest";
		case EResource.Coal:
			return "miningResource";
		case EResource.Ore:
			return "miningResource";
		case EResource.Stone:
			return "stone";
		}

		//It should not reach this point
		return "location";
	}
	
	//private MapParser my_raw_solution;

	//public 

	void Awake()
	{
		self = this;
		my_active_agents = new List<Agent>();
		my_planner = GetComponent<TaskPlannerProcess>();

		/*serialised_person_names = new List<string>();
		serialised_person_jobs = new List<EJob>();
		serialised_person_locations = new List<string>();
		
		serialised_building_names = new List<string>();
		serialised_building_types = new List<EBuilding>();
		serialised_building_resources = new List<EResource>();

		my_person_incriment = 0;
		my_building_incriment = 0;*/
	}

	// Use this for initialization
	void Start ()
	{
		
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
	void Update ()
	{
		foreach (Agent rep_agent in my_active_agents)
		{
			rep_agent.Call_Update();
		}
	}

	/// <summary>
	///  Generates a PDDL problem to be solved
	///  It adds together several splits between the phases of writing a problem and
	/// combines them into a string to save as a separate file.
	/// </summary>
	public static void Write_Problem(string its_file, Person[] its_scoped_people, Building[] its_scoped_buildings, Goal its_goal)
	{
		//using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/Resources/" + its_file + "-problem.pddl"))
		using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/PDDL/Metric-FF/" + its_file + "-problem.pddl"))
		{
			self.Problem_Writing_Intro(quick_writer, its_file, "prob1");
			self.Problem_Writing_Objects(quick_writer, its_scoped_people, its_scoped_buildings);
			self.Problem_Writing_Initialising(quick_writer, its_scoped_people, its_scoped_buildings);
			self.Problem_Writing_Goal(quick_writer, its_goal);
			self.Problem_Writing_Outro(quick_writer);

			Debug.Log ("File " + Application.dataPath + "/Resources/" + its_file + ".pddl" + " created");
		}
	}

	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Intro(StreamWriter its_stream, string its_file_name, string its_problem_name)
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
	private void Problem_Writing_Objects(StreamWriter its_stream, Person[] its_scoped_people, Building[] its_scoped_buildings)
	{
		its_stream.WriteLine("\t(:objects");

		//Go through each person listed in the list of people
		for (int rep_person = 0; rep_person < its_scoped_people.Length; rep_person++)
		{
			its_stream.WriteLine("\t\t" + its_scoped_people[rep_person].TheName + " - person");
		}

		//Go through each location listed in the list of locations
		for (int rep_building = 0; rep_building < its_scoped_buildings.Length; rep_building++)
		{
			//its_stream.WriteLine("\t\t" + its_scoped_buildings[rep_building].TheName + " - " + Resource_To_String(its_scoped_buildings[rep_building].TheResource));
			its_stream.WriteLine("\t\t" + its_scoped_buildings[rep_building].TheName + " - " + Location_To_String(its_scoped_buildings[rep_building].TheResource));
		}

		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Initialising(StreamWriter its_stream, Person[] its_scoped_people, Building[] its_scoped_buildings)
	{
		its_stream.WriteLine("\t(:init");

		//Looping through people jobs and assigning them
		for (int rep_person = 0; rep_person < its_scoped_people.Length; rep_person++)
		{
			its_stream.WriteLine("\t\t(is-" + Job_To_String(its_scoped_people[rep_person].TheJob)+ " " + its_scoped_people[rep_person].TheName + ")");
			its_stream.WriteLine("\t\t(at " + its_scoped_people[rep_person].TheName + " " + its_scoped_people[rep_person].TheLocation + ")");
		}

		//Looping through each building and assigning their resource
		for (int rep_building = 0; rep_building < its_scoped_buildings.Length; rep_building++)
		{
			if (its_scoped_buildings[rep_building].TheType != EBuilding.None)
				its_stream.WriteLine("\t\t(has-" + Building_To_String(its_scoped_buildings[rep_building].TheType) + " " + its_scoped_buildings[rep_building].TheName + ")");

			if (its_scoped_buildings[rep_building].TheResource != EResource.None)
				its_stream.WriteLine("\t\t(has-" + Resource_To_String(its_scoped_buildings[rep_building].TheResource) + " " + its_scoped_buildings[rep_building].TheName + ")");
		}

		//Set the number of each resource
		its_stream.WriteLine("\t\t(=(labourCost) " + "0" + ")");
		its_stream.WriteLine("\t\t(=(timber) " + my_resource_timber.ToString() + ")");
		its_stream.WriteLine("\t\t(=(wood) " + my_resource_wood.ToString() + ")");
		its_stream.WriteLine("\t\t(=(stone) " + my_resource_stone.ToString() + ")");
		its_stream.WriteLine("\t\t(=(coal) " + my_resource_coal.ToString() + ")");
		its_stream.WriteLine("\t\t(=(ore) " + my_resource_ore.ToString() + ")");
		its_stream.WriteLine("\t\t(=(iron) " + my_resource_iron.ToString() + ")");
		its_stream.WriteLine("\t\t(=(population) " + its_scoped_people.Length.ToString() + ")");

		//End the resource writing
		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Goal(StreamWriter its_stream, Goal its_goal)
	{
		its_stream.WriteLine("\t(:goal");
		its_stream.WriteLine("\t\t(and");

		//This will probably hold a list of conditions
		foreach (string rep_line in its_goal.Write_Goal())
		{
			its_stream.WriteLine("\t\t\t(" + rep_line + ")");
		}

		its_stream.WriteLine("\t\t\t)");
		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");

	}

	/// <summary>
	/// Writes the end of a file
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Outro(StreamWriter its_stream)
	{
		//First the top line
		its_stream.WriteLine(")");
	}
	
	public string Read_Solution(string its_filename)
	{
		return "";
	}
}
