using UnityEngine;

using System;
using System.IO;
using System.Reflection;

using System.Text;
using System.Linq;

using Utility;

// . or G 	= passable terrain
// @ or O 	= out of bounds
// T 		= trees (unpassable)
// S 		= swamp (passable from regular terrain)
// W 		= water (traversable, but not passable from terrain)

// Just a quick implementation for the map parser! NEEDS CLEANING UP, I KNOW JUST LEAVE ME BE!
public class MapParser
{
	private enum MapProperties
	{ TYPE = 0, HEIGHT, WIDTH, MAP }

	char[] PassCondition = new char[] { '.', 'G', 'S' };

    int width;
    int height;
	char[] map;

	public MapParser ()
	{ }

	public void LoadFromFile (string fileName)
	{
		LoadFromFile (fileName, ".txt",  "Resources");
	}

	public void LoadFromFile (string fileName, string fileExtension, string relativeLocation)
	{
		string location 		= Application.dataPath + "/Resources/";
		string fullDirectory 	= string.Concat(location, fileName, fileExtension);

		if (!File.Exists (fullDirectory))
        {
            Debug.LogWarning("Unable to compile: Could not find file.");
            return;
        }
        
		Debug.Log (string.Concat("Loading Map: ", fileName));

		string[] AllLines = File.ReadAllLines(fullDirectory);
		// Use the properties (first 4 elements).
		height 	= Int32.Parse(AllLines[(int)MapProperties.HEIGHT].Split(' ')[1]);
		width 	= Int32.Parse(AllLines[(int)MapProperties.WIDTH].Split(' ')[1]);

		map = new char[width * height];

		for (int w = 0; w < AllLines.Length - 4; ++w)
		{
			AllLines[w].ToCharArray().CopyTo(map, w);

//			for (int h = 0; h < AllLines[w + 4].Length; ++h)
//			{
//				map[w * width + h] = AllLines[w + 4][h];
//			}
		}
	}

	public void ConvertToTiles ()
	{
		
	}

	public void ConvertToChunks (int chunkDivisor)
	{
		if (chunkDivisor < 1)
		{
			Debug.LogWarning ("MapParser: Divisor must be 2 or greater. Unable to perform chunk processing.");
			return;
		}

		if (width < 256 && height < 256) // And case because width/height are always the same...
		{
			Debug.LogWarning ("Map Processing: Minimum height/width requires not met to perform chunk processing.");
			return;
		}
		
		//string[,] chunkData = new string[width / chunkdivisor, height / chunkdivisor];
		
		//string[] chunked = AllLines.SubArray (4, width / chunkdivisor);
		
		//foreach (string item in chunked)
		//{
		//	Debug.Log (item);
		//}
	}

	private void ProcessChunk (string[] subLines)
	{

	}
}