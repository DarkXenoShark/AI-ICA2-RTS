using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

using SandTiger;

namespace BlackTip
{
	[Serializable] [CustomEditor (typeof (TileMap))]
	public class TileMapInspector : Editor
	{
		[SerializeField] private bool _showTileGrid		= false;
		[SerializeField] private bool _showMapSettings	= true;
		[SerializeField] private bool _showSprites		= false;

		private readonly Dictionary<string, Texture2D> _thumbnailCache = new Dictionary<string, Texture2D>();

		private TileMap _tileMap		= null;
		private TileSheet _tileSheet	= null;

		private IVector2 _tiles					= IVector2.zero;
		private int _tileResolution				= 8;
		private float _tileSize					= 0f;
		private MeshMode _meshMode				= MeshMode.SingleQuad;
		private TextureFormat _textureFormat	= TextureFormat.ARGB32;
		private FilterMode _textureFilterMode	= FilterMode.Point;

		[UsedImplicitly] private void OnEnable ()
		{
			_tileMap	= (TileMap) target;
			_tileSheet	= _tileMap.TileSheet;

			TileMeshSettings meshSettings = _tileMap.MeshSettings;

			if (meshSettings == null) return;

			_tiles			= meshSettings.Tiles;
			_tileResolution	= meshSettings.TileResolution;
			_tileSize		= meshSettings.TileSize;
			_meshMode		= meshSettings.MeshMode;

            if (Application.isPlaying)
			_textureFormat	= meshSettings.TextureFormat;
		}

		public override void OnInspectorGUI ()
		{
            //base.OnInspectorGUI();

            serializedObject.Update();

			_showTileGrid = EditorGUILayout.Toggle ("TileMap Grid", _showTileGrid);
			// Forcefully update the scene view.
			if (_showTileGrid) SceneView.RepaintAll();

			_showMapSettings = EditorGUILayout.Foldout (_showMapSettings, "Map Settings");
			if (_showMapSettings)
			{
				_tiles.x = EditorGUILayout.IntField (new GUIContent("Tiles X", "The number of tiles on the X axis"), _tiles.x);
				_tiles.y = EditorGUILayout.IntField (new GUIContent("Tiles Y", "The number of tiles on the Y axis"), _tiles.y);
				_tileResolution = EditorGUILayout.IntField (new GUIContent("Tile Resolution", "The number of pixels along each axis on one tile"), _tileResolution);

				if (_tileResolution != _tileMap.MeshSettings.TileResolution)
				{
					EditorGUILayout.HelpBox ("Changing tile resolution will clear the current tile setup.\n" +
											string.Format ("Current tile resolution is {0}.", _tileMap.MeshSettings.TileResolution), MessageType.Warning);
				}

				_tileSize = EditorGUILayout.FloatField (new GUIContent ("Tile Size", "The size of one tile in Unity units"), _tileSize);
				_meshMode = (MeshMode) EditorGUILayout.EnumPopup ("Mesh Mode", _meshMode);

				// these settings only apply to the single quad mode mesh
				if (_meshMode == MeshMode.SingleQuad)
				{
					_textureFormat = (TextureFormat)EditorGUILayout.EnumPopup ("Texture Format", _textureFormat);
					_textureFilterMode = (FilterMode)EditorGUILayout.EnumPopup ("Filter Mode", _textureFilterMode);
				}
			}

			// Sprites Drop Down
			bool prominentImportArea = !_tileSheet.Ids.Any();
			_showSprites = EditorGUILayout.Foldout(_showSprites || prominentImportArea, "Sprites");
			if (_showSprites || prominentImportArea)
			{
				ShowImportDropArea();
			}
			if (_showSprites && !prominentImportArea)
			{
				if (GUILayout.Button("Delete all"))
				{
					foreach (int id in _tileMap.TileSheet.Ids) _tileMap.TileSheet.Remove(id);
					_thumbnailCache.Clear();
				}

				if (GUILayout.Button("Refresh thumbnails")) _thumbnailCache.Clear();

				List <int> ids = _tileSheet.Ids.ToList();
				ids.Sort();
				foreach (int t in ids)
				{
					Sprite sprite = _tileSheet.Get(t);
					ShowSprite(sprite);

					/*if (i < ids.Count - 1) */GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
				}
			}

			EditorUtility.SetDirty (this);

            serializedObject.ApplyModifiedProperties();
        }

		private bool ShowTileDeletionWarning ()
		{
			return EditorUtility.DisplayDialog ("Really delete?", string.Format("{0} manually set tile(s) will be removed.", _tileMap.TileCount), "Yes", "No");
		}

		public void ShowSprite(Sprite sprite)
		{
			EditorGUILayout.BeginHorizontal();

			GUILayout.Label (new GUIContent(sprite.name, GetThumbnail(sprite), sprite.textureRect.ToString()));

			GUILayout.FlexibleSpace();

			// TODO would be nice to vertically center this button when larger sprites are used
			if (GUILayout.Button("Remove")) _tileSheet.Remove(_tileSheet.Lookup(sprite.name));

			EditorGUILayout.EndHorizontal();
		}

		public void ShowImportDropArea()
		{
			Event evt = Event.current;
			Rect rect = GUILayoutUtility.GetRect(0f, 20f, GUILayout.ExpandWidth (true));
			GUI.Box(rect, "Drag and drop Texture/Sprite here");

			switch (evt.type)
			{
				case EventType.DragUpdated:
				case EventType.DragPerform:
					if (!rect.Contains(evt.mousePosition)) return;
					//			if (evt.type != EventType.DragPerform)
					//				return;

					DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
					//			DragAndDrop.AcceptDrag();

					if (evt.type == EventType.DragPerform)
					{
						DragAndDrop.AcceptDrag();

						// I don't know of a way to multi-select stuff in the asset view
						// to drag and drop, so assume only one
						Object dropped = DragAndDrop.objectReferences.FirstOrDefault();
						TryImport(dropped);

						Event.current.Use();
					}
					break;
			}
		}

		private void TryImport(object obj)
		{
			Texture2D texture = obj as Texture2D;
			Sprite sprite = obj as Sprite;
			if (texture != null) ImportTexture(texture);
			else if (sprite != null) ImportSprite(sprite);
		}

		private void ImportTexture(Texture2D texture)
		{
			if (!IsTextureReadable(texture))
			{
				Debug.LogError(string.Format("Texture '{0}' must be marked as readable", texture.name));
				return;
			}
			string assetPath = AssetDatabase.GetAssetPath(texture);
			Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);
			List <Sprite> sprites = assets.OfType<Sprite>().ToList();
			if (sprites.Count > 0)
			{
				foreach (Sprite sprite in sprites)
				{
					if (_tileSheet.Contains(sprite.name)) continue;
					_tileSheet.Add(sprite);
				}
				Debug.Log(string.Format("{0} sprites loaded from {1}", sprites.Count, assetPath));
			}
			else
			{
				Debug.LogWarning(string.Format("No sprites found on asset path: {0}", assetPath));
			}
		}

		private void ImportSprite(Sprite sprite)
		{
			if (!IsTextureReadable(sprite.texture))
			{
				Debug.LogError(string.Format("Texture '{0}' must be marked as readable", sprite.texture.name));
				return;
			}

			if (_tileSheet.Contains(sprite.name)) Debug.LogError(string.Format("TileSheet already contains a sprite named {0}", sprite.name));
			else _tileSheet.Add(sprite);
		}

		private Texture GetThumbnail(Sprite sprite)
		{
			Texture2D texture = null;
			if (_thumbnailCache.TryGetValue (sprite.name, out texture)) return texture;

			Rect rect = sprite.textureRect;
			texture = new Texture2D((int)rect.width, (int)rect.height, _textureFormat, false);
			texture.SetPixels(sprite.texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
			texture.Apply(false, true);

			_thumbnailCache[sprite.name] = texture;
			return texture;
		}

		private static bool IsTextureReadable (Texture2D texture)
		{
			string path = AssetDatabase.GetAssetPath (texture);
			TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(path);
			return textureImporter.isReadable;
		}

		[UsedImplicitly] private void OnSceneGUI ()
		{
			if (!_showTileGrid) return;

			float gridWidth = _tiles.x * _tileSize;
			float gridHeight = _tiles.y * _tileSize;

			Vector2 position = _tileMap.gameObject.transform.position;

			Handles.color = Color.gray;
			for (float i = 1; i < gridWidth; i++)
			{
				Handles.DrawLine(new Vector3(i + position.x, position.y), new Vector3(i + position.x, gridHeight + position.y));
			}

			for (float i = 1; i < gridHeight; i++)
			{
				Handles.DrawLine (new Vector3(position.x, i + position.y), new Vector3(gridWidth + position.x, i + position.y));
			}

			Handles.color = Color.white;
			Handles.DrawLine (position, new Vector3(gridWidth + position.x, position.y));
			Handles.DrawLine (position, new Vector3(position.x, gridHeight + position.y));
			Handles.DrawLine (new Vector3(gridWidth + position.x, position.y), new Vector3(gridWidth + position.x, gridHeight + position.y));
			Handles.DrawLine (new Vector3(position.x, gridHeight + position.y), new Vector3(gridWidth + position.x, gridHeight + position.y));
		}
	}
}