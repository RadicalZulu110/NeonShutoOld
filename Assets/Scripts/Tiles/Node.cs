using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{ // defines the nodes

	public bool walkable; // walkable for cars and characters
	public Vector3 worldPosition;
	public bool ocupied, nearRoad, road, initial;

	public Node()
	{
		ocupied = false;
		nearRoad = false;
		road = false;
		initial = false;
	}

	// Getters
	public bool isOcupied()
    {
		return ocupied;
    }

	public bool isNearRoad()
    {
		return nearRoad;
    }

	public bool isRoad()
    {
		return road;
    }

	public bool isInitial()
    {
		return initial;
    }

	public Vector3 getWorldPosition()
    {
		return worldPosition;
    }

	// Setters
	public void setOcupied(bool o)
    {
		ocupied = o;
		if (ocupied == false)
			road = false;
    }

	public void setNearRoad(bool nr)
    {
		nearRoad = nr;
    }

	public void setRoad(bool r)
    {
		road = r;
    }

	public void setInitial(bool i)
    {
		initial = i;
    }

	public void setWorldPosition(Vector3 wp)
    {
		worldPosition = wp;
    }
}
