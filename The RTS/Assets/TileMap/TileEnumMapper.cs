using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackTip
{
	public class TileEnumMapper<T>
	{
		private readonly TileMap m_tileMap;
		private readonly Dictionary<T, int> _tiles = new Dictionary<T, int>();

		public TileEnumMapper (TileMap tileMap)
		{
			if (tileMap == null) throw new ArgumentNullException("tileMap");
			m_tileMap = tileMap;
		}
		
		public void Map (T tileType, string nameOfSprite)
		{
			try
			{
				_tiles[tileType] = m_tileMap.TileSheet.Lookup(nameOfSprite);
			}
			catch (KeyNotFoundException)
			{
				Debug.LogError(string.Format("No Sprite named '{0}', did you forget to add it?", nameOfSprite));
				throw;
			}
		}
		
		public int GetId (T tileType)
		{
			return _tiles[tileType];
		}
		
		public T GetType (int id)
		{
			foreach (KeyValuePair <T, int> pair in _tiles)
			{
				if (pair.Value == id) return pair.Key;
			}

			throw new KeyNotFoundException (id.ToString());
		}
		
		public bool Mapped (int id)
		{
			return _tiles.ContainsValue (id);
		}
		
		public bool Mapped (T tileType)
		{
			return _tiles.ContainsKey (tileType);
		}
	}
}