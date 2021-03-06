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
				grid[x, y] = Instantiate(tilePrefab, new Vector3(worldPoint.x, 0f, worldPoint.z), Quaternion.identity); // creates the new node with walkable and world point
				grid[x, y].transform.SetParent(tiles.transform, true);
				grid[x, y].SetActive(false);
				grid[x, y].GetComponent<Node>().setPosX(x);
				grid[x, y].GetComponent<Node>().setPosY(y);
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

	public int getSizeX()
    {
		return gridSizeX;
    }

	public int getSizeY()
    {
		return gridSizeY;
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
					// Near roads
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

					// Adyacent to road
					/*for (int k = -1; k != 2; k++)
					{
						if (k + i > 0 && k + i < gridSizeX)
						{
							for (int h = -1; h != 2; h++)
							{
								if (h + j > 0 && h + j < gridSizeX)
								{
									grid[k + i, h + j].GetComponent<Node>().setAdyacentRoad(true);
								}
							}
						}
					}*/

					for (int k = -1; k != 2; k++)
					{
						if (k + i > 0 && k + i < gridSizeX)
						{
							grid[k + i, j].GetComponent<Node>().setAdyacentRoad(true);
						}
					}

					for (int h = -1; h != 2; h++)
					{
						if (h + j > 0 && h + j < gridSizeX)
						{
							grid[i, j+h].GetComponent<Node>().setAdyacentRoad(true);
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

					// Adyacent to road
					for (int k = -1; k != 2; k++)
					{
						if (k + i > 0 && k + i < gridSizeX)
						{
							for (int h = -1; h != 2; h++)
							{
								if (h + j > 0 && h + j < gridSizeX)
								{
									grid[k + i, h + j].GetComponent<Node>().setAdyacentRoad(true);
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

	// Make adyacent roads tile visible
	public void setTilesAdyacentRoadActive(bool ac)
	{
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				if (grid[i, j].GetComponent<Node>().isAdyacentRoad())
				{
					grid[i, j].SetActive(ac);

					if (grid[i, j].GetComponent<Node>().isOcupied())
						grid[i, j].SetActive(false);
				}
			}
		}
	}

	// Get a list of gameobjects (nodes)
	public List<GameObject> getNodes(int width, int height, Node actualNode)
    {
		List<GameObject> res = new List<GameObject>();

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				res.Add(grid[i + actualNode.getPosX(), j + actualNode.getPosY()]);
			}
		}

		return res;
	}

	// True if all the nodes are free
	public bool areNodesFree(int width, int height, Node actualNode)
    {
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if(grid[i + actualNode.getPosX(), j + actualNode.getPosY()].GetComponent<Node>().isOcupied())
					return false;
			}
		}

		return true;
	}

	// Set nodes occupied
	public void setNodesOccupied(int width, int height, Node actualNode)
    {
		for(int i = 0; i < width; i++)
        {
			for (int j = 0; j < height; j++)
			{
				grid[i + actualNode.getPosX(), j + actualNode.getPosY()].GetComponent<Node>().setOcupied(true);
			}
		}

	}

	// Set nodes unoccupied
	public void setNodesUnoccupied(int width, int height, Node actualNode)
	{
		actualNode.setOcupied(false);

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				grid[i + actualNode.getPosX(), j + actualNode.getPosY()].GetComponent<Node>().setOcupied(false);
			}
		}
	}

	// Make visible the line of roads available
	public void setTilesLineRoadVisible(Node roadNode)
    {
		// Left
		for(int i = 1; i < gridSizeX; i++)
        {
			if (roadNode.getPosX() - i == 0 || grid[roadNode.getPosX() - i, roadNode.getPosY()].GetComponent<Node>().isOcupied())
				break;
            else
            {
				grid[roadNode.getPosX() - i, roadNode.getPosY()].SetActive(true);
			}
        }

		// Right
		for(int i = 1; i < gridSizeX; i++)
        {
			if (roadNode.getPosX() + i == gridSizeX || grid[roadNode.getPosX() + i, roadNode.getPosY()].GetComponent<Node>().isOcupied())
				break;
			else
			{
				grid[roadNode.getPosX() + i, roadNode.getPosY()].SetActive(true);
			}
		}

		// Up
		for (int i = 1; i < gridSizeY; i++)
		{
			if (roadNode.getPosY() + i == gridSizeY || grid[roadNode.getPosX(), roadNode.getPosY() + i].GetComponent<Node>().isOcupied())
				break;
			else
			{
				grid[roadNode.getPosX(), roadNode.getPosY() + i].SetActive(true);
			}
		}

		// Down
		for (int i = 1; i < gridSizeY; i++)
		{
			if (roadNode.getPosY() - i == 0 || grid[roadNode.getPosX(), roadNode.getPosY() - i].GetComponent<Node>().isOcupied())
				break;
			else
			{
				grid[roadNode.getPosX(), roadNode.getPosY() - i].SetActive(true);
			}
		}
	}
}


