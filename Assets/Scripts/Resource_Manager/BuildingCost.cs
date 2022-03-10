using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost : MonoBehaviour
{
    public int GoldCost;
    public int FoodCost;
    public int EnergyCost;
    public int PopCost;

    public int GoldIncrease;
    public int FoodIncrease;
    public int EnergyIncrease;
    public int PopIncrease;

    public float timeBtwIncrease;
    private float nextIncreaseTime;

    private GameManager gm;

    public int width, height;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.SetFuturePop(PopIncrease);
    }

    private void Update()
    {
        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncrease;
            gm.gold += GoldIncrease;
            gm.energy += EnergyIncrease;
            gm.food += FoodIncrease;
        }
    }

    public int GetPopulation()
    {
        return PopIncrease;
    }

    public int getHGridWidth()
    {
        return width;
    }

    public int getHGridHeight()
    {
        return height;
    }
}
