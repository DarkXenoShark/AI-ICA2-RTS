using System;
using System.Collections.Generic;
using BlackTip;
using JetBrains.Annotations;
using SandTiger;
using UnityEngine;

public class Location : MonoBehaviour
{
	[SerializeField] private List<Sprite> _sprites = null;
	private SpriteRenderer _SR = null;
	
	public AgentMaster.Building TheSelf;

	public int TheAlliance { get; set; }

	[UsedImplicitly] void Awake()
	{
		TheAlliance		= -1;
        TheSelf.TheName	= gameObject.name.ToUpper();

		_SR = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		SetTilePosition(new IVector2(transform.position));
		SetTileRenderer();
	}

    public void SetTilePosition (IVector2 position)
    {
        Rect tileBounds = TileMap.Self.GetTileBoundsWorld (position);
        transform.position = new Vector3 (tileBounds.xMin, tileBounds.yMin + 1, transform.position.z);
    }

	public void SetResource(AgentMaster.EResource its_resource)
	{
		TheSelf.TheResource = its_resource;
		SetTileRenderer();
	}

	public void SetBuilding(AgentMaster.EBuilding its_building)
	{
		TheSelf.TheType = its_building;

		SetTileRenderer();
	}

	public void SetPermeability()
	{
		if (TheSelf.TheType == AgentMaster.EBuilding.None &&
		    TheSelf.TheResource == AgentMaster.EResource.None)
		{
			Level.Self.SetTile((int) transform.position.x, (int) transform.position.y, TileType.GRASS);
		}
		else
			Level.Self.SetTile((int) transform.position.x, (int) transform.position.y, TileType.OUT_BOUNDS);
	}

	public void SetTileRenderer ()
	{
		// First 6 = Resource
		// Other 12 = Buildings
		SetPermeability();

		if (_SR == null) return;
		if (_sprites == null || _sprites.Count < 0) return;

		if (TheSelf.TheType != AgentMaster.EBuilding.None)
		{
			_SR.sprite = _sprites[(int) TheSelf.TheType + 5];
			return;
		}

		if (TheSelf.TheResource != AgentMaster.EResource.None)
		{
			_SR.sprite = _sprites[(int) TheSelf.TheResource-1];
			return;
		}


		_SR.sprite = null;
	}
}
