using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost : MonoBehaviour
{
    public int width, height;

    //set cost of the building type
    public int GoldCost;
    public int FoodCost;
    public int EnergyCost;
    public int StoneCost;
    public int CrystalCost;
    public int PopCost;

    //set amount of reasource to increase
    public int GoldIncrease;
    public int FoodIncrease;
    public int EnergyIncrease;
    public int StoneIncrease;
    public int CrystalIncrease;
    public int PopIncrease;

    //set time between increases in reasources
    public float timeBtwIncrease;
    private float nextIncreaseTime;

    private GameManager gm;

    public int width, height;
    private List<GameObject> nodes; // Nodes where the building is built

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.SetFuturePop(PopIncrease);
        nodes = new List<GameObject>();
    }

    //Doing somthing wrong here 
    private void Update()
    {
        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncrease;
            gm.gold += GoldIncrease;
            gm.energy += EnergyIncrease;
            gm.food += FoodIncrease;
            gm.stone += StoneIncrease;
            gm.crystal += CrystalIncrease;
        }
    }

    public int GetPopulation()
    {
        return PopIncrease;
    }

    public int getGridWidth()
    {
        return width;
    }

    public int getGridHeight()
    {
        return height;
    }

    public List<GameObject> getNodesBuilt()
    {
        return nodes;
    }

    public void setNodesBuilt(List<GameObject> ns)
    {
        nodes = ns;
    }

    public void setWH(int w, int h)
    {
        width = w;
        height = h;
    }

    // Change the height with the width and viceversa
    public void changeWH()
    {
        int haux = height;
        height = width;
        width = haux;
    }

    public int getGridWidth()
    {
        return width;
    }

    public int getGridHeight()
    {
        return height;
    }

    public void setWH(int w, int h)
    {
        width = w;
        height = h;
    }

    // Change the height with the width and viceversa
    public void changeWH()
    {
        int haux = height;
        height = width;
        width = haux;
    }
}
