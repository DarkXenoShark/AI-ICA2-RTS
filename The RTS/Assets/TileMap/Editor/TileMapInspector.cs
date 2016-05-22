using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using SandTiger;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BlackTip
{
	[Serializable] [CustomEditor (typeof (TileMap))]
	public class TileMapInspector : Editor
	{
		[SerializeField] private bool _showTileGrid		= false;
		[SerializeField] private bool _showMapSettings	= true;
		[SerializeField] private bool _showSprites		= true;

		private readonly Dictionary<string, Texture2D> _thumbnailCache = new Dictionary<string, Texture2D>();

		private TileMap _tileMap		= null;
		private TileSheet _tileSheet	= null;

		private IVector2 _tiles					= IVector2.zero;
		private int _tileResolution				= 0;

		[UsedImplicitly] private void OnEnable ()
		{
			_tileMap	= (TileMap) target;
			_tileSheet	= _tileMap.TileSheet;

			TileMeshSettings meshSettings = _tileMap.MeshSettings;

			if (meshSettings == null) return;

			_tiles			= meshSettings.Tiles;
			_tileResolution	= meshSettings.TileResolution;
		}

		public override void OnInspectorGUI ()
		{
            serializedObject.Update();

			_showTileGrid = EditorGUILayout.Toggle ("TileMap Grid", _showTileGrid);
			// Forcefully update the scene view.
			if (_showTileGrid) SceneView.RepaintAll();

			_showMapSettings = EditorGUILayout.Foldout (_showMapSettings, "Map Settings");
			if (_showMapSettings)
			{
				GUILayout.Label (string.Concat("Tile Size: ", _tiles.x.ToString(), "(x), ", _tiles.y.ToString(), "(y)") );
				GUILayout.Label (string.Concat("Tile Resolution: ", _tileResolution.ToString(), "px"));

				if (_tileResolution != _tileMap.MeshSettings.TileResolution)
				{
					EditorGUILayout.HelpBox ("Changing tile resolution will clear the current tile setup.\n" +
											string.Format ("Current tile resolution is {0}.", _tileMap.MeshSettings.TileResolution), MessageType.Warning);
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
				foreach (Sprite sprite in ids.Select(t => _tileSheet.Get(t)))
				{
					ShowSprite(sprite);
					GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
				}
			}

			EditorUtility.SetDirty (this);

            serializedObject.ApplyModifiedProperties();
        }

		private bool ShowTileDeletionWarning ()
		{
			return EditorUtility.DisplayDialog ("Really delete?", string.Format("{0} manually set tile(s) will be removed.", _tileMap.TileCount), "Yes", "No");
		}

		public void ShowSprite (Sprite sprite)
		{
			EditorGUILayout.BeginHorizontal();

			GUILayout.Label (new GUIContent(sprite.name, GetThumbnail(sprite), sprite.textureRect.ToString()));
			GUILayout.FlexibleSpace();

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

					DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

					if (evt.type == EventType.DragPerform)
					{
						DragAndDrop.AcceptDrag();
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
				foreach (Sprite sprite in sprites.Where(sprite => !_tileSheet.Contains(sprite.name)))
				{
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
			texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);
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

			float gridWidth = _tiles.x * 1f;
			float gridHeight = _tiles.y * 1f;

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