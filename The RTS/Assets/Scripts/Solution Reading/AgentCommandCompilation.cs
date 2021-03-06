﻿using JetBrains.Annotations;
using SandTiger;
using UnityEngine;

public class AgentCommandCompilation : MonoBehaviour
{
	[UsedImplicitly] private void Start ()
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
	
	#region SIMPLETRAIN
	private static void Agent_Simpletrain_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[1]).SkillPoints++;
	}

	private static void Agent_Simpletrain_Update(string[] its_string)
	{

	}

	private static void Agent_Simpletrain_End(string[] its_string)
	{
		Debug.Log ("Added skill point to " + its_string[1] + " by " + its_string[0] + " at " + its_string[2]);
	}

	private static bool Agent_Simpletrain_CompletedCheck(string[] its_string)
	{
		return true;
	}
	#endregion

	#region SCHOOLTRAIN
	 private static void Agent_SchoolTrain_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Teacher);
	}

	private void Agent_SchoolTrain_Update(string[] its_string)
	{

	}

	private static void Agent_SchoolTrain_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[1] + " by " + its_string[0] + " at " + its_string[2]);
	}

	private static bool Agent_SchoolTrain_CompletedCheck(string[] its_string)
	{
		return true;
	}

	#endregion 

	#region TRAINCARPENTER
	 private static void Agent_TrainCarpenter_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Carpenter);
	}

	private static void Agent_TrainCarpenter_Update(string[] its_string)
	{

	}

	private static void Agent_TrainCarpenter_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a carpenter");
	}

	private static bool Agent_TrainCarpenter_CompletedCheck(string[] its_string)
	{
		return true;
	}

	#endregion 

	#region TRAINLUMBERJACK
	 private static void Agent_TrainLumberjack_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Lumberjack);
	}

	private static void Agent_TrainLumberjack_Update(string[] its_string)
	{

	}

	private static void Agent_TrainLumberjack_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a lumberjack");
	}

	private static bool Agent_TrainLumberjack_CompletedCheck(string[] its_string)
	{
		return true;
	}

	#endregion 

	#region TRAINMINER
	 private static void Agent_TrainMiner_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Miner);
	}

	private static void Agent_TrainMiner_Update(string[] its_string)
	{

	}

	private static void Agent_TrainMiner_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a miner");
	}

	private static bool Agent_TrainMiner_CompletedCheck(string[] its_string)
	{
		return true;
	}	

	#endregion 

	#region TRAINBLACKSMITH
	 private static void Agent_TrainBlacksmith_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Blacksmith);
	}

	private static void Agent_TrainBlacksmith_Update(string[] its_string)
	{

	}

	private static void Agent_TrainBlacksmith_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a blacksmith");
	}

	private static bool Agent_TrainBlacksmith_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region TRAINTEACHER
	 private static void Agent_TrainTeacher_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).Set_Job(AgentMaster.EJob.Teacher);
	}

	private static void Agent_TrainTeacher_Update(string[] its_string)
	{

	}

	private static void Agent_TrainTeacher_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a teacher");
	}

	private static bool Agent_TrainTeacher_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion

	#region TRAINRIFLEMAN
	 private static void Agent_TrainRifleman_Start(string[] its_string)
	{
		 GameMaster.Get_Person_By_Name(its_string[0]).SetSkill (PlayerBehaviour.ESkill.Rifleman);
	}

	private static void Agent_TrainRifleman_Update(string[] its_string)
	{

	}

	private static void Agent_TrainRifleman_End(string[] its_string)
	{

		Debug.Log ("Trained " + its_string[0] + " to be a riflemans");
	}

	private static bool Agent_TrainRifleman_CompletedCheck(string[] its_string)
	{
		return true;
	}	

	#endregion 
		
	#region MOVE
	private static void Agent_Move_Start (string[] its)
	{
		// 0 Who. 1 WhereAt. 2 WhereToo.
		IVector2 whereToo = (Vector2)GameMaster.Get_Location_By_Name(its[2]).transform.position;

		// Where to send him (this will run regardless of update).
		GameMaster.Get_Person_By_Name (its[0]).Go (whereToo);

		// Basically where he should be (Teleports).
		//player.SetTilePosition (whereAt); // We already know where we are at.
	}

	private static void Agent_Move_Update (string[] its)
	{
		
	}

	private static void Agent_Move_End(string[] its)
	{
		GameMaster.Get_Person_By_Name(its[0])._self.TheLocation = its[2];
		Debug.Log ("Moved " + its[0] + " to " + its[2]);
	}

	private static bool Agent_Move_CompletedCheck(string[] its)
	{
		return !GameMaster.Get_Person_By_Name(its[0]).IsPathing();
	}

	#endregion 

	#region CUTTREE
	 private static void Agent_CutTree_Start(string[] its_string)
	 {
		 GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource(AgentMaster.EResource.Timber);
		 GameMaster.Get_Location_By_Name(its_string[1]).SetResource(AgentMaster.EResource.None);
	 }

	private static void Agent_CutTree_Update(string[] its_string)
	{

	}

	private static void Agent_CutTree_End(string[] its_string)
	{

		Debug.Log ("Cut down " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_CutTree_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region SIMPLEMINEORE
	 private static void Agent_SimpleMineOre_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource(AgentMaster.EResource.Ore);
		//GameMaster.Get_Location_By_Name(its_string[1]).TheSelf.TheResource = AgentMaster.EResource.None;
	}

	private static void Agent_SimpleMineOre_Update(string[] its_string)
	{

	}

	private static void Agent_SimpleMineOre_End(string[] its_string)
	{

		Debug.Log ("Ored mine at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_SimpleMineOre_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region SIMPLEMINECOAL
	 private static void Agent_SimpleMineCoal_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource(AgentMaster.EResource.Coal);
		//GameMaster.Get_Location_By_Name(its_string[1]).TheSelf.TheResource = AgentMaster.EResource.None;
	}

	private static void Agent_SimpleMineCoal_Update(string[] its_string)
	{

	}

	private static void Agent_SimpleMineCoal_End(string[] its_string)
	{

		Debug.Log ("Stone mine at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_SimpleMineCoal_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region MINEOREWITHMINE
	private static void Agent_MineOreWithMine_Start(string[] its_string)
	{ }

	private static void Agent_MineOreWithMine_Update(string[] its_string)
	{ }

	private static void Agent_MineOreWithMine_End(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource (AgentMaster.EResource.Ore);
		Debug.Log ("Stone ored mine at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_MineOreWithMine_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region MINECOALWITHMINE
	 private static void Agent_MineCoalWithMine_Start(string[] its_string)
	{ }

	private static void Agent_MineCoalWithMine_Update(string[] its_string)
	{

	}

	private static void Agent_MineCoalWithMine_End(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource (AgentMaster.EResource.Coal);
		Debug.Log ("Stone mined mine at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_MineCoalWithMine_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region QUARRYSTONE
	private static void Agent_QuarryStone_Start(string[] its_string)
	{ }

	private static void Agent_QuarryStone_Update(string[] its_string)
	{ }

	private static void Agent_QuarryStone_End(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource (AgentMaster.EResource.Stone);
		Debug.Log ("Quarried stone at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_QuarryStone_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion

	#region SAWTIMBERATSAWMILL
	 private static void Agent_SawTimberAtSawmill_Start(string[] its_string)
	 {
		 GameMaster.Get_Person_By_Name(its_string[0]).Remove_Resource(AgentMaster.EResource.Timber);
	 }

	private static void Agent_SawTimberAtSawmill_Update(string[] its_string)
	{

	}

	private static void Agent_SawTimberAtSawmill_End(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource (AgentMaster.EResource.Wood);
		Debug.Log ("Sawn timber at " + its_string[1] + " by " + its_string[0]);
	}

	private static bool Agent_SawTimberAtSawmill_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion

	#region SMELTOREATSMELTER
	 private static void Agent_SmeltOreAtSmelter_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Remove_Resource(AgentMaster.EResource.Ore);
	}

	private static void Agent_SmeltOreAtSmelter_Update(string[] its_string)
	{

	}

	private static void Agent_SmeltOreAtSmelter_End(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Get_Resource (AgentMaster.EResource.Iron);
	}

	private static bool Agent_SmeltOreAtSmelter_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion

	#region MULTIPLYSINGLE
	private static void Agent_MultipleSingle_Start(string[] its_string)
	{
		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		 quick_player.Create_Person(its_string[2]);
	}

	private static void Agent_MultipleSingle_Update(string[] its_string)
	{ }

	private static void Agent_MultipleSingle_End(string[] its_string)
	{ }

	private static bool Agent_MultipleSingle_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region MULTIPLYDOUBLE
	private static void Agent_MultiplyDouble_Start(string[] its_string)
	{
		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		 quick_player.Create_Person(its_string[2]);
		 quick_player.Create_Person(its_string[2]);		
	}

	private static void Agent_MultiplyDouble_Update(string[] its_string)
	{ }

	private static void Agent_MultiplyDouble_End(string[] its_string)
	{ }

	private static bool Agent_MultiplyDouble_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STORETIMBER
	private static void Agent_GotTimber_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Timber);
	}

	private static void Agent_GotTimber_Update(string[] its_string)
	{

	}

	private static void Agent_GotTimber_End(string[] its_string)
	{

	}

	private static bool Agent_GotTimber_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STOREWOOD
	private static void Agent_GotWood_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Wood);
	}

	private static void Agent_GotWood_Update(string[] its_string)
	{

	}

	private static void Agent_GotWood_End(string[] its_string)
	{

	}

	private static bool Agent_GotWood_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STORESTONE
	private static void Agent_GotStone_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Stone);
	}

	private static void Agent_GotStone_Update(string[] its_string)
	{

	}

	private static void Agent_GotStone_End(string[] its_string)
	{

	}

	private static bool Agent_GotStone_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STOREORE
	private static void Agent_GotOre_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Ore);
	}

	private static void Agent_GotOre_Update(string[] its_string)
	{

	}

	private static void Agent_GotOre_End(string[] its_string)
	{

	}

	private static bool Agent_GotOre_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STORECOAL
	private static void Agent_GotCoal_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Coal);
	}

	private static void Agent_GotCoal_Update(string[] its_string)
	{

	}

	private static void Agent_GotCoal_End(string[] its_string)
	{

	}

	private static bool Agent_GotCoal_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region STOREIRON
	private static void Agent_GotIron_Start(string[] its_string)
	{
		GameMaster.Get_Person_By_Name(its_string[0]).Store_Resource (AgentMaster.EResource.Iron);
	}

	private static void Agent_GotIron_Update(string[] its_string)
	{

	}

	private static void Agent_GotIron_End(string[] its_string)
	{

	}

	private static bool Agent_GotIron_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDTURFHUT
	private static void Agent_BuildHut_Start(string[] its_string)
	{ }

	private static void Agent_BuildHut_Update(string[] its_string)
	{ }

	private static void Agent_BuildHut_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[1]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[1]).SetBuilding(AgentMaster.EBuilding.Turfhut);

	}

	private static bool Agent_BuildHut_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDHOUSE
	private static void Agent_BuildHouse_Start(string[] its_string)
	{ }

	private static void Agent_BuildHouse_Update(string[] its_string)
	{ }

	private static void Agent_BuildHouse_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[2]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[2]).SetBuilding(AgentMaster.EBuilding.House);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheWood--;
		quick_player.TheResources.TheStone--;
	}

	private static bool Agent_BuildHouse_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDSCHOOL
	private static void Agent_BuildSchool_Start(string[] its_string)
	{ }

	private static void Agent_BuildSchool_Update(string[] its_string)
	{ }

	private static void Agent_BuildSchool_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[2]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[2]).SetBuilding(AgentMaster.EBuilding.School);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheWood--;
		quick_player.TheResources.TheStone--;
	}

	private static bool Agent_BuildSchool_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDBARRACKS
	private static void Agent_BuildBarracks_Start(string[] its_string)
	{ }

	private static void Agent_BuildBarracks_Update(string[] its_string)
	{ }

	private static void Agent_BuildBarracks_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[2]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[2]).SetBuilding(AgentMaster.EBuilding.Barracks);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheWood--;
		quick_player.TheResources.TheStone--;
	}

	private static bool Agent_BuildBarracks_CompletedCheck(string[] its_string)
	{
		return true;
	}
	#endregion 

	#region BUILDSTORAGE
	private static void Agent_BuildStorage_Start(string[] its_string)
	{ }

	private static void Agent_BuildStorage_Update(string[] its_string)
	{ }

	private static void Agent_BuildStorage_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[2]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[2]).SetBuilding(AgentMaster.EBuilding.Storage);

		for (int rep_person = 0; rep_person < 2; rep_person++)
		{
			GameMaster.Get_Person_By_Name(its_string[rep_person]).Store_Resource(AgentMaster.EResource.Wood);
			GameMaster.Get_Person_By_Name(its_string[rep_person]).Store_Resource(AgentMaster.EResource.Stone);
		}
	}

	private static bool Agent_BuildStorage_CompletedCheck(string[] its_string)
	{
		return true;
	}
	#endregion 

	#region BUILDCOALMINE
	private static void Agent_BuildCoalMine_Start(string[] its_string)
	{ }

	private static void Agent_BuildCoalMine_Update(string[] its_string)
	{ }

	private static void Agent_BuildCoalMine_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[3]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[3]).SetBuilding(AgentMaster.EBuilding.Coalmine);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheWood--;
		quick_player.TheResources.TheIron--;
	}

	private static bool Agent_BuildCoalMine_CompletedCheck(string[] its_string)
	{
		return true;
	}			
	#endregion 

	#region BUILDOREMINE
	private static void Agent_BuildOreMine_Start(string[] its_string)
	{ }

	private static void Agent_BuildOreMine_Update(string[] its_string)
	{ }

	private static void Agent_BuildOreMine_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[3]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[3]).SetBuilding(AgentMaster.EBuilding.Oremine);
	
		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheWood--;
		quick_player.TheResources.TheIron--;
}

	private static bool Agent_BuildOreMine_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion

	#region BUILDSMELTER
	private static void Agent_BuildSmelter_Start(string[] its_string)
	{ }

	private static void Agent_BuildSmelter_Update(string[] its_string)
	{ }

	private static void Agent_BuildSmelter_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[1]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[1]).SetBuilding(AgentMaster.EBuilding.Smelter);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheStone--;
	}

	private static bool Agent_BuildSmelter_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDQUARRY
	private static void Agent_BuildQuarry_Start(string[] its_string)
	{ }

	private static void Agent_BuildQuarry_Update(string[] its_string)
	{ }

	private static void Agent_BuildQuarry_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[1]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[1]).SetBuilding(AgentMaster.EBuilding.Quary);
	}

	private static bool Agent_BuildQuarry_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDSAWMILL
	private static void Agent_BuildSawMill_Start(string[] its_string)
	{ }

	private static void Agent_BuildSawMill_Update(string[] its_string)
	{ }

	private static void Agent_BuildSawMill_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[1]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[1]).SetBuilding(AgentMaster.EBuilding.Sawmill);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheTimber--;
		quick_player.TheResources.TheIron--;
		quick_player.TheResources.TheStone--;
	}

	private static bool Agent_BuildSawMill_CompletedCheck(string[] its_string)
	{
		return true;
	}	
	#endregion 

	#region BUILDREFINERY
	private static void Agent_BuildRefinery_Start(string[] its_string)
	{ }

	private static void Agent_BuildRefinery_Update(string[] its_string)
	{ }

	private static void Agent_BuildRefinery_End(string[] its_string)
	{
		GameMaster.Get_Location_By_Name(its_string[1]).TheAlliance = GameMaster.Get_Person_By_Name(its_string[0])._alliance;
		GameMaster.Get_Location_By_Name(its_string[1]).SetBuilding(AgentMaster.EBuilding.Refinery);

		Player quick_player = GameMaster.Get_Player(GameMaster.Get_Person_By_Name(its_string[0])._alliance);
		quick_player.TheResources.TheTimber--;
		quick_player.TheResources.TheStone--;
		quick_player.TheResources.TheIron--;
	}

	private static bool Agent_BuildRefinery_CompletedCheck(string[] its_string)
	{
		return true;
	}		
	#endregion 
}