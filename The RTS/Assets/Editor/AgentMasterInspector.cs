using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (AgentMaster))]
public class AgentMasterInspector : Editor
{
	//Creation of editor object
	private AgentMaster self;
	
	//The various display properties
	//private SerializedProperty property_domain;

	/*private SerializedProperty property_person_names;
	private SerializedProperty property_person_jobs;
	private SerializedProperty property_person_locations;

	private SerializedProperty property_building_names;
	private SerializedProperty property_building_types;
	private SerializedProperty property_building_resources;

	private SerializedProperty property_resource_timber;
	private SerializedProperty property_resource_wood;
	private SerializedProperty property_resource_stone;
	private SerializedProperty property_resource_ore;
	private SerializedProperty property_resource_coal;
	private SerializedProperty property_resource_iron;*/

	private SerializedProperty property_goal_building;
	private SerializedProperty property_goal_destination;

	void OnEnable()
	{
		self = (AgentMaster)target;

		property_goal_building = serializedObject.FindProperty("serialized_goal_building");
		property_goal_destination = serializedObject.FindProperty("serialized_goal_destination");

		//property_domain = serializedObject.FindProperty("serialised_domain_name");

		/*property_person_names = serializedObject.FindProperty("serialised_person_names");
		property_person_jobs = serializedObject.FindProperty("serialised_person_jobs");
		property_person_locations = serializedObject.FindProperty("serialised_person_locations");
		
		property_building_names = serializedObject.FindProperty("serialised_building_names");
		property_building_types = serializedObject.FindProperty("serialised_building_types");
		property_building_resources = serializedObject.FindProperty("serialised_building_resources");

		property_resource_timber = serializedObject.FindProperty("my_resource_timber");
		property_resource_wood = serializedObject.FindProperty("my_resource_wood");
		property_resource_stone = serializedObject.FindProperty("my_resource_stone");
		property_resource_ore = serializedObject.FindProperty("my_resource_ore");
		property_resource_coal = serializedObject.FindProperty("my_resource_coal");
		property_resource_iron = serializedObject.FindProperty("my_resource_iron");*/
		//serializedObject.
	}

	public override void OnInspectorGUI ()
	{
		// Show original GUI.
		base.OnInspectorGUI();
		serializedObject.Update ();

		/*property_domain.stringValue = EditorGUILayout.TextField("File Name", property_domain.stringValue);


		EditorGUILayout.LabelField("");


		property_resource_timber.intValue = EditorGUILayout.IntField("Timber Owned", property_resource_timber.intValue);
		property_resource_wood.intValue = EditorGUILayout.IntField("Wood Owned", property_resource_wood.intValue);
		property_resource_stone.intValue = EditorGUILayout.IntField("Stone Owned", property_resource_stone.intValue);
		property_resource_ore.intValue = EditorGUILayout.IntField("Ore Owned", property_resource_ore.intValue);
		property_resource_coal.intValue = EditorGUILayout.IntField("Coal Owned", property_resource_coal.intValue);
		property_resource_iron.intValue = EditorGUILayout.IntField("Iron Owned", property_resource_iron.intValue);

		//Read all labourers
		EditorGUILayout.LabelField("Labourers");
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Name");
		EditorGUILayout.LabelField("Job");
		EditorGUILayout.LabelField("Location");
		EditorGUILayout.EndHorizontal();

		for (int rep_person = 0; rep_person < property_person_names.arraySize; rep_person++)
		{
			EditorGUILayout.BeginHorizontal();
			property_person_names.GetArrayElementAtIndex(rep_person).stringValue = EditorGUILayout.TextField(property_person_names.GetArrayElementAtIndex(rep_person).stringValue);
			property_person_jobs.GetArrayElementAtIndex(rep_person).enumValueIndex = (int)(AgentMaster.EJob)EditorGUILayout.EnumPopup((AgentMaster.EJob)property_person_jobs.GetArrayElementAtIndex(rep_person).enumValueIndex);
			property_person_locations.GetArrayElementAtIndex(rep_person).stringValue = EditorGUILayout.TextField(property_person_locations.GetArrayElementAtIndex(rep_person).stringValue);
			EditorGUILayout.EndHorizontal();
		}

		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("+"))
			self.Add_Person();
		if (GUILayout.Button("-"))
			self.Pop_Person();
		EditorGUILayout.EndHorizontal();


		EditorGUILayout.LabelField("");


		//EditorGUILayout.

		//Read all buildings
		EditorGUILayout.LabelField("Buildings");
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Name");
		EditorGUILayout.LabelField("Type");
		EditorGUILayout.LabelField(">Unsused<");
		EditorGUILayout.EndHorizontal();
		
		for (int rep_person = 0; rep_person < property_building_names.arraySize; rep_person++)
		{
			EditorGUILayout.BeginHorizontal();
			property_building_names.GetArrayElementAtIndex(rep_person).stringValue = EditorGUILayout.TextField(property_building_names.GetArrayElementAtIndex(rep_person).stringValue);
			property_building_types.GetArrayElementAtIndex(rep_person).enumValueIndex = (int)(AgentMaster.EBuilding)EditorGUILayout.EnumPopup((AgentMaster.EBuilding)property_building_types.GetArrayElementAtIndex(rep_person).enumValueIndex);
			property_building_resources.GetArrayElementAtIndex(rep_person).enumValueIndex = (int)(AgentMaster.EResource)EditorGUILayout.EnumPopup((AgentMaster.EResource)property_building_resources.GetArrayElementAtIndex(rep_person).enumValueIndex);
			EditorGUILayout.EndHorizontal();
		}
		
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("+"))
			self.Add_Building();
		if (GUILayout.Button("-"))
			self.Pop_Building();
		EditorGUILayout.EndHorizontal();


		EditorGUILayout.LabelField("");*/

		
		//Now the goal area
		//EditorGUILayout.EnumPopup("Goal",);
		//switch ()



		if (Application.isEditor)
		{
			/*if (GUILayout.Button ("Reset Incriment"))
			{
				self.my_person_incriment = 0;
				self.my_building_incriment = 0;
			}*/
		}

		if (Application.isPlaying)
		{
			if (GUILayout.Button ("Make File"))
			{
				AgentMaster.BuildingGoal quick_goal = new AgentMaster.BuildingGoal();
				quick_goal.TheBuilding = (AgentMaster.EBuilding)property_goal_building.enumValueIndex;
				quick_goal.TheDestination = property_goal_destination.stringValue;

				AgentMaster.Write_Problem(self.Domain, self.People, self.Buildings, quick_goal);
			}

			if (GUILayout.Button ("Start Task Planner"))
			{
				self.gameObject.GetComponent<TaskPlannerProcess>().CallStart();
			}
		}

		serializedObject.ApplyModifiedProperties ();
	}
}
