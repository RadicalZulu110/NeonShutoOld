using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private GameObject buildingToPlace, roadToPlace, initialToPlace;
    public CustomCursor customCursor, customCursorRoad, customCursorInitial;
    public Grid grid;
    public GameObject[,] tiles;
    public Camera camera;

    GameObject nearNode;
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

        // Cancel construction with escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buildingToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            roadToPlace = null;
            customCursorRoad.gameObject.SetActive(false);
            initialToPlace = null;
            customCursorInitial.gameObject.SetActive(false);
        }

        // Create building
        if (Input.GetKeyDown(KeyCode.Mouse0) && buildingToPlace != null)
        {
            nearNode = getNearestNode(customCursor.gameObject);

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
            nearNode = getNearestNode(customCursorRoad.gameObject);

            Instantiate(roadToPlace, new Vector3(nearNode.transform.position.x, 0.5f, nearNode.transform.position.z), Quaternion.identity);
            nearNode.GetComponent<Node>().setOcupied(true);
            nearNode.GetComponent<Node>().setRoad(true);
            roadToPlace = null;
            customCursorRoad.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            grid.checkTilesRoads();
        }

        // Create initial building
        if (Input.GetKeyDown(KeyCode.Mouse0) && initialToPlace != null)
        {
            nearNode = getNearestNode(customCursorInitial.gameObject);

            Instantiate(initialToPlace, new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z), Quaternion.identity);
            nearNode.GetComponent<Node>().setOcupied(true);
            nearNode.GetComponent<Node>().setInitial(true);
            initialToPlace = null;
            customCursorInitial.gameObject.SetActive(false);
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

    // Private functions
    // Return the gameobject node nearest to the gameobject given
    private GameObject getNearestNode(GameObject gObject)
    {
        GameObject res = null;
        float distanceNode = float.MaxValue;
        float dist = 0;
        
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                if (!tiles[i, j].GetComponent<Node>().isOcupied() && tiles[i, j].activeInHierarchy)
                {
                    dist = Vector3.Distance(tiles[i, j].transform.position, gObject.transform.position);
                    if (dist < distanceNode)
                    {
                        distanceNode = dist;
                        res = tiles[i, j];
                    }
                }
            }
        }

        return res;
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
        grid.setTilesAdyacentRoadActive(true);
        customCursorRoad.gameObject.SetActive(true);
        Cursor.visible = false;
        roadToPlace = road;
        isDeleting = false;
    }

    // Button event to create initial building
    public void createInitial(GameObject building)
    {
        grid.setTilesActive(true);
        customCursorInitial.gameObject.SetActive(true);
        Cursor.visible = false;
        initialToPlace = building;
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
