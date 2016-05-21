using System;
using System.Collections;
using System.Collections.Generic;
using SandTiger;
using UnityEngine;

namespace BlackTip
{
	[Serializable] internal class TileMapData : Grid<int>
	{
		public void SetSize (IVector2 v)
		{
			SetSize (v, -1);
		}
	}
    [ExecuteInEditMode]
	[Serializable] public class TileMap : MonoBehaviour, IEnumerable<KeyValuePair<IVector2, int>>
	{
        private static TileMap self;

        public static TileMap Self
        {
            get
            {
                return self;
            }
        }
        
        [SerializeField]
        private TileMapData _tileMapData = null;
		[SerializeField] private TileMeshSettings _tileMeshSettings	= null;
		[SerializeField] private TileSheet _tileSheet				= null;

		private TileChunkManager _chunkManager = null;

		public TileMeshSettings MeshSettings
		{
			get { return _tileMeshSettings; }
			set
			{
				ChunkManager.Settings = value;

				if (_tileMeshSettings != null && _tileMeshSettings.TileResolution != value.TileResolution)
				{
					_tileMapData.Clear();
				}

				_tileMeshSettings = value;
				_tileMapData.SetSize (_tileMeshSettings.Tiles);
			}
		}

		public TileSheet TileSheet
		{ get { return _tileSheet; } }

		public int TileCount
		{ get { return _tileMapData.Count; } }

		public void ClearTiles()
		{
			_tileMapData.Clear();
		}

		private TileChunkManager ChunkManager
		{
			get
			{
				if (_chunkManager != null) return _chunkManager;

				_chunkManager = new TileChunkManager();
				_chunkManager.Initialize (this, _tileMeshSettings);
				return _chunkManager;
			}
		}

		//public bool HasMesh
		//{ get { return ChunkManager.GetChunk (0, 0) != null; } }

        
		protected virtual void Awake()
		{
            self = this;

			if (_tileMeshSettings == null) _tileMeshSettings = new TileMeshSettings (IVector2.one, 16, 1f);
			if (_tileSheet == null) _tileSheet = ScriptableObject.CreateInstance<TileSheet>();

			if (_chunkManager == null)
			{
				_chunkManager = new TileChunkManager();
				_chunkManager.Initialize (this, _tileMeshSettings);
			}

			if (_tileMapData == null)
			{
				_tileMapData = new TileMapData();
				_tileMapData.SetSize (_tileMeshSettings.Tiles);
			}

			if (Application.isPlaying) CreateMesh();
		}

		public int this[int x, int y]
		{
			get { return _tileMapData[x, y]; }
			set
			{
				SetTile (new IVector2 (x, y), value);
				_tileMapData[x, y] = value;
			}
		}

		public void CreateMesh ()
		{
			// initialize mesh grid
			if (!ChunkManager.Initialized) ChunkManager.Initialize (this, _tileMeshSettings);
			else ChunkManager.Settings = _tileMeshSettings;
		}

		public void DestroyMesh ()
		{
			ChunkManager.DeleteAllChunks();
		}
		
		public Rect GetTileBoundsLocal (IVector2 coord)
		{
			return ChunkManager.GetChunk (0, 0).GetTileBoundsLocal (coord);
		}
		
		public Rect GetTileBoundsWorld (IVector2 coord)
		{
			return ChunkManager.GetChunk (0, 0).GetTileBoundsWorld (coord);
		}

		public bool IsInBounds (IVector2 coord)
		{
			return _tileMapData.IsInBounds (coord);
		}

		public void PaintTile (IVector2 coord, Color color)
		{
			TileMesh child = ChunkManager.GetChunk (0, 0);
			if (child == null) throw new InvalidOperationException ("MeshGrid has not yet been created.");

			TileMeshSingleQuad singleQuad = child as TileMeshSingleQuad;

			if (singleQuad == null) throw new InvalidOperationException ("Painting tiles is only supported in SingleQuad MeshMode");
			singleQuad.SetTile (coord, color);
		}

		private void SetTile (IVector2 coord, Sprite sprite)
		{
			if (sprite == null) throw new ArgumentNullException ("sprite");
			ChunkManager.GetChunk (0, 0).SetTile (coord, sprite);
		}

		private void SetTile (IVector2 coord, int id)
		{
			SetTile (coord, _tileSheet.Get (id));
		}

		public IEnumerator<KeyValuePair<IVector2, int>> GetEnumerator()
		{
			for (int x = 0; x < _tileMeshSettings.Tiles.x; ++x)
			{
				for (int y = 0; y < _tileMeshSettings.Tiles.y; ++y)
				{
					yield return new KeyValuePair<IVector2, int>(new IVector2 (x, y), _tileMapData[x, y]);
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}