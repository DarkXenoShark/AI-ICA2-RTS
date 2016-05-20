using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

using SandTiger;

namespace BlackTip
{
	[Serializable] public class TileChunkManager
	{
		private const string ChunkNameFormat = "Mesh@{0},{1}";
		private TileMap _parent;
		private TileMeshSettings _settings;
		private readonly Grid<TileMesh> _chunks = new Grid<TileMesh>();
		public IVector2 ChunkSize
		{ get { return _settings == null ? IVector2.zero : _settings.Tiles; } }

		public bool Initialized { get; private set; }

		public TileMeshSettings Settings
		{
			get { return _settings; }
			set
			{
				if (!Initialized) throw new InvalidOperationException ("The TileMeshGrid needs to be initialized before applying settings");

				_settings = value;

				List <TileMesh> chunks = _chunks.Where (x => x != null).ToList();

				if (chunks.Count == 0)
				{
					// setup a single chunk
					SetNumChunks (1, 1);
					CreateChunk (0, 0);
					//CreateChunk (0, 1);
					//CreateChunk (1, 0);
					//CreateChunk (1, 1);
				}

				foreach (TileMesh child in chunks) child.Settings = _settings;
			}
		}

		public void Initialize(TileMap parent, TileMeshSettings settings)
		{
			if (Initialized) throw new InvalidOperationException ("Already initialized");
			_parent		= parent;
			_settings	= settings;
			Initialized = true;
		}

		public void DeleteAllChunks()
		{
			for (int i = 0; i < _parent.transform.childCount; ++i)
			{
				Transform child = _parent.transform.GetChild (i);

				// TODO should children of the TileMap thats not chunks be allowed?
				if (!child.name.StartsWith("Mesh")) continue;
				Object.DestroyImmediate(child.gameObject);
			}

			_chunks.Clear();
		}

		public void DeleteChunk (int x, int y)
		{
			string chunkName = string.Format (ChunkNameFormat, x, y);

			for (int i = 0; i < _parent.transform.childCount; ++i)
			{
				Transform child = _parent.transform.GetChild(i);
				if (child.name != chunkName) continue;
				Object.DestroyImmediate(child.gameObject);
				_chunks[x, y] = null;
				return;
			}
		}
		
		public void SetNumChunks (int x, int y)
		{
			_chunks.SetSize (new IVector2 (x, y), null);
		}
		
		internal TileMesh GetChunk (int tileX, int tileY)
		{
			int chunkX = tileX / _settings.Tiles.x;
			int chunkY = tileY / _settings.Tiles.y;

			return _chunks[chunkX, chunkY] ?? CreateChunk (chunkX, chunkY);
		}

		private TileMesh CreateChunk (int x, int y)
		{
			Type type;
			switch (_settings.MeshMode)
			{
				case MeshMode.SingleQuad:
					type = typeof (TileMeshSingleQuad);
				break;

				case MeshMode.QuadGrid:
					type = typeof (TileMeshQuadGrid);
				break;

				default:
					throw new InvalidOperationException (string.Concat ("Mesh mode not implemented: ", _settings.MeshMode));
			}

			GameObject gameObject = new GameObject (string.Format (ChunkNameFormat, x, y), type);
			gameObject.transform.parent = _parent.transform;
			gameObject.transform.localPosition = Vector3.zero;

			// apply settings
			TileMesh mesh = gameObject.GetComponent<TileMesh>();
			mesh.Settings = _settings;

			// cache
			_chunks[x, y] = mesh;
			return mesh;
		}
	}
}