using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
	private int NoBuildings;
	public int gold;
	public int currentGold;
	private int futureGold;

	private int NoBatterys;
	public int energy;
	public int currentEnergy;
	private int futureEnergy;

	private int NoFarms;
	public int food;
	public int currentFood;
	private int futureFood;
	
	public int pop;
	public int futurePop;
	public int currentPop;


	public Text goldDisplay;
	public Text energyDisplay;
	public Text foodDisplay;
	public Text popDisplay;

	public CustomCursor customCursor;

	private void Start()
	{
		NoBuildings = 0;
		NoFarms = 0;
		NoBatterys = 0;
	}

	private void Update()
	{
		goldDisplay.text = (gold).ToString() + "(" + (currentGold).ToString() + ")";
		energyDisplay.text = (energy).ToString() + "(" + (currentEnergy).ToString() + ")";
		foodDisplay.text = (food).ToString() + "(" + (currentFood).ToString() + ")";
		popDisplay.text = (currentPop).ToString();
	}

	//deduction of reasources
	public void BuyBuilding(BuildingCost building)
	{
		if (gold >= building.GoldCost)
		{
			gold -= building.GoldCost;
		}

		if (energy >= building.EnergyCost)
		{
			energy -= building.EnergyCost;
		}

		if (food >= building.FoodCost)
		{
			food -= building.FoodCost;
		}

		if (pop >= building.PopCost)
		{
			pop -= building.PopCost;
		}
	}

	public int GetNoBuildings()
	{
		return NoBuildings;
	}

	public void SetNoBuilding(int BuildingNo)
	{
		NoBuildings = BuildingNo;
	}

	public int GetNoFarms()
	{
		return NoFarms;
	}

	public void SetNoFarms(int FarmNo)
    {
		NoFarms = FarmNo;
    }

	public int GetNoBatterys()
    {
		return NoBatterys;
    }

	public void SetNoBatterys(int BatteryNo)
    {
		NoBatterys = BatteryNo;
    }

	public int GetFuturePop()
    {
		return futurePop;
    }

	public void SetFuturePop(int futurePopulation)
    {
		futurePop = futurePopulation;
    }

	public int GetFutureGold()
    {
		return gold;
    }

	public void SetFutureGold(int futureG)
    {
		futureGold = futureG;
    }

	public int GetFutureEnergy()
    {
		return energy;
    }

	public void SetFutureEnergy(int futureE)
    {
		futureEnergy = futureE;
    }

	public int GetFutureFood()
    {
		return food;
    }

	public void SetFutureFood(int futureF)
    {
		futureFood = futureF;
    }

	public void AddGold(int gold)
    {
		currentGold += gold;
    }

	public void AddFood(int food)
    {
		currentFood += food;
    }

	public void AddEnergy(int Energy)
    {
		currentEnergy += Energy;
    }

	public void AddPop(int pop)
    {
		currentPop += pop;
    }
}
