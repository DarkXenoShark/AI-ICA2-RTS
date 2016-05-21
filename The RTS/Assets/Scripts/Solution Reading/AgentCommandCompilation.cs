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
		
		quick_agent.Set_Agent(
            Agent_SchoolTrain_Start,
            Agent_SchoolTrain_Update,
            Agent_SchoolTrain_End,
            Agent_SchoolTrain_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "SCHOOLTRAIN");
		
		quick_agent.Set_Agent(
            Agent_TrainCarpenter_Start,
            Agent_TrainCarpenter_Update,
            Agent_TrainCarpenter_End,
            Agent_TrainCarpenter_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINCARPENTER");
		
		quick_agent.Set_Agent(
            Agent_TrainLumberjack_Start,
            Agent_TrainLumberjack_Update,
            Agent_TrainLumberjack_End,
            Agent_TrainLumberjack_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINLUMBERJACK");
		
		quick_agent.Set_Agent(
            Agent_TrainMiner_Start,
            Agent_TrainMiner_Update,
            Agent_TrainMiner_End,
            Agent_TrainMiner_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINMINER");
		
		quick_agent.Set_Agent(
            Agent_TrainBlacksmith_Start,
            Agent_TrainBlacksmith_Update,
            Agent_TrainBlacksmith_End,
            Agent_TrainBlacksmith_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINBLACKSMITH");
		
		quick_agent.Set_Agent(
            Agent_TrainTeacher_Start,
            Agent_TrainTeacher_Update,
            Agent_TrainTeacher_End,
            Agent_TrainTeacher_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINTEACHER");
		
		quick_agent.Set_Agent(
            Agent_TrainRifleman_Start,
            Agent_TrainRifleman_Update,
            Agent_TrainRifleman_End,
            Agent_TrainRifleman_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "TRAINRIFLEMAN");
		
		quick_agent.Set_Agent(
            Agent_Move_Start,
            Agent_Move_Update,
            Agent_Move_End,
            Agent_Move_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "MOVE");
		
		quick_agent.Set_Agent(
            Agent_CutTree_Start,
            Agent_CutTree_Update,
            Agent_CutTree_End,
            Agent_CutTree_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "CUTTREE");
		
		quick_agent.Set_Agent(
            Agent_SimpleMineOre_Start,
            Agent_SimpleMineOre_Update,
            Agent_SimpleMineOre_End,
            Agent_SimpleMineOre_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "SIMPLEMINEORE");
		
		quick_agent.Set_Agent(
            Agent_SimpleMineCoal_Start,
            Agent_SimpleMineCoal_Update,
            Agent_SimpleMineCoal_End,
            Agent_SimpleMineCoal_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "SIMPLEMINECOAL");
		
		quick_agent.Set_Agent(
            Agent_MineOreWithMine_Start,
            Agent_MineOreWithMine_Update,
            Agent_MineOreWithMine_End,
            Agent_MineOreWithMine_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "MINEOREWITHMINE");
		
		quick_agent.Set_Agent(
            Agent_MineCoalWithMine_Start,
            Agent_MineCoalWithMine_Update,
            Agent_MineCoalWithMine_End,
            Agent_MineCoalWithMine_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "MINECOALWITHMINE");
		
		quick_agent.Set_Agent(
            Agent_QuarryStone_Start,
            Agent_QuarryStone_Update,
            Agent_QuarryStone_End,
            Agent_QuarryStone_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "QUARRYSTONE");
		
		quick_agent.Set_Agent(
            Agent_SawTimberAtSawmill_Start,
            Agent_SawTimberAtSawmill_Update,
            Agent_SawTimberAtSawmill_End,
            Agent_SawTimberAtSawmill_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "SAWTIMBERATSAWMILL");
		
		quick_agent.Set_Agent(
            Agent_SmeltOreAtSmelter_Start,
            Agent_SmeltOreAtSmelter_Update,
            Agent_SmeltOreAtSmelter_End,
            Agent_SmeltOreAtSmelter_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "SMELTOREATSMELTER");
		
		quick_agent.Set_Agent(
            Agent_MultipleSingle_Start,
            Agent_MultipleSingle_Update,
            Agent_MultipleSingle_End,
            Agent_MultipleSingle_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "MULTIPLYSINGLE");
		
		quick_agent.Set_Agent(
            Agent_MultiplyDouble_Start,
            Agent_MultiplyDouble_Update,
            Agent_MultiplyDouble_End,
            Agent_MultiplyDouble_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "MULTIPLYDOUBLE");
		
		quick_agent.Set_Agent(
            Agent_GotTimber_Start,
            Agent_GotTimber_Update,
            Agent_GotTimber_End,
            Agent_GotTimber_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STORETIMBER");
		
		quick_agent.Set_Agent(
            Agent_GotWood_Start,
            Agent_GotWood_Update,
            Agent_GotWood_End,
            Agent_GotWood_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STOREWOOD");
		
		quick_agent.Set_Agent(
            Agent_GotStone_Start,
            Agent_GotStone_Update,
            Agent_GotStone_End,
            Agent_GotStone_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STORESTONE");
		
		quick_agent.Set_Agent(
            Agent_GotOre_Start,
            Agent_GotOre_Update,
            Agent_GotOre_End,
            Agent_GotOre_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STOREORE");
		
		quick_agent.Set_Agent(
            Agent_GotCoal_Start,
            Agent_GotCoal_Update,
            Agent_GotCoal_End,
            Agent_GotCoal_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STORECOAL");
		
		quick_agent.Set_Agent(
            Agent_GotIron_Start,
            Agent_GotIron_Update,
            Agent_GotIron_End,
            Agent_GotIron_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "STOREIRON");
		
		quick_agent.Set_Agent(
            Agent_BuildHut_Start,
            Agent_BuildHut_Update,
            Agent_BuildHut_End,
            Agent_BuildHut_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDTURFHUT");
		
		quick_agent.Set_Agent(
            Agent_BuildHouse_Start,
            Agent_BuildHouse_Update,
            Agent_BuildHouse_End,
            Agent_BuildHouse_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDHOUSE");
		
		quick_agent.Set_Agent(
            Agent_BuildSchool_Start,
            Agent_BuildSchool_Update,
            Agent_BuildSchool_End,
            Agent_BuildSchool_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDSCHOOL");
		
		quick_agent.Set_Agent(
            Agent_BuildBarracks_Start,
            Agent_BuildBarracks_Update,
            Agent_BuildBarracks_End,
            Agent_BuildBarracks_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDBARRACKS");
		
		quick_agent.Set_Agent(
            Agent_BuildStorage_Start,
            Agent_BuildStorage_Update,
            Agent_BuildStorage_End,
            Agent_BuildStorage_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDSTORAGE");
		
		quick_agent.Set_Agent(
            Agent_BuildCoalMine_Start,
            Agent_BuildCoalMine_Update,
            Agent_BuildCoalMine_End,
            Agent_BuildCoalMine_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDCOALMINE");
		
		quick_agent.Set_Agent(
            Agent_BuildOreMine_Start,
            Agent_BuildOreMine_Update,
            Agent_BuildOreMine_End,
            Agent_BuildOreMine_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDOREMINE");
		
		quick_agent.Set_Agent(
            Agent_BuildSmelter_Start,
            Agent_BuildSmelter_Update,
            Agent_BuildSmelter_End,
            Agent_BuildSmelter_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDSMELTER");
		
		quick_agent.Set_Agent(
            Agent_BuildQuarry_Start,
            Agent_BuildQuarry_Update,
            Agent_BuildQuarry_End,
            Agent_BuildQuarry_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDQUARRY");
		
		quick_agent.Set_Agent(
            Agent_BuildSawMill_Start,
            Agent_BuildSawMill_Update,
            Agent_BuildSawMill_End,
            Agent_BuildSawMill_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDSAWMILL");
		
		quick_agent.Set_Agent(
            Agent_BuildRefinery_Start,
            Agent_BuildRefinery_Update,
            Agent_BuildRefinery_End,
            Agent_BuildRefinery_CompletedCheck
            );
		AgentMaster.Register_Agent_Type(quick_agent, "BUILDREFINERY");
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
	#region SIMPLETRAIN
    private void Agent_Simpletrain_Start(string[] its_string)
    {

    }

    private void Agent_Simpletrain_Update(string[] its_string)
    {

    }

    private void Agent_Simpletrain_End(string[] its_string)
    {
		Debug.Log ("Trained " + its_string[1] + " by " + its_string[0] + " at " + its_string[2]);
    }

    private bool Agent_Simpletrain_CompletedCheck(string[] its_string)
    {
        return true;
    }
	#endregion

	#region SCHOOLTRAIN
	 private void Agent_SchoolTrain_Start(string[] its_string)
    {

    }

    private void Agent_SchoolTrain_Update(string[] its_string)
    {

    }

    private void Agent_SchoolTrain_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[1] + " by " + its_string[0] + " at " + its_string[2]);
	}

    private bool Agent_SchoolTrain_CompletedCheck(string[] its_string)
    {
        return true;
    }

	#endregion 

	#region TRAINCARPENTER
	 private void Agent_TrainCarpenter_Start(string[] its_string)
    {

    }

    private void Agent_TrainCarpenter_Update(string[] its_string)
    {

    }

    private void Agent_TrainCarpenter_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a carpenter");
	}

    private bool Agent_TrainCarpenter_CompletedCheck(string[] its_string)
    {
        return true;
    }

	#endregion 

	#region TRAINLUMBERJACK
	 private void Agent_TrainLumberjack_Start(string[] its_string)
    {

    }

    private void Agent_TrainLumberjack_Update(string[] its_string)
    {

    }

    private void Agent_TrainLumberjack_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a lumberjack");
	}

    private bool Agent_TrainLumberjack_CompletedCheck(string[] its_string)
    {
        return true;
    }

	#endregion 

	#region TRAINMINER
	 private void Agent_TrainMiner_Start(string[] its_string)
    {

    }

    private void Agent_TrainMiner_Update(string[] its_string)
    {

    }

    private void Agent_TrainMiner_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a miner");
	}

    private bool Agent_TrainMiner_CompletedCheck(string[] its_string)
    {
        return true;
    }	

	#endregion 

	#region TRAINBLACKSMITH
	 private void Agent_TrainBlacksmith_Start(string[] its_string)
    {

    }

    private void Agent_TrainBlacksmith_Update(string[] its_string)
    {

    }

    private void Agent_TrainBlacksmith_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a blacksmith");
	}

    private bool Agent_TrainBlacksmith_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region TRAINTEACHER
	 private void Agent_TrainTeacher_Start(string[] its_string)
    {

    }

    private void Agent_TrainTeacher_Update(string[] its_string)
    {

    }

    private void Agent_TrainTeacher_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a teacher");
	}

    private bool Agent_TrainTeacher_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion

	#region TRAINRIFLEMAN
	 private void Agent_TrainRifleman_Start(string[] its_string)
    {

    }

    private void Agent_TrainRifleman_Update(string[] its_string)
    {

    }

    private void Agent_TrainRifleman_End(string[] its_string)
    {

		Debug.Log ("Trained " + its_string[0] + " to be a riflemans");
	}

    private bool Agent_TrainRifleman_CompletedCheck(string[] its_string)
    {
        return true;
    }	

	#endregion 

			
	#region MOVE
	 private void Agent_Move_Start(string[] its_string)
    {
		
    }

    private void Agent_Move_Update(string[] its_string)
    {

    }

    private void Agent_Move_End(string[] its_string)
    {

		Debug.Log ("Moved " + its_string[0] + " to " + its_string[1]);
	}

    private bool Agent_Move_CompletedCheck(string[] its_string)
    {
        return true;
    }	

	#endregion 

	#region CUTTREE
	 private void Agent_CutTree_Start(string[] its_string)
    {
		
    }

    private void Agent_CutTree_Update(string[] its_string)
    {

    }

    private void Agent_CutTree_End(string[] its_string)
    {

		Debug.Log ("Cut down " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_CutTree_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region SIMPLEMINEORE
	 private void Agent_SimpleMineOre_Start(string[] its_string)
    {
		
    }

    private void Agent_SimpleMineOre_Update(string[] its_string)
    {

    }

    private void Agent_SimpleMineOre_End(string[] its_string)
    {

		Debug.Log ("Ored mine at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_SimpleMineOre_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region SIMPLEMINECOAL
	 private void Agent_SimpleMineCoal_Start(string[] its_string)
    {
		
    }

    private void Agent_SimpleMineCoal_Update(string[] its_string)
    {

    }

    private void Agent_SimpleMineCoal_End(string[] its_string)
    {

		Debug.Log ("Stone mine at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_SimpleMineCoal_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region MINEOREWITHMINE
	 private void Agent_MineOreWithMine_Start(string[] its_string)
    {
		
    }

    private void Agent_MineOreWithMine_Update(string[] its_string)
    {

    }

    private void Agent_MineOreWithMine_End(string[] its_string)
    {
		Debug.Log ("Stone ored mine at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_MineOreWithMine_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region MINECOALWITHMINE
	 private void Agent_MineCoalWithMine_Start(string[] its_string)
    {
		
    }

    private void Agent_MineCoalWithMine_Update(string[] its_string)
    {

    }

    private void Agent_MineCoalWithMine_End(string[] its_string)
    {

		Debug.Log ("Stone mined mine at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_MineCoalWithMine_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region QUARRYSTONE
	 private void Agent_QuarryStone_Start(string[] its_string)
    {
		
    }

    private void Agent_QuarryStone_Update(string[] its_string)
    {

    }

    private void Agent_QuarryStone_End(string[] its_string)
    {

		Debug.Log ("Quarried stone at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_QuarryStone_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion

	#region SAWTIMBERATSAWMILL
	 private void Agent_SawTimberAtSawmill_Start(string[] its_string)
    {
		
    }

    private void Agent_SawTimberAtSawmill_Update(string[] its_string)
    {

    }

    private void Agent_SawTimberAtSawmill_End(string[] its_string)
    {

		Debug.Log ("Quarried stone at " + its_string[1] + " by " + its_string[0]);
	}

    private bool Agent_SawTimberAtSawmill_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion

	#region SMELTOREATSMELTER
	 private void Agent_SmeltOreAtSmelter_Start(string[] its_string)
    {
		
    }

    private void Agent_SmeltOreAtSmelter_Update(string[] its_string)
    {

    }

    private void Agent_SmeltOreAtSmelter_End(string[] its_string)
    {

    }

    private bool Agent_SmeltOreAtSmelter_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion

	#region MULTIPLYSINGLE
	 private void Agent_MultipleSingle_Start(string[] its_string)
    {
		
    }

    private void Agent_MultipleSingle_Update(string[] its_string)
    {

    }

    private void Agent_MultipleSingle_End(string[] its_string)
    {

    }

    private bool Agent_MultipleSingle_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region MULTIPLYDOUBLE
	 private void Agent_MultiplyDouble_Start(string[] its_string)
    {
		
    }

    private void Agent_MultiplyDouble_Update(string[] its_string)
    {

    }

    private void Agent_MultiplyDouble_End(string[] its_string)
    {

    }

    private bool Agent_MultiplyDouble_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STORETIMBER
	 private void Agent_GotTimber_Start(string[] its_string)
    {
		
    }

    private void Agent_GotTimber_Update(string[] its_string)
    {

    }

    private void Agent_GotTimber_End(string[] its_string)
    {

    }

    private bool Agent_GotTimber_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STOREWOOD
	 private void Agent_GotWood_Start(string[] its_string)
    {
		
    }

    private void Agent_GotWood_Update(string[] its_string)
    {

    }

    private void Agent_GotWood_End(string[] its_string)
    {

    }

    private bool Agent_GotWood_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STORESTONE
	 private void Agent_GotStone_Start(string[] its_string)
    {
		
    }

    private void Agent_GotStone_Update(string[] its_string)
    {

    }

    private void Agent_GotStone_End(string[] its_string)
    {

    }

    private bool Agent_GotStone_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STOREORE
	 private void Agent_GotOre_Start(string[] its_string)
    {
		
    }

    private void Agent_GotOre_Update(string[] its_string)
    {

    }

    private void Agent_GotOre_End(string[] its_string)
    {

    }

    private bool Agent_GotOre_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STORECOAL
	 private void Agent_GotCoal_Start(string[] its_string)
    {
		
    }

    private void Agent_GotCoal_Update(string[] its_string)
    {

    }

    private void Agent_GotCoal_End(string[] its_string)
    {

    }

    private bool Agent_GotCoal_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region STOREIRON
	 private void Agent_GotIron_Start(string[] its_string)
    {
		
    }

    private void Agent_GotIron_Update(string[] its_string)
    {

    }

    private void Agent_GotIron_End(string[] its_string)
    {

    }

    private bool Agent_GotIron_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDTURFHUT
	 private void Agent_BuildHut_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildHut_Update(string[] its_string)
    {

    }

    private void Agent_BuildHut_End(string[] its_string)
    {

    }

    private bool Agent_BuildHut_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDHOUSE
	 private void Agent_BuildHouse_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildHouse_Update(string[] its_string)
    {

    }

    private void Agent_BuildHouse_End(string[] its_string)
    {

    }

    private bool Agent_BuildHouse_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDSCHOOL
	 private void Agent_BuildSchool_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildSchool_Update(string[] its_string)
    {

    }

    private void Agent_BuildSchool_End(string[] its_string)
    {

    }

    private bool Agent_BuildSchool_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDBARRACKS
	 private void Agent_BuildBarracks_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildBarracks_Update(string[] its_string)
    {

    }

    private void Agent_BuildBarracks_End(string[] its_string)
    {

    }

    private bool Agent_BuildBarracks_CompletedCheck(string[] its_string)
    {
        return true;
    }
	#endregion 

	#region BUILDSTORAGE
	 private void Agent_BuildStorage_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildStorage_Update(string[] its_string)
    {

    }

    private void Agent_BuildStorage_End(string[] its_string)
    {

    }

    private bool Agent_BuildStorage_CompletedCheck(string[] its_string)
    {
        return true;
    }
	#endregion 

	#region BUILDCOALMINE
	 private void Agent_BuildCoalMine_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildCoalMine_Update(string[] its_string)
    {

    }

    private void Agent_BuildCoalMine_End(string[] its_string)
    {

    }

    private bool Agent_BuildCoalMine_CompletedCheck(string[] its_string)
    {
        return true;
    }			
	#endregion 

	#region BUILDOREMINE
	 private void Agent_BuildOreMine_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildOreMine_Update(string[] its_string)
    {

    }

    private void Agent_BuildOreMine_End(string[] its_string)
    {

    }

    private bool Agent_BuildOreMine_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion

	#region BUILDSMELTER
	 private void Agent_BuildSmelter_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildSmelter_Update(string[] its_string)
    {

    }

    private void Agent_BuildSmelter_End(string[] its_string)
    {

    }

    private bool Agent_BuildSmelter_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDQUARRY
	 private void Agent_BuildQuarry_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildQuarry_Update(string[] its_string)
    {

    }

    private void Agent_BuildQuarry_End(string[] its_string)
    {

    }

    private bool Agent_BuildQuarry_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDSAWMILL
	 private void Agent_BuildSawMill_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildSawMill_Update(string[] its_string)
    {

    }

    private void Agent_BuildSawMill_End(string[] its_string)
    {

    }

    private bool Agent_BuildSawMill_CompletedCheck(string[] its_string)
    {
        return true;
    }	
	#endregion 

	#region BUILDREFINERY
	 private void Agent_BuildRefinery_Start(string[] its_string)
    {
		
    }

    private void Agent_BuildRefinery_Update(string[] its_string)
    {

    }

    private void Agent_BuildRefinery_End(string[] its_string)
    {

    }

    private bool Agent_BuildRefinery_CompletedCheck(string[] its_string)
    {
        return true;
    }		
	#endregion 
}
