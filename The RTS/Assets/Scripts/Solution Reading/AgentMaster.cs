using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AgentMaster : MonoBehaviour
{
	public static AgentMaster self;

	public string test_domain_name;

	private List<Agent> my_active_agents;
	private TaskPlannerProcess my_planner;
	//private MapParser my_raw_solution;

	//public 

	void Awake()
	{
		self = this;
		my_active_agents = new List<Agent>();
		my_planner = GetComponent<TaskPlannerProcess>();
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
	public static void Write_Problem(string its_file)
	{
		using (StreamWriter quick_writer = File.CreateText(Application.dataPath + "/Resources/" + its_file + "-problem.pddl"))
		{
			self.Problem_Writing_Intro(quick_writer,its_file,"prob1");
			self.Problem_Writing_Objects(quick_writer);
			self.Problem_Writing_Initialising(quick_writer);
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
	private void Problem_Writing_Objects(StreamWriter its_stream)
	{
		its_stream.WriteLine("\t(:objects");

		//Looping through people, blah blah blah

		//Looping through mining resources, blah blah blah

		its_stream.WriteLine("\t\t)");
		its_stream.WriteLine("");
	}
	
	/// <summary>
	/// Writes the static header for problem files to the stream
	/// </summary>
	/// <param name="its_stream">The given stream to write to.</param>
	/// <param name="its_problem_name">The problem name that's on top of the files.</param>
	private void Problem_Writing_Initialising(StreamWriter its_stream)
	{
		its_stream.WriteLine("\t(:init");

		//Looping through people locations, blah blah blah

		//Looping through mining resources hold what, blah blah blah

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
