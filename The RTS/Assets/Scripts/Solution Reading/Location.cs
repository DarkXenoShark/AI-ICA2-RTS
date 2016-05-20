using UnityEngine;
using System.Collections;

using BlackTip;
using SandTiger;

public class Location : MonoBehaviour
{
    public AgentMaster.Building TheSelf;
    private int my_alliance;

    private IVector2 _position = IVector2.zero;

    public int TheAlliance
    {
        get
        {
            return my_alliance;
        }
    }
    
    void Awake()
    {
        TheSelf.TheName = gameObject.name;
        //SetTilePosition(new IVector2((int) gameObject.transform.position.x,(int)gameObject.transform.position.y));
    }

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    public void SetTilePosition(IVector2 position)
    {
        _position = position;
        Rect tileBounds = TileMap.Self.GetTileBoundsWorld(position);
        transform.position = new Vector3(tileBounds.xMin, tileBounds.yMin + 1, transform.position.z);
    }
}
