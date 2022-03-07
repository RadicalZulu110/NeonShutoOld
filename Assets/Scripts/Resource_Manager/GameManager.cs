using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private int NoBuildings;
	public int gold;
	public int energy;
	public int food;
	public int pop;
	public int futurePop;

	public Text goldDisplay;
	public Text energyDisplay;
	public Text foodDisplay;
	public Text popDisplay;

    private void Start()
    {
		NoBuildings = 0;
    }

    private void Update()
	{
		goldDisplay.text = gold.ToString();
		energyDisplay.text = energy.ToString();
		foodDisplay.text = food.ToString();
		popDisplay.text = (futurePop * NoBuildings).ToString();
	}
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

	public int GetFuturePop()
    {
		return futurePop;
    }

	public void SetFuturePop(int futurePopulation)
    {
		futurePop = futurePopulation;
    }
}
