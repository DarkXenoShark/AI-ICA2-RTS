using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BlackTip;
using SandTiger;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public AgentMaster.Person _self;
	public int _alliance;

	public float SkillPoints { get; set; }

	[SerializeField] private List<AgentMaster.EResource> _holding;

	public void Get_Resource(AgentMaster.EResource its_resource)
	{
		if (_holding.Any(rep_source => rep_source == its_resource))
		{
			Debug.Log("Already Holding " + its_resource);
			return;
		}

		_holding.Add(its_resource);
	}

	public enum ESkill
	{
		None,
		Rifleman
	}

	public ESkill Skill { get; private set; }

	public void SetSkill (ESkill its_skill)
	{
		if (SkillPoints > 0)
		{
			Skill = its_skill;
			SkillPoints--;
		}
		else
		{
			Debug.Log("Not enough points to become a " + its_skill);
		}
	}

	private IVector2 _position	= IVector2.zero;
	private bool _walking		= false;
    [SerializeField] private float _speed = 0.1f;

    private void Awake()
    {
        _self.TheName = gameObject.name.ToUpper();
        _self.TheLocation = _self.TheLocation.ToUpper();
		_self.TheJob = AgentMaster.EJob.Labourer;
		Skill = ESkill.None;
		_holding = new List<AgentMaster.EResource>();
	    SkillPoints = 0;
    }

	private void Start()
	{

		SetTilePosition(new IVector2(GameMaster.Get_Location_By_Name(_self.TheLocation).transform.position));
	}

	public void Store_Resources()
	{
		Player quick_player = GameMaster.Get_Player(_alliance);

		foreach (AgentMaster.EResource rep_resource in _holding)
		{
			switch (rep_resource)
			{
				case AgentMaster.EResource.None:
				break;

				case AgentMaster.EResource.Timber:
					quick_player.TheResources.TheTimber++;
				break;

				case AgentMaster.EResource.Coal:
					quick_player.TheResources.TheCoal++;
				break;

				case AgentMaster.EResource.Ore:
					quick_player.TheResources.TheOre++;
				break;

				case AgentMaster.EResource.Stone:
					quick_player.TheResources.TheStone++;
				break;

				case AgentMaster.EResource.Wood:
					quick_player.TheResources.TheWood++;
					break;

				case AgentMaster.EResource.Iron:
					quick_player.TheResources.TheIron++;
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		_holding.Clear();
	}

	public void Store_Resource(AgentMaster.EResource its_resource)
	{
		Player quick_player = GameMaster.Get_Player(_alliance);

		for (int rep_resource = 0; rep_resource < _holding.Count; rep_resource++)
		{
			if (_holding[rep_resource] != its_resource) 
				continue;

			switch (its_resource)
			{
				case AgentMaster.EResource.None:
					break;

				case AgentMaster.EResource.Timber:
					quick_player.TheResources.TheTimber++;
					break;

				case AgentMaster.EResource.Coal:
					quick_player.TheResources.TheCoal++;
					break;

				case AgentMaster.EResource.Ore:
					quick_player.TheResources.TheOre++;
					break;

				case AgentMaster.EResource.Stone:
					quick_player.TheResources.TheStone++;
					break;

				case AgentMaster.EResource.Wood:
					quick_player.TheResources.TheWood++;
					break;

				case AgentMaster.EResource.Iron:
					quick_player.TheResources.TheIron++;
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
			_holding.RemoveAt(rep_resource);
			return;
		}
	}

	public void Remove_Resource(AgentMaster.EResource its_resource)
	{
		for (int rep_resource = 0; rep_resource < _holding.Count; rep_resource++)
		{
			if (_holding[rep_resource] != its_resource) 
				continue;

			_holding.RemoveAt(rep_resource);
			return;
		}
	}

	public void Set_Job(AgentMaster.EJob its_job)
	{
		if (SkillPoints > 0)
		{
			_self.TheJob = its_job;
			SkillPoints--;
		}
		else
		{
			Debug.Log("Not enough points to become a " + its_job);
		}
	}

	public void Go (IVector2 destination)
	{
		if (_walking) return;
		_walking = true;
        StartCoroutine (WalkTo (destination, _speed));
	}

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
