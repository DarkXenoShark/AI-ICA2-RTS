using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (AgentMaster))]
public class AgentMasterInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		// Show original GUI.
		base.OnInspectorGUI();

		//if (Application.isEditor)
		if (Application.isPlaying)
		if (GUILayout.Button ("Make File"))
		{
			AgentMaster quick_self = (AgentMaster) target;
			AgentMaster.Write_Problem(quick_self.test_domain_name);
		}
	}
}
