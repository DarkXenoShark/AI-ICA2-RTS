using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]
public class PlayerInspector : Editor
{
    Player self;

    void OnEnable()
    {
        self = (Player)target;
    }

    public override void OnInspectorGUI()
    {
        // Show original GUI.
        base.OnInspectorGUI();
        serializedObject.Update();

        if (Application.isPlaying)
        {
            if (GUILayout.Button("Do...Something"))
            {
                AgentMaster.BuildingGoal quick_goal = new AgentMaster.BuildingGoal();
                quick_goal.TheBuilding = (AgentMaster.EBuilding.Storage);
                quick_goal.TheDestination = self.Get_First_Empty_Loaction();

                AgentMaster.Write_Problem(
                    "rts", 
                    self.TheResources,
                    AgentMaster.Convert_PlayerBehaviour_To_People(self.my_people.ToArray()), 
                    AgentMaster.Convert_Locations_To_Building(GameMaster.Get_Locations_Of_Player(self.TheAlliance)), 
                    quick_goal);
                AgentMaster.Call_Start();
                foreach (AgentMaster.AgentCommands rep_string in AgentMaster.Get_Generated_Plan())
                {
                    Debug.Log(rep_string.TheAgentName);
                }
                
            }
        }
        
        serializedObject.ApplyModifiedProperties ();
	}
}
