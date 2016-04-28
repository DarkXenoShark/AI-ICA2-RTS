using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (TileMap))]
public class TileMapInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		// Show original GUI.
		base.OnInspectorGUI();

		if (GUILayout.Button ("Force Rebuild"))
		{
			TileMap tileMap = (TileMap) target;

			tileMap.GenerateMap();
		}
	}
}