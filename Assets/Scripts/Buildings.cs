using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private GameObject buildingToPlace, roadToPlace, initialToPlace, farmToPlace, batteryToPlace;
    public CustomCursor customCursor, customCursorRoad, customCursorInitial;
    public Grid grid;
    public GameObject[,] tiles;
    public Camera camera;
    public GameObject initialShadow, roadShadow, buildingShadow;
    public AudioSource buildingPlaceSound;
    public ParticleSystem buildingPlaceParticles;

    GameObject nearNode;
    bool isDeleting;
    public GameManager gameManager;//need to change naming convention for this to be somthing else rather than gameManager

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


        if (initialShadow.activeInHierarchy)
        {
            nearNode = getNearestNode(customCursorInitial.gameObject);
            initialShadow.transform.position = new Vector3(nearNode.transform.position.x, 0.1f, nearNode.transform.position.z);
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateAroundY(initialShadow, 90);
            }
        }

        if (roadShadow.activeInHierarchy)
        {
            nearNode = getNearestNode(customCursorRoad.gameObject);
            roadShadow.transform.position = new Vector3(nearNode.transform.position.x, 0.1f, nearNode.transform.position.z);
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateAroundY(roadShadow, 90);
            }
        }

        if (buildingShadow.activeInHierarchy)
        {
            nearNode = getNearestNode(customCursor.gameObject);
            buildingShadow.transform.position = new Vector3(nearNode.transform.position.x, 0.1f, nearNode.transform.position.z);
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateAroundY(buildingShadow, 90);
            }
        }

        // Cancel construction with escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buildingToPlace = null;
            farmToPlace = null;
            batteryToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            roadToPlace = null;
            customCursorRoad.gameObject.SetActive(false);
            initialToPlace = null;
            customCursorInitial.gameObject.SetActive(false);
            initialShadow.SetActive(false);
            roadShadow.SetActive(false);
            buildingShadow.SetActive(false);
        }

        // Create building
        if (Input.GetKeyDown(KeyCode.Mouse0) && buildingToPlace != null)
        {
            nearNode = getNearestNode(customCursor.gameObject);

            Instantiate(buildingToPlace, new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z), buildingShadow.transform.rotation);
            buildingPlaceSound.Play();
            buildingPlaceParticles.transform.position = new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z);
            buildingPlaceParticles.Play();
            nearNode.GetComponent<Node>().setOcupied(true);
            gameManager.BuyBuilding(buildingToPlace.GetComponent<BuildingCost>());
            buildingToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            gameManager.SetNoBuilding(gameManager.GetNoBuildings() + 1);
            grid.setTilesActive(false);
            buildingShadow.SetActive(false);
        }

        //Create farm
        if (Input.GetKeyDown(KeyCode.Mouse0) && farmToPlace != null)
        {
            nearNode = getNearestNode(customCursor.gameObject);

            Instantiate(farmToPlace, new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z), buildingShadow.transform.rotation);
            buildingPlaceSound.Play();
            buildingPlaceParticles.transform.position = new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z);
            buildingPlaceParticles.Play();
            nearNode.GetComponent<Node>().setOcupied(true);
            gameManager.BuyBuilding(farmToPlace.GetComponent<BuildingCost>());
            farmToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            gameManager.SetNoFarms(gameManager.GetNoFarms() + 1);
            grid.setTilesActive(false);
            buildingShadow.SetActive(false);
        }

        //Create battery
        if (Input.GetKeyDown(KeyCode.Mouse0) && batteryToPlace != null)
        {
            nearNode = getNearestNode(customCursor.gameObject);

            Instantiate(batteryToPlace, new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z), buildingShadow.transform.rotation);
            buildingPlaceSound.Play();
            buildingPlaceParticles.transform.position = new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z);
            buildingPlaceParticles.Play();
            nearNode.GetComponent<Node>().setOcupied(true);
            gameManager.BuyBuilding(batteryToPlace.GetComponent<BuildingCost>());
            batteryToPlace = null;
            customCursor.gameObject.SetActive(false);
            Cursor.visible = true;
            gameManager.SetNoBatterys(gameManager.GetNoBatterys() + 1);
            grid.setTilesActive(false);
            buildingShadow.SetActive(false);
        }

        // Create road
        if (Input.GetKeyDown(KeyCode.Mouse0) && roadToPlace != null)
        {
            nearNode = getNearestNode(customCursorRoad.gameObject);

            Instantiate(roadToPlace, new Vector3(nearNode.transform.position.x, 0.5f, nearNode.transform.position.z), roadShadow.transform.rotation);
            buildingPlaceSound.Play();
            buildingPlaceParticles.transform.position = new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z);
            buildingPlaceParticles.Play();
            nearNode.GetComponent<Node>().setOcupied(true);
            nearNode.GetComponent<Node>().setRoad(true);
            roadToPlace = null;
            customCursorRoad.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            grid.checkTilesRoads();
            roadShadow.SetActive(false);
        }

        // Create initial building
        if (Input.GetKeyDown(KeyCode.Mouse0) && initialToPlace != null)
        {
            Instantiate(initialToPlace, new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z), initialShadow.transform.rotation);
            buildingPlaceSound.Play();
            buildingPlaceParticles.transform.position = new Vector3(nearNode.transform.position.x, 0, nearNode.transform.position.z);
            buildingPlaceParticles.Play();
            nearNode.GetComponent<Node>().setOcupied(true);
            nearNode.GetComponent<Node>().setInitial(true);
            initialToPlace = null;
            customCursorInitial.gameObject.SetActive(false);
            Cursor.visible = true;
            grid.setTilesActive(false);
            grid.checkTilesRoads();
            initialShadow.SetActive(false);
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
                    if (hitInfo.collider.gameObject.tag == "Buildings")
                    {
                        gameManager.AddPop(- hitInfo.collider.gameObject.GetComponent <BuildingCost>().GetPopulation());
                        gameManager.AddFood(- hitInfo.collider.gameObject.GetComponent<BuildingCost>().GetFoodIncrease());
                        gameManager.AddGold(- hitInfo.collider.gameObject.GetComponent<BuildingCost>().GetGoldIncrease());
                        gameManager.AddEnergy(- hitInfo.collider.gameObject.GetComponent<BuildingCost>().GetEnergyIncrease());
                    }
                    grid.getTile(hitInfo.collider.gameObject.transform.position).GetComponent<Node>().setOcupied(false);
                    grid.checkTilesRoads();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    /********************************************************************************************************************************/

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

    // Rotate a gameobject around the axis y
    private void rotateAroundY(GameObject go, float degrees)
    {
        go.transform.Rotate(0, degrees, 0);
    }

    /********************************************************************************************************************************/

    // Button event to create a building
    public void createBuilding(GameObject building)
    {
        if (gameManager.GetFutureGold() - building.GetComponent<BuildingCost>().GoldCost < 0 ||
            gameManager.GetFutureFood() - building.GetComponent<BuildingCost>().FoodCost < 0 ||
            gameManager.GetFutureEnergy() - building.GetComponent<BuildingCost>().EnergyCost < 0) return;

        grid.setTilesNearRoadActive(true);
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
        buildingToPlace = building;
        isDeleting = false;
        buildingShadow.SetActive(true);
    }

    //button event to create a farm
    public void createFarm(GameObject farm)
    {
        if (gameManager.GetFutureGold() - farm.GetComponent<BuildingCost>().GoldCost < 0 ||
            gameManager.GetFutureFood() - farm.GetComponent<BuildingCost>().FoodCost < 0 ||
            gameManager.GetFutureEnergy() - farm.GetComponent<BuildingCost>().EnergyCost < 0) return;

        grid.setTilesNearRoadActive(true);
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
        farmToPlace = farm;
        isDeleting = false;
        buildingShadow.SetActive(true);
    }

    //button event to create a battery
    public void createBattery(GameObject battery)
    {
        if (gameManager.GetFutureGold() - battery.GetComponent<BuildingCost>().GoldCost < 0 ||
            gameManager.GetFutureFood() - battery.GetComponent<BuildingCost>().FoodCost < 0 ||
            gameManager.GetFutureEnergy() - battery.GetComponent<BuildingCost>().EnergyCost < 0) return;

        grid.setTilesNearRoadActive(true);
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
        farmToPlace = battery;
        isDeleting = false;
        buildingShadow.SetActive(true);
    }

    // Button event to create a road
    public void createRoad(GameObject road)
    {
        if (gameManager.GetFutureGold() - road.GetComponent<BuildingCost>().GoldCost < 0 ||
            gameManager.GetFutureFood() - road.GetComponent<BuildingCost>().FoodCost < 0 ||
            gameManager.GetFutureEnergy() - road.GetComponent<BuildingCost>().EnergyCost < 0) return;

        grid.setTilesAdyacentRoadActive(true);
        customCursorRoad.gameObject.SetActive(true);
        Cursor.visible = false;
        roadToPlace = road;
        isDeleting = false;
        roadShadow.SetActive(true);
    }

    // Button event to create initial building
    public void createInitial(GameObject building)
    {
        grid.setTilesActive(true);
        customCursorInitial.gameObject.SetActive(true);
        Cursor.visible = false;
        initialToPlace = building;
        isDeleting = false;
        initialShadow.SetActive(true);
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