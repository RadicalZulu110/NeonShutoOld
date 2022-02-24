using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private GameObject buildingToPlace;
    public CustomCursor customCursor;
    public Grid grid;
    public Node[,] tiles;
    public Camera camera;

    Node nearNode;
    float distanceNode, dist;
    bool isDeleting;

    // Start is called before the first frame update
    void Start()
    {
        tiles = grid.getGrid();
        isDeleting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiles == null)
            tiles = grid.getGrid();

        if (Input.GetKeyDown(KeyCode.Mouse0) && buildingToPlace != null)
        {
            nearNode = null;
            distanceNode = float.MaxValue;
            foreach(Node tile in tiles)
            {
                dist = Vector3.Distance(tile.worldPosition, customCursor.gameObject.transform.position);
                if(dist < distanceNode)
                {
                    distanceNode = dist;
                    nearNode = tile;
                }
            }

            Instantiate(buildingToPlace, nearNode.worldPosition, Quaternion.identity);
            buildingToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && isDeleting)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.gameObject != null)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    public void createBuilding(GameObject building)
    {
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
        buildingToPlace = building;
    }

    public void deleteBuilding()
    {
        if (isDeleting)
            isDeleting = false;
        else
            isDeleting = true;
    }
}
