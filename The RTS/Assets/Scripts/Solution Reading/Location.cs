using BlackTip;
using SandTiger;
using UnityEngine;

public class Location : MonoBehaviour
{
    public AgentMaster.Building TheSelf;

	private IVector2 _position = IVector2.zero;

    public int TheAlliance { get; private set; }

	void Awake()
    {
        TheSelf.TheName = gameObject.name.ToUpper();
    }

    public void SetTilePosition(IVector2 position)
    {
        _position = position;
        Rect tileBounds = TileMap.Self.GetTileBoundsWorld(position);
        transform.position = new Vector3(tileBounds.xMin, tileBounds.yMin + 1, transform.position.z);
    }
}
