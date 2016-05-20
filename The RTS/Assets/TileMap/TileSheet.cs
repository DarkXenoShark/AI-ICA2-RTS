using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlackTip
{
	[Serializable] public sealed class TileSheet : ScriptableObject
	{
		[Serializable] internal sealed class TileEntry
		{
			[SerializeField] public int Id;
			[SerializeField] public Sprite Sprite;
		}

		[SerializeField] internal List<TileEntry> _tiles = new List<TileEntry>();

		public IEnumerable<string> Names
		{ get { return _tiles.Select(x => x.Sprite.name).ToList(); } }

		public IEnumerable<int> Ids
		{ get { return _tiles.Select(x => x.Id).ToList(); } }

		public int Count
		{ get { return _tiles.Count; } }

		public Sprite Get (int sid)
		{
			TileEntry entry = GetEntry (sid);

			if (entry == null) throw new KeyNotFoundException (sid.ToString());

			return entry.Sprite;
		}

		public int Lookup (string sname)
		{
			TileEntry entry = GetEntry (sname);

			if (entry == null) throw new KeyNotFoundException (sname);

			return entry.Id;
		}

		public string Lookup (int sid)
		{
			TileEntry firstOrDefault = _tiles.FirstOrDefault (x => x.Id == sid);

			if (firstOrDefault == null) throw new KeyNotFoundException (sid.ToString());

			return firstOrDefault.Sprite.name;
		}

		public bool Contains (string spriteName)
		{
			return GetEntry (spriteName) != null;
		}

		public bool Contains (int id)
		{
			return GetEntry (id) != null;
		}

		public int Add (Sprite sprite)
		{
			if (sprite == null) throw new ArgumentNullException ("sprite");

			TileEntry entry = new TileEntry
			{
				Id		= GenerateNewId(),
				Sprite	= sprite
			};

			_tiles.Add (entry);

			return entry.Id;
		}

		public void Remove (int id)
		{
			for (int index = 0; index < _tiles.Count; ++index)
			{
				if (_tiles[index].Id != id) continue;

				_tiles.RemoveAt (index);
				return;
			}
		}

		private TileEntry GetEntry (int id)
		{
			return _tiles.FirstOrDefault (entry => entry.Id == id);
		}

		private TileEntry GetEntry (string spriteName)
		{
			return _tiles.FirstOrDefault (entry => entry.Sprite.name == spriteName);
		}

		private int GenerateNewId()
		{
			for (int id = 0;; ++id)
			{
				if (_tiles.All (entry => entry.Id != id)) return id;
			}
		}
	}
}