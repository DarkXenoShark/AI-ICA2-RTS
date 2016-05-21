using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BlackTip;
using JetBrains.Annotations;
using SandTiger;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	[SerializeField] private bool _overridable = false;

    public AgentMaster.Person _self;

	private TileMap _tileMap	= null;
	private Level _level		= null;
	private IVector2 _position	= IVector2.zero;
	private bool _walking		= false;
    [SerializeField] private float _speed = 0.1f;

    private void Awake()
    {
        _self.TheName = gameObject.name.ToUpper();
    }

	 [UsedImplicitly] private void Start ()
	{
		GameObject tileMapGameObject = GameObject.Find("TileMap");

		_tileMap	= tileMapGameObject.GetComponent<TileMap>();
		_level		= tileMapGameObject.GetComponent<Level>();

		if (_tileMap == null) Debug.LogError ("TileMapBehaviour not found");
		if (_level == null) Debug.LogError ("LevelBehaviour not found");
	}

	public void Go (IVector2 destination)
	{
		if (_walking) return;
		_walking = true;
        StartCoroutine (WalkTo (destination, _speed));
	}

	// TODO refactor into a reusable "TileWalker" behaviour
	private IEnumerator WalkTo (IVector2 destination, float stepIntervalSeconds)
	{
		if (Level.Self.IsWalkeable (destination.x, destination.y))
		{
            AStar astar = new AStar(Level.Self);
			List <IVector2> path	= astar.Search (_position, destination).ToList();

			if (path.Count == 0)
			{
				Debug.Log ("No path found");
				_walking = false;
				yield break;
			}

			foreach (IVector2 node in path)
			{
				SetTilePosition (node);
				yield return new WaitForSeconds (stepIntervalSeconds);
			}
		}

		_walking = false;
	}

	public bool IsPathing ()
	{
		return _walking;
	}

	public void SetTilePosition (IVector2 position)
	{
		_position = position;
        Rect tileBounds = TileMap.Self.GetTileBoundsWorld(position);
		transform.position = new Vector3(tileBounds.xMin, tileBounds.yMin + 1, transform.position.z);
	}
	
	private class AStarGrid : IAStar<IVector2>
	{
		public virtual int HeuristicCostEstimate(IVector2 a, IVector2 b)
		{
			return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
		}

		public virtual IEnumerable<IVector2> GetNeighbourNodes(IVector2 node)
		{
			for (int y = -1; y <= 1; y++)
			{
				for (int x = -1; x <= 1; x++)
					yield return new IVector2(node.x + x, node.y + y);
			}
		}
	}

	private class AStar : AStarGrid
	{
		private readonly Level _mLevelBehaviour;

		public AStar(Level levelBehaviour)
		{
			_mLevelBehaviour = levelBehaviour;
		}

		public override IEnumerable<IVector2> GetNeighbourNodes(IVector2 node)
		{
			// only return neighbour tiles that are walk-able
			return base.GetNeighbourNodes(node).Where(x => _mLevelBehaviour.IsWalkeable(x.x, x.y));
		}
	}
}
