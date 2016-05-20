using UnityEngine;
using System.Collections;

public class AgentCommandCompilation : MonoBehaviour
{

	// Use this for initialization
	void Start () 
    {
        Agent quick_agent = new Agent();
        quick_agent.Set_Agent(
            Agent_Simpletrain_Start,
            Agent_Simpletrain_Update,
            Agent_Simpletrain_End,
            Agent_Simpletrain_CompletedCheck
            );
        AgentMaster.Register_Agent_Type(quick_agent, "SIMPLETRAIN");
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

    private void Agent_Simpletrain_Start(string[] its_string)
    {

    }

    private void Agent_Simpletrain_Update(string[] its_string)
    {

    }

    private void Agent_Simpletrain_End(string[] its_string)
    {

    }

    private bool Agent_Simpletrain_CompletedCheck(string[] its_string)
    {
        return true;
    }
}
