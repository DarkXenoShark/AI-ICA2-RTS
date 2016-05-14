using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentMaster : MonoBehaviour
{
	public static AgentMaster self;

	private List<Agent> my_active_agents;

	//public 

	void Awake()
	{
		self = this;
		my_active_agents = new List<Agent>();
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

	public string Read_Solution(string its_filename)
	{

	}
}
