using System;
using UnityEngine;

using SandTiger;

namespace BlackTip
{
	[Serializable] public class TileMeshSettings
	{
		public IVector2 Tiles;
		public int TileResolution;
		public float TileSize;
		public TextureFormat TextureFormat;
		public FilterMode TextureFilterMode = FilterMode.Point;
		public MeshMode MeshMode;
		
		public TileMeshSettings ()
		{ }

		public TileMeshSettings (IVector2 tiles, int tileResolution) : this (tiles, tileResolution, 1f)
		{ }

		public TileMeshSettings (IVector2 tiles, int tileResolution, float tileSize) : this (tiles, tileResolution, tileSize, MeshMode.SingleQuad)
		{ }

		public TileMeshSettings (IVector2 tiles, int tileResolution, float tileSize, MeshMode meshMode) : this (tiles, tileResolution, tileSize, meshMode, TextureFormat.ARGB32)
		{ }

		public TileMeshSettings (IVector2 tiles, int tileResolution, float tileSize, MeshMode meshMode, TextureFormat textureFormat)
		{
			Tiles			= tiles;
			TileResolution	= tileResolution;
			TileSize		= tileSize;
			MeshMode		= meshMode;
			TextureFormat	= textureFormat;
		}

		public override bool Equals (object ob)
		{
			if (ReferenceEquals(this, ob)) return true;

			TileMeshSettings TMS = ob as TileMeshSettings;
			if (TMS == null) return false;

			return Tiles == TMS.Tiles &&
				TileResolution == TMS.TileResolution &&
				Math.Abs (TileSize - TMS.TileSize) < 0f &&
				MeshMode == TMS.MeshMode &&
				TextureFormat == TMS.TextureFormat;
		}

		public override int GetHashCode()
		{
			return Tiles.GetHashCode() ^
				TileResolution.GetHashCode() ^
				TileSize.GetHashCode() ^
				MeshMode.GetHashCode() ^
				TextureFormat.GetHashCode();
		}
	}
}
