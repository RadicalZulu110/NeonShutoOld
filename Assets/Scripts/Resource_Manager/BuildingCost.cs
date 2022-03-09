using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost : MonoBehaviour
{
    //set cost of the building type
    public int GoldCost;
    public int FoodCost;
    public int EnergyCost;
    public int PopCost;

    //set amount of reasource to increase
    public int GoldIncrease;
    public int FoodIncrease;
    public int EnergyIncrease;
    public int PopIncrease;

    //set time between increases in reasources
    public float timeBtwIncrease;
    private float nextIncreaseTime;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.AddPop(PopIncrease);
        gm.AddGold(GoldIncrease);
        gm.AddFood(FoodIncrease);
        gm.AddEnergy(EnergyIncrease);
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
        }
    }

    public int GetPopulation()
    {
        return PopIncrease;
    }

    public int GetGoldIncrease()
    {
        return GoldIncrease;
    }

    public int GetFoodIncrease()
    {
        return FoodIncrease;
    }

    public int GetEnergyIncrease()
    {
        return EnergyIncrease;
    }
}
