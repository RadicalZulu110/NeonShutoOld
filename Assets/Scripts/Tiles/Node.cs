using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{ // defines the nodes

	public Vector3 worldPosition;
	public bool ocupied, nearRoad, adyacentRoad, road, initial;
	public int posX, posY;

	public Node()
	{
		ocupied = false;
		nearRoad = false;
		road = false;
		initial = false;
		adyacentRoad = false;
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

	public bool isAdyacentRoad()
	{
		return adyacentRoad;
	}

	public bool isRoad()
    {
		return road;
    }

	public bool isInitial()
    {
		return initial;
    }

	public int getPosX()
    {
		return posX;
    }

	public int getPosY()
	{
		return posY;
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

	public void setAdyacentRoad(bool ar)
	{
		adyacentRoad = ar;
	}

	public void setRoad(bool r)
    {
		road = r;
    }

	public void setInitial(bool i)
    {
		initial = i;
    }

	public void setPosX(int x)
    {
		posX = x;
    }

	public void setPosY(int y)
	{
		posY = y;
	}

	public void setWorldPosition(Vector3 wp)
    {
		worldPosition = wp;
    }
}
