using System;
using JetBrains.Annotations;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
	public float pixelsPerUnit;
	public int zoom = 1;

	// TODO: Allow this script to auto access the actual pixels per unit.
	[UsedImplicitly] private void Start ()
	{
		UpdateSize();
	}

	private void UpdateSize ()
	{
		float size = Screen.height / pixelsPerUnit / zoom / 2f;

		// Always setting the size would make the scene constantly marked as dirty, only set if value has changed.
		if (Math.Abs (Camera.main.orthographicSize - size) > 0f) Camera.main.orthographicSize = size;
	}
}
