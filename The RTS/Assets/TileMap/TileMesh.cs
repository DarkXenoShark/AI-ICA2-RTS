using System;
using UnityEngine;
using UnityEngine.Rendering;

using SandTiger;

namespace BlackTip
{
	public enum MeshMode
	{ SingleQuad, QuadGrid }

	[ExecuteInEditMode] [RequireComponent (typeof (MeshFilter))] [RequireComponent (typeof (MeshRenderer))]
	public abstract class TileMesh : MonoBehaviour
	{
		private Material _material			= null;
		private TileMeshSettings _settings	= null;

		public virtual TileMeshSettings Settings
		{
			get { return _settings; }
			set
			{
				if (value == null) throw new ArgumentNullException ("value");
				if (_settings != null && _settings.Equals (value)) return;

				if (value.Tiles.x < 0)			throw new ArgumentException ("Tiles X cannot be less than zero");
				if (value.Tiles.y < 0)			throw new ArgumentException ("Tiles Y cannot be less than zero");
				if (value.TileResolution < 0)	throw new ArgumentException ("TilesResolution cannot be less than zero");
				if (value.TileSize < 0f)		throw new ArgumentException ("TileSize cannot be less than zero");

				_settings	= value;
				_material	= Material;

				GetComponent<MeshFilter>().mesh = CreateMesh();

				MeshRenderer MR = GetComponent<MeshRenderer>();
				// Disable anything to do with lighting.
				MR.shadowCastingMode	= ShadowCastingMode.Off;
				MR.reflectionProbeUsage = ReflectionProbeUsage.Off;
				MR.receiveShadows		= false;
				MR.useLightProbes		= false;
				// Assign the material.
				MR.material				= _material;
			}
		}

		protected Material Material
		{ get { return _material ?? (_material = new Material (Shader.Find ("Sprites/Default")) { color = Color.white }); } }

		protected Texture MaterialTexture
		{
			get { return Material.GetTexture ("_MainTex"); }
			set { Material.SetTexture ("_MainTex", value); }
		}

		public abstract void SetTile (IVector2 coord, Sprite sprite);

		public Rect GetTileBoundsLocal (IVector2 coord)
		{
			float size = _settings.TileSize;
			return new Rect (coord.x * size, coord.y * size, size, size);
		}

		public Rect GetTileBoundsWorld (IVector2 coord)
		{
			Rect rect = GetTileBoundsLocal (coord);
			rect.x += transform.position.x;
			rect.y += transform.position.y;
			return rect;
		}

		protected abstract Mesh CreateMesh();
	}
}