using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{ // defines the nodes

	public bool walkable; // walkable for cars and characters
	public Vector3 worldPosition;
	public bool ocupied;

	public Node(bool _walkable, Vector3 _worldPos)
	{
		walkable = _walkable;
		worldPosition = _worldPos;
		ocupied = false;
	}

	public bool isOcupied()
    {
		return ocupied;
    }

	public void setOcupied(bool o)
    {
		ocupied = o;
    }
}
