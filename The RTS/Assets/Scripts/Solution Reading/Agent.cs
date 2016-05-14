using UnityEngine;
using System.Collections;

public class Agent
{
	public delegate void Event_Mission_Action(params string[] its_actions);
	public delegate bool Event_Mission_Check(params string[] its_actions);

	private Event_Mission_Action my_mission_start;
	private Event_Mission_Action my_mission_action;
	private Event_Mission_Action my_mission_complete;

	private Event_Mission_Check my_mission_check;



	public string[] my_agent_actions;

	public void Set_Agent(Event_Mission_Action its_start_action,
	                      Event_Mission_Action its_during_action,
	                      Event_Mission_Action its_complete_action,
	                      Event_Mission_Check its_complete_check)
	{
		my_mission_start = its_start_action;
		my_mission_action = its_during_action;
		my_mission_complete = its_complete_action;
		my_mission_check = its_complete_check;
	}

	public void Start_Agent()
	{
		AgentMaster.Add_Agent(this);
	}

	public void Abort_Agent()
	{
		AgentMaster.Abort_Agent(this);
	}

	public void Call_Start()
	{
		my_mission_start(my_agent_actions);
	}
	
	public void Call_Update()
	{
		my_mission_action(my_agent_actions);
		if (my_mission_check(my_agent_actions))
			Abort_Agent();
	}
	
	public void Call_End()
	{
		my_mission_complete(my_agent_actions);
	}

	public Agent()
	{
	}
}
