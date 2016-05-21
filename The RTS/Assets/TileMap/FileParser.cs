using System;
using System.IO;
using UnityEngine;

namespace BlackTip
{
	public static class FileParser
	{
		private enum MapProperties
		{ HEIGHT = 1, WIDTH = 2 }

		public static int Width				{ get; private set; }
		public static int Height			{ get; private set; }
		public static TileType[] RawData	{ get; private set; }

		static FileParser ()
		{
			ClearData();
		}

		public static void LoadFromFile (string name)
		{
			LoadFromFile (name, ".txt", "Resources");
		}

		public static void LoadFromFile (string name, string extension, string relativeLocation)
		{
			// The complete path of the file including its relative directory and extension!
			string path = string.Concat (Application.dataPath, "/", relativeLocation, "/", name, extension);

			try
			{
				ValidateFile (path);

				string[] AllLines = File.ReadAllLines (path);
				// Use the properties (first 4 elements).
				Height	= int.Parse (AllLines[(int) MapProperties.HEIGHT].Split (' ')[1]);
				Width 	= int.Parse (AllLines[(int) MapProperties.WIDTH].Split (' ')[1]);
				RawData	= new TileType[Width * Height];

				for (int index = 4, offset = 0; index < AllLines.Length; ++index)
				{
					int rowLength = AllLines[index].Length;
					TileType[] row = new TileType[rowLength];

					for (int subex = 0; subex < rowLength; ++subex)
					{
						switch (AllLines[index][subex])
						{
							case '.':
							case 'G':
								row[subex] = TileType.GRASS;
							continue;

							case 'S':
								row[subex] = TileType.SWAMP;
							continue;

							case 'W':
								row[subex] = TileType.WATER;
							continue;

							default:
								row[subex] = TileType.OUT_BOUNDS;
							continue;
						}
					}

					//int[] row = Array.ConvertAll (AllLines[index].ToCharArray(), item => (int) item);
					Array.Copy (row, 0, RawData, offset, row.Length);
					offset += row.Length;
				}
			}
			catch (Exception)
			{
				// ignored
			}
		}

		public static void ClearData ()
		{
			RawData = null;
			Width	= 0;
			Height	= 0;
		}

		public static void ValidateFile (string fullPath)
		{
			if (!File.Exists (fullPath)) throw new Exception (string.Concat ("Non-Compliant: Could not find/load file \"", fullPath, "\"."));
		}
	}
}