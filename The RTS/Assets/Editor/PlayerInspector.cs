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
				self.Set_New_Goal();
            }
        }
        
        serializedObject.ApplyModifiedProperties ();
	}
}
