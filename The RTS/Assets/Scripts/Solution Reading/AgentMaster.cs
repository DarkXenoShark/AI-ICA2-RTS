using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AgentMaster : MonoBehaviour
{
	public static AgentMaster self;

	public int my_person_incriment;
	public int my_building_incriment;

	public string serialised_domain_name;

	public List<string> serialised_person_names;
	public List<EJob> serialised_person_jobs;
	public List<string> serialised_person_locations;

	public List<string> serialised_building_names;
	public List<EBuilding> serialised_building_types;
	public List<EResource> serialised_building_resources;

	/// <summary>
	/// Converts the serialised information into a struct array for reading
	/// </summary>
	/// <value>The people.</value>
	public Person[] People
	{
		get
		{
			Person[] returner = new Person[serialised_person_jobs.Count];
			for (int rep_person = 0; rep_person < serialised_person_jobs.Count; rep_person++)
			{
				returner[rep_person].TheName = serialised_person_names[rep_person];
				returner[rep_person].TheJob = serialised_person_jobs[rep_person];
				returner[rep_person].TheLocation = serialised_person_locations[rep_person];
			}

			return returner;
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
			Building[] returner = new Building[serialised_building_names.Count];
			for (int rep_building = 0; rep_building < serialised_building_names.Count; rep_building++)
			{
				returner[rep_building].TheName = serialised_building_names[rep_building];
				returner[rep_building].TheType = serialised_building_types[rep_building];
				returner[rep_building].TheResource = serialised_building_resources[rep_building];
			}
			
			return returner;
		}
	}

	public void Add_Person()
	{
		serialised_person_names.Add("Labourer" + (my_person_incriment++).ToString());
		serialised_person_jobs.Add(EJob.Unknown);
		serialised_person_locations.Add((serialised_building_names.Count >0)?
		                                serialised_building_names[0]:
		                                "");
	}

	public void Add_Building()
	{
		serialised_building_names.Add("Building" + (my_building_incriment++).ToString());
		serialised_building_types.Add(EBuilding.Unknown);
		serialised_building_resources.Add(EResource.None);
	}
	
	public void Pop_Person()
	{
		if (serialised_person_names.Count >0 )
		{
			serialised_person_names.RemoveAt(serialised_person_names.Count-1);
			serialised_person_jobs.RemoveAt(serialised_person_jobs.Count-1);
			serialised_person_locations.RemoveAt(serialised_person_locations.Count-1);
		}
	}

	public void Pop_Building()
	{
		if (serialised_building_names.Count >0 )
		{
			serialised_building_names.RemoveAt(serialised_building_names.Count-1);
			serialised_building_types.RemoveAt(serialised_building_types.Count-1);
			serialised_building_resources.RemoveAt(serialised_building_resources.Count-1);
		}
	}


	private List<Agent> my_active_agents;
	private TaskPlannerProcess my_planner;
	
	public struct Person
	{
		public string TheName;
		public EJob TheJob;
		public string TheLocation;
	}
	
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
		Unknown,
		Turfhut,
		House,
		School,
		Barracks,
		Storage,
		Mine,
		Smelter,
		Quary,
		Sawmill,
		Refinery,
		MarketStall
	}

	public enum EResource
	{
		None,
		Wood,
		Mineral
	}

	/// <summary>
	/// Converts an EJob to a string representation
	/// </summary>
	/// <returns>A string of the given EJob</returns>
	/// <param name="its_job">The job type to be converted to a string</param>
	public string Job_To_String(EJob its_job)
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
	public string Building_To_String(EBuilding its_building)
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
		case EBuilding.Mine:
			return "mine";
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
		serialised_building_resources = new List<EResource>();*/

		my_person_incriment = 0;
		my_building_incriment = 0;
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
	public static void Write_Problem(string its_file, Person[] its_scoped_people, Building[] its_scoped_buildings)
	{
		using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/Resources/" + its_file + "-problem.pddl"))
		{
			self.Problem_Writing_Intro(quick_writer, its_file, "prob1");
			self.Problem_Writing_Objects(quick_writer, its_scoped_people, its_scoped_buildings);
			self.Problem_Writing_Initialising(quick_writer, its_scoped_people, its_scoped_buildings);
			self.Problem_Writing_Goal(quick_writer);
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
			its_stream.WriteLine("\t\t" + its_scoped_buildings[rep_building].TheName + " - location");
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
			its_stream.WriteLine("\t\t(has-" + Building_To_String(its_scoped_buildings[rep_building].TheType) + " " + its_scoped_buildings[rep_building].TheName + ")");
		}

		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Goal(StreamWriter its_stream)
	{
		its_stream.WriteLine("\t(:goal");

		//This will probably hold a list of conditions

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
