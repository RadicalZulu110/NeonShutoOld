using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private GameObject buildingToPlace, roadToPlace;
    public CustomCursor customCursor, customCursorRoad;
    public Grid grid;
    public GameObject[,] tiles;
    public Camera camera;

    GameObject nearNode;
    float distanceNode, dist;
    bool isDeleting;

    // Start is called before the first frame update
    void Start()
    {
        
        isDeleting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grid == null)
            grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();

        if (tiles == null)
            tiles = grid.getGrid();

        // Create building
        if (Input.GetKeyDown(KeyCode.Mouse0) && buildingToPlace != null)
        {
            nearNode = null;
            distanceNode = float.MaxValue;
            for(int i=0; i<tiles.GetLength(0); i++)
            {
                for(int j=0; j<tiles.GetLength(1); j++)
                {
                    if (!tiles[i,j].GetComponent<Node>().isOcupied() && tiles[i,j].activeInHierarchy)
                    {
                        dist = Vector3.Distance(tiles[i, j].transform.position, customCursor.gameObject.transform.position);
                        if (dist < distanceNode)
                        {
                            distanceNode = dist;
                            nearNode = tiles[i, j];
                        }
                    }
                }
            }

            Instantiate(buildingToPlace, new Vector3(nearNode.transform.position.x, 2, nearNode.transform.position.z), Quaternion.identity);
            nearNode.GetComponent<Node>().setOcupied(true);
            buildingToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
        }

        // Create road
        if (Input.GetKeyDown(KeyCode.Mouse0) && roadToPlace != null)
        {
            nearNode = null;
            distanceNode = float.MaxValue;
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (!tiles[i, j].GetComponent<Node>().isOcupied())
                    {
                        dist = Vector3.Distance(tiles[i, j].transform.position, customCursorRoad.gameObject.transform.position);
                        if (dist < distanceNode)
                        {
                            distanceNode = dist;
                            nearNode = tiles[i, j];
                        }
                    }
                }
            }

            Instantiate(roadToPlace, new Vector3(nearNode.transform.position.x, 0.5f, nearNode.transform.position.z), Quaternion.identity);
            nearNode.GetComponent<Node>().setOcupied(true);
            nearNode.GetComponent<Node>().setRoad(true);
            roadToPlace = null;
            customCursorRoad.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            grid.checkTilesRoads();
        }

        // Delete building or road
        if (Input.GetKeyDown(KeyCode.Mouse0) && isDeleting)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.gameObject != null && (hitInfo.collider.gameObject.tag == "Buildings" || 
                                                            hitInfo.collider.tag == "Road"))
                {
                    grid.getTile(hitInfo.collider.gameObject.transform.position).GetComponent<Node>().setOcupied(false);
                    grid.checkTilesRoads();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    // Button event to create a building
    public void createBuilding(GameObject building)
    {
        grid.setTilesNearRoadActive(true);
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
        buildingToPlace = building;
        isDeleting = false;
    }

    // Button event to create a road
    public void createRoad(GameObject road)
    {
        grid.setTilesActive(true);
        customCursorRoad.gameObject.SetActive(true);
        Cursor.visible = false;
        roadToPlace = road;
        isDeleting = false;
    }

    // Button event to delete a building or a road
    public void deleteBuilding()
    {
        if (isDeleting)
            isDeleting = false;
        else
            isDeleting = true;
    }
}
