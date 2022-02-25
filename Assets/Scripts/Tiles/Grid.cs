using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public GameObject tilePrefab;
	public GameObject tiles;

	public Vector2 gridWorldSize; // defines the grid size
	public float nodeRadius; // radius of each node/tile
	Node[,] grid;
	public LayerMask unwalkable;
	float nodeDiameter; // node diameter = node radius * 2
	int gridSizeX, gridSizeY; // defintion of x and y

	void Start()
	{ // start function to create the grid and find the world size and diameter
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
		CreateGrid(); // creates the grid using the creategrid() function
		this.gameObject.transform.localScale = new Vector3(gridWorldSize.x, 0.1f, gridWorldSize.y);
	}

	void CreateGrid()
	{ // start of function
		grid = new Node[gridSizeX, gridSizeY]; //creates the new grid with the gridsizex and y parameters
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; // defines the world bottom left

		for (int x = 0; x < gridSizeX; x++)
		{ // while x = 0 x is less then gridsize x
			for (int y = 0; y < gridSizeY; y++)
			{// while y = 0 y is less then gridsize y
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkable));
				grid[x, y] = new Node(walkable, worldPoint); // creates the new node with walkable and world point
				GameObject tile = Instantiate(tilePrefab, new Vector3(worldPoint.x, 0.1f, worldPoint.z), Quaternion.identity);
				tile.transform.SetParent(tiles.transform, true);
			}
		}
	}


	public Node NodeFromWorldPoint(Vector3 worldPosition)
	{ // sets node from the world point
		float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX); // rounds the x value to the nearest whole number
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY); // rounds the y value to the nearest whole number
		return grid[x, y]; // returns the grid with the x and y values
	}

	/*void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));


		if (grid != null)
		{
			foreach (Node n in grid)
			{
				Gizmos.color = (n.walkable) ? Color.white : Color.red; // if walkable change colour to white else red
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f)); // draws a cube on each node
			}
		}
	}*/

	public Node[,] getGrid()
    {
		return grid;
    }
}


