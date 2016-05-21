public struct Agent
{
	public delegate void Event_Mission_Action(string[] its_actions);
	public delegate bool Event_Mission_Check(string[] its_actions);

	private Event_Mission_Action my_mission_start;
	private Event_Mission_Action my_mission_action;
	private Event_Mission_Action my_mission_complete;

	private Event_Mission_Check my_mission_check;



	public string[] TheActions;

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
        my_mission_start(TheActions);
	}
	
    /// <summary>
    /// A standard update of the agent, consistently calling the frame check
    /// </summary>
    /// <returns>If the agent is completed this frame</returns>
	public bool Call_Update()
	{
        my_mission_action(TheActions);
        if (my_mission_check(TheActions))
        {
            //Abort_Agent();
            Call_End();
            return true;
        }

        return false;
	}
	
	public void Call_End()
	{
        my_mission_complete(TheActions);
	}

}
