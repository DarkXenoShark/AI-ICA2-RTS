using UnityEngine;

// Required components to use this script.
[RequireComponent (typeof (TileMap))]

public class TileMapInterface : MonoBehaviour
{
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (GetComponent<Collider>().Raycast (ray, out hitInfo, Mathf.Infinity))
		{
			//transform.worldToLocalMatrix * hitInfo.point;
		}
	}
}