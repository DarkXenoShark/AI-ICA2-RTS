using BlackTip;
using SandTiger;
using UnityEngine;

public class Location : MonoBehaviour
{
    public AgentMaster.Building TheSelf;

    public int TheAlliance { get; private set; }

	void Awake()
    {
        TheSelf.TheName = gameObject.name.ToUpper();
    }

	void Start()
	{
		SetTilePosition(new IVector2((int)transform.position.x, (int)transform.position.y));
	}

    public void SetTilePosition(IVector2 position)
    {
        Rect tileBounds = TileMap.Self.GetTileBoundsWorld(position);
        transform.position = new Vector3(tileBounds.xMin, tileBounds.yMin + 1, transform.position.z);
    }
}
