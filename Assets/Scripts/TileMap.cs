using UnityEngine;

// Required components to use this script.
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
[RequireComponent (typeof (MeshCollider))]
// Other setting for this mono-script.
[DisallowMultipleComponent]
[ExecuteInEditMode]

public class TileMap : MonoBehaviour
{
	enum MeshMode
	{ Hexagonal, Cubic }
	
	// Determines which tiling mesh used.
	[SerializeField] private MeshMode meshMode = MeshMode.Cubic;

	[SerializeField] private int 	width 	= 10; // Amount in X
	[SerializeField] private int 	height 	= 10; // Amount in Z not Y
	[SerializeField] private float	scale 	= 1f; // Scaling factor per tile.

	void UnrelatedAndWillBeRemoved ()
	{
        MapParser instance = new MapParser();
        instance.LoadFromFile ("Aged");
		//instance.ConvertToTileArray();
		//
	}

	void Start ()
	{
		UnrelatedAndWillBeRemoved();

		// Should do some garbage collection but whatever.
	
		GenerateMap();
	}

	public void GenerateMap ()
	{
		Mesh mesh = new Mesh();
	
		switch (meshMode)
		{
			case MeshMode.Hexagonal:
				//GenerateHexagonalMap();
			break;

			case MeshMode.Cubic:
				mesh = GenerateCubeMap();
			break;

			default:
			break;
		}
		
		if (!mesh) return; // Failed to generate tilemap mesh.
				
		// Now we can use our new mesh type.
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		//MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		MeshCollider meshCollider = GetComponent<MeshCollider>();
		
        meshFilter.mesh 		= mesh;
		meshCollider.sharedMesh = mesh;
    }

	// Generate a cubic world.
	private Mesh GenerateCubeMap ()
	{
		int triangleCount = (width * height) * 2;

		int verticeX = width + 1;
		int verticeZ = height + 1;
		int verticeCount = verticeX * verticeZ;

		// Basically unity's mesh vertex limit.
		if (verticeCount >= 65000)
		{
			Debug.LogError ("Unable to complie, vertex limit reached (65000): " + verticeCount);
			return null;
		}

		// Generate the mesh data.
		Vector3[] vertices 	= new Vector3[verticeCount];
		Vector3[] normals 	= new Vector3[verticeCount];
		Vector2[] uvCoods 	= new Vector2[verticeCount];
		int[] triangles 	= new int[triangleCount * 3];

		for (int z = 0; z < verticeZ; ++z)
		{
			for (int x = 0; x < verticeX; ++x)
			{
				int squareIndex = z * verticeX + x;
				
				// Generate Vertex Data
				vertices[squareIndex]	= new Vector3 (x * scale, 0, z * scale);
				normals[squareIndex]	= Vector3.up;
				uvCoods[squareIndex] 	= new Vector2 ((float) x / verticeX, (float) z / verticeZ); // 1 to 1 relationship.
			}
		}

		for (int z = 0; z < height; ++z)
		{
			for (int x = 0; x < width; ++x)
			{
				// Generate Triangles				
				int squareIndex 	= z * width + x;
				
				int triangleOffset 	= squareIndex * 6;
				int squareOffset 	= z * verticeX + x;
				
				// First Triangle
				triangles[triangleOffset + 0] = squareOffset + 0;
				triangles[triangleOffset + 1] = squareOffset + verticeX + 0;
				triangles[triangleOffset + 2] = squareOffset + verticeX + 1;
				// Second Triangle
				triangles[triangleOffset + 3] = triangles[triangleOffset + 0];
				triangles[triangleOffset + 4] = triangles[triangleOffset + 2];
				triangles[triangleOffset + 5] = squareOffset + 1;
			}
		}
		
		// Using our vertex, triangles and normals we create a mesh.
		Mesh mesh 		= new Mesh();
		mesh.name 		= "CubicMap";
		
		mesh.vertices 	= vertices;
		mesh.normals 	= normals;
		mesh.uv 		= uvCoods;
		mesh.triangles 	= triangles;
		
		return mesh;
	}
	// Generate a hexagonal world.
	//http://www.redblobgames.com/grids/hexagons/#wraparound
	//http://goo.gl/dldzPC
	/*private void GenerateHexagonalMap ()
	{
		int tileCount = width * height;
		int triangleCount = tileCount * 4;

		int verticeX = width + 1;
		int verticeZ = height + 1;
		int verticeCount = verticeX * vertiexZ;

		// Generate the mesh data.
		Vector3[] vertices = new Vector3[verticeCount];
		Vector3[] normals = new Vector3[verticeCount];
		Vector2[] uvCoods = new Vector2[verticeCount];
		int[] triangles = new int[triangleCount * 3];

		for (int z = 0; z < verticeZ; ++z)
		{
			for (int x = 0; x < verticeX; ++x)
			{
				// Generate Vertex Data
				vertices[z * width + x] = new Vector3 (x * scale, 0, z * scale);
				normals[z * width + x] 	= new Vector3.up;
				uvCoods[z * width + x] 	= new Vector2 ((float) x / verticeX, (float) z / verticeZ); // 1 to 1 relationship.

				// Generate Triangles				
				int squareIndex = z * width + x;
				int triangleIndex = squareIndex * 6;

				int offsetX = z * verticeX + x;

				triangles[triangleIndex + 0] = offset + 0;
				triangles[triangleIndex + 1] = offset + verticeX + 0;
				triangles[triangleIndex + 2] = offset + verticeX + 1;

				triangles[triangleIndex + 3] = offsetX + 0;
				triangles[triangleIndex + 4] = offsetX + verticeX + 1;
				triangles[triangleIndex + 5] = offsetX + 1;
			}
		}
	}
	
	verticesFlat[] = {     
    0.0f,   0.0f, 0.0f,    //center
    -0.5f,   1.0f, 0.0f,    // left top
    0.5f,   1.0f, 0.0f,    // right top
    1.0f,   0.0f, 0.0f,    // right
    0.5f,   -1.0f, 0.0f,    // right bottom
    -0.5f,  -1.0f, 0.0f,    // left bottom
    -1.0f,   0.0f, 0.0f,     // left
};
	*/
}