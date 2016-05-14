using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (AgentMaster))]
public class AgentMasterInspector : Editor
{
	//Creation of editor object
	private AgentMaster self;
	
	//The various display properties
	private SerializedProperty property_domain;

	private SerializedProperty property_person_names;
	private SerializedProperty property_person_jobs;
	private SerializedProperty property_person_locations;

	private SerializedProperty property_building_names;
	private SerializedProperty property_building_types;
	private SerializedProperty property_building_resources;

	void OnEnable()
	{
		self = (AgentMaster)target;

		property_domain = serializedObject.FindProperty("serialised_domain_name");

		property_person_names = serializedObject.FindProperty("serialised_person_names");
		property_person_jobs = serializedObject.FindProperty("serialised_person_jobs");
		property_person_locations = serializedObject.FindProperty("serialised_person_locations");
		
		property_building_names = serializedObject.FindProperty("serialised_building_names");
		property_building_types = serializedObject.FindProperty("serialised_building_types");
		property_building_resources = serializedObject.FindProperty("serialised_building_resources");
	}

	public override void OnInspectorGUI ()
	{
		// Show original GUI.
		//base.OnInspectorGUI();
		serializedObject.Update ();

		property_domain.stringValue = EditorGUILayout.TextField("File Name", property_domain.stringValue);

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


		EditorGUILayout.LabelField("");


		//EditorEditor

		if (Application.isEditor)
		{
			if (GUILayout.Button ("Reset Incriment"))
			{
				self.my_person_incriment = 0;
				self.my_building_incriment = 0;
			}
		}

		if (Application.isPlaying)
		{
			if (GUILayout.Button ("Make File"))
			{
				AgentMaster.Write_Problem(property_domain.stringValue, self.People, self.Buildings);
			}

			if (GUILayout.Button ("Start Task Planner"))
			{
				self.gameObject.GetComponent<TaskPlannerProcess>().CallStart();
			}
		}

		serializedObject.ApplyModifiedProperties ();
	}
}
