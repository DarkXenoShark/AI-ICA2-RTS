using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BlackTip;
using JetBrains.Annotations;
using SandTiger;
using UnityEngine;
using Debug = UnityEngine.Debug;
// Custom namespace

public class Level : MonoBehaviour
{
    private static Level self;

    public static Level Self
    {
        get
        {
            return self;
        }
    }

	[SerializeField] private string _map = "";

	private TileEnumMapper <TileType> _tiles;
	private TileMap _tileMap;

	[UsedImplicitly] private void Awake ()
	{
        self = this;

		// Parse and load a map into cache.
		FileParser.LoadFromFile (_map);
		// Find the tilemap game object and cache the behaviour.
		_tileMap = GameObject.Find ("TileMap").GetComponent<TileMap>();

		if (_tileMap == null)
		{
			Debug.LogError ("TileMapBehaviour not found.");
			return;
		}

		TileSheet tileSheet = _tileMap.TileSheet;

		if (tileSheet.Count == 0)
		{
			Debug.LogError ("Add some sprites before running the game.");
			return;
		}

		Sprite sprite = tileSheet.Get (1);
		_tileMap.MeshSettings = new TileMeshSettings (new IVector2 (FileParser.Width, FileParser.Height), (int)sprite.rect.width);

		// Map type of tile to sprite
		_tiles = new TileEnumMapper<TileType> (_tileMap);
		_tiles.Map (TileType.OUT_BOUNDS, "OutOfBound");
		_tiles.Map (TileType.GRASS, "NormalGrass");
		_tiles.Map (TileType.SWAMP, "SwampGrass");
		_tiles.Map (TileType.WATER, "ShallowWater");
	}

	[UsedImplicitly] private void Start ()
	{
		// TODO: It takes about 3.5-4 Seconds for Aged.txt :'(
		Stopwatch watch = new Stopwatch();
		watch.Start();

		// Does some basic stuff.
		TexturePreProcessOptimization();

		// TODO: Optimization could be to set the majority sprites as default?
		for (int y = 0; y < FileParser.Height; ++y)
		{
			for (int x = 0; x < FileParser.Width; ++x)
			{
				TileType type = FileParser.RawData[y * FileParser.Width + x];

				// Only tiles that have been mapped and registered will be used.
				if (_tiles.Mapped (type)) _tileMap[x, y] = _tiles.GetId (type);
			}
		}

		watch.Stop();
		Debug.Log (watch.ElapsedMilliseconds / 1000f);

		Renderer R = _tileMap.GetComponentInChildren<TileMesh>().GetComponent<Renderer>();
		if (R != null) R.sortingOrder = 0;
	}

	private void TexturePreProcessOptimization ()
	{
		TileType[] significantTiles = MostTileCoverage();
		// This should not occur but if it does BOOM.
		if (significantTiles.Length == 0) return;

		// The optimization is to set the entire texture to the tile type of most significance.
	}

	public TileType GetTile (int x, int y)
	{
		return _tiles.GetType (_tileMap[x, y]);
	}

	// Returns true if the player can walk on this tile.
	public bool IsWalkeable (int x, int y)
	{
		return _tileMap[x, y] != _tiles.GetId (TileType.OUT_BOUNDS);
	}

	//public IVector2 FindTile (TileType tileType)
	//{
	//	for (int y = 0; y < _grid.Size.y; ++y)
	//	{
	//		for (int x = 0; x < _grid.Size.x; ++x)
	//		{
	//			if (_grid[x, y] == tileType) return new IVector2 (x, y);
	//		}
	//	}

	//	return new IVector2 (0, 0);
	//}

	public IEnumerable<IVector2> FindAllTiles (TileType tileType)
	{
		for (int y = 0; y < FileParser.Height; ++y)
		{
			for (int x = 0; x < FileParser.Width; ++x)
			{
				if (FileParser.RawData[y * FileParser.Width + x] == tileType) yield return new IVector2 (x, y);
			}
		}
	}

	public TileType[] MostTileCoverage ()
	{
		List <TileType> currentTileTypes = new List <TileType>();
		int currentCount = 0;

		for (TileType index = TileType.OUT_BOUNDS; index < TileType.TYPE_COUNT; ++index)
		{
			int count = FindAllTiles (index).Count();

			if (currentCount > count) continue;

			currentTileTypes.Add (index);
			currentCount = count;
		}

		return currentTileTypes.ToArray();
	}

	public bool HasMostTileCoverage (TileType tileType)
	{
		TileType currentTileType	= TileType.OUT_BOUNDS;
		int currentCount			= 0;

		for (TileType index = currentTileType; index < TileType.TYPE_COUNT; ++index)
		{
			int count = FindAllTiles (index).Count();

			if (currentCount >= count) continue;

			currentTileType = index;
			currentCount = count;
		}

		return tileType == currentTileType;
	}

	//public IVector2 GetRandomTileOfType (TileType tileType)
	//{
	//	List <IVector2> candidates = FindAllTiles (tileType).ToList();
	//	return candidates[Random.Range(0, candidates.Count)];
	//}
}
