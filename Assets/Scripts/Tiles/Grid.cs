using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public GameObject tilePrefab;
	public GameObject tiles;
	public int roadRadius, initialRadius;

	public Vector2 gridWorldSize; // defines the grid size
	public float nodeRadius; // radius of each node/tile
	GameObject[,] grid;
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
		grid = new GameObject[gridSizeX, gridSizeY]; //creates the new grid with the gridsizex and y parameters
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; // defines the world bottom left

		for (int x = 0; x < gridSizeX; x++)
		{ // while x = 0 x is less then gridsize x
			for (int y = 0; y < gridSizeY; y++)
			{// while y = 0 y is less then gridsize y
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkable));
				grid[x, y] = Instantiate(tilePrefab, new Vector3(worldPoint.x, 0.1f, worldPoint.z), Quaternion.identity); // creates the new node with walkable and world point
				grid[x, y].transform.SetParent(tiles.transform, true);
				grid[x, y].SetActive(false);
			}
		}
	}


	public GameObject NodeFromWorldPoint(Vector3 worldPosition)
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

	public GameObject[,] getGrid()
    {
		return grid;
    }

	public GameObject getTile(Vector3 position)
    {
		for(int i = 0; i<grid.GetLength(0); i++)
        {
			for(int j=0; j<grid.GetLength(1); j++)
            {

				if (position.x == grid[i,j].transform.position.x && position.z == grid[i, j].transform.position.z)
					return grid[i, j];
            }
        }

		return null;
    }

	// Check which tiles are near to a road and update the tiles
	public void checkTilesRoads()
    {
		// Erase every near road
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				grid[i, j].GetComponent<Node>().setNearRoad(false);
			}
		}

		// Check near road
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				// Check all roads
                if (grid[i, j].GetComponent<Node>().isRoad())
                {
					for(int k=-roadRadius; k != roadRadius+1; k++)
                    {
						if(k+i > 0 && k+i < gridSizeX)
                        {
							for (int h = -roadRadius; h != roadRadius+1; h++)
							{
								if(h+j > 0 && h+j < gridSizeX)
                                {
									grid[k + i, h + j].GetComponent<Node>().setNearRoad(true);
                                }
							}
						}
						
                    }
                }
                // Check the initial place
                if (grid[i, j].GetComponent<Node>().isInitial())
                {
					for (int k = -initialRadius; k != initialRadius + 1; k++)
					{
						if (k + i > 0 && k + i < gridSizeX)
						{
							for (int h = -initialRadius; h != initialRadius + 1; h++)
							{
								if (h + j > 0 && h + j < gridSizeX)
								{
									grid[k + i, h + j].GetComponent<Node>().setNearRoad(true);
								}
							}
						}

					}
				}
			}
		}
	}

	// Make all tiles visible or invisible
	public void setTilesActive(bool ac)
    {
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				grid[i, j].SetActive(ac);
				if (grid[i, j].GetComponent<Node>().isOcupied())
					grid[i, j].SetActive(false);
			}
		}
	}

	// Make near roads tile visible
	public void setTilesNearRoadActive(bool ac)
	{
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
                if (grid[i, j].GetComponent<Node>().isNearRoad())
                {
					grid[i, j].SetActive(ac);

					if (grid[i, j].GetComponent<Node>().isOcupied())
						grid[i, j].SetActive(false);
				}
			}
		}
	}
}


