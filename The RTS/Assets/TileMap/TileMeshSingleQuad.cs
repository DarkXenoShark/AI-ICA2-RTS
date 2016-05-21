using System;
using System.Linq;
using JetBrains.Annotations;
using SandTiger;
using UnityEngine;
// TODO: Max texture2D varies around: 64 resolution TileMap maxed at 64X64
// 2048x2048
// 4096x4096
// 8192x8192

namespace BlackTip
{
	public class TileMeshSingleQuad : TileMesh
	{
		private Texture2D _texture = null;
		private bool _dirty = false;

		public override TileMeshSettings Settings
		{
			get { return base.Settings; }
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (base.Settings != null && base.Settings.Equals(value)) return;

				bool resolutionChanged = false;

				if (base.Settings != null) resolutionChanged = base.Settings.TileResolution != value.TileResolution;

				base.Settings = value;
				CreateTexture (!resolutionChanged);
			}
		}

		[UsedImplicitly] private void LateUpdate ()
		{
			if (!_dirty || _texture == null) return;
			_dirty = false;
			_texture.Apply ();
		}

		public override void SetTile (IVector2 coord, Sprite sprite)
		{
			Color[] spriteColours = sprite.texture.GetPixels((int)sprite.rect.x, (int)sprite.rect.y, (int)sprite.rect.width, (int)sprite.rect.height);

			SetTile (coord, Array.ConvertAll(spriteColours, item => (Color32)item));
		}
		
		public void SetTile (IVector2 coord, Color32 color)
		{
			Color32[] colors = Enumerable.Repeat (color, base.Settings.TileResolution * base.Settings.TileResolution).ToArray();
			SetTile (coord, colors);
		}
		
		private void SetTile (IVector2 coord, Color32[] colors)
		{
			if (MaterialTexture == null)
			{
				Debug.LogError("Texture has not been created");
				return;
			}

			int resolution = base.Settings.TileResolution;
			coord *= resolution;
			
			_texture.SetPixels32 (coord.x, coord.y, resolution, resolution, colors, 0);

			if (Application.isPlaying) _dirty = true;
			else _texture.Apply ();
		}

		protected override Mesh CreateMesh ()
		{
			float sizeX = base.Settings.Tiles.x * base.Settings.TileSize;
			float sizeY = base.Settings.Tiles.y * base.Settings.TileSize;

			Vector2[] vertices = { Vector2.zero, new Vector2 (sizeX, 0), new Vector2 (0, sizeY), new Vector2 (sizeX, sizeY) };

			Mesh mesh = new Mesh
			{
				name		= "TileMapMesh",
				vertices	= Array.ConvertAll (vertices, item => (Vector3) item),
				triangles	= new []{ 0, 2, 3, 0, 3, 1 },
				uv			= new []{ Vector2.zero, Vector2.right, Vector2.up, Vector2.one }
			};

			mesh.RecalculateNormals();
			return mesh;
		}

		private void CreateTexture (bool keepData)
		{
			Debug.Log (new Vector2 (base.Settings.Tiles.x, base.Settings.Tiles.y));
			Debug.Log (base.Settings.TileResolution);
			Debug.Log (new Vector2 (base.Settings.Tiles.x * base.Settings.TileResolution, base.Settings.Tiles.y * base.Settings.TileResolution));

			Texture2D texture = new Texture2D (
				base.Settings.Tiles.x * base.Settings.TileResolution,
				base.Settings.Tiles.y * base.Settings.TileResolution,
				base.Settings.TextureFormat,
				false, false)
			{
				name		= "TileMapSingleTexture",
				filterMode	= base.Settings.TextureFilterMode,
				wrapMode	= TextureWrapMode.Clamp
			};

			if (_texture != null && keepData)
			{
				texture.SetPixels32 (_texture.GetPixels32 (0), 0);
				texture.Apply ();
			}

			_texture = texture;
			MaterialTexture = _texture;
		}
	}
}