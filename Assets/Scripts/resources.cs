using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour
{
    int food = 0;
    int money= 0;
    int numberofbuildings =1;
    int power= 10;
    int powercollected = 0;
    int pop = 0;
    int usedpower = 0;
    int costfood = 0;
    int costpower = 0;
    int collectedfood = 10;
    int water = 0;
    int costwater = 0;
    int usedwater = 0;
    int usedfood = 0;
    int collectedwater =0;
    // Start is called before the first frame update
    void Start()
    {
        initialstart();
        StartCoroutine(moneycollection());
         StopCoroutine(moneycollection());
        
    }

    // Update is called once per frame
    void Update()
    {
        
         GameObject[]buildingcount = GameObject.FindGameObjectsWithTag("buildings");
         int numberofbuildings = buildingcount.Length;
         Debug.Log(numberofbuildings);
        
        usedwater = numberofbuildings * 10;
        usedpower = numberofbuildings * 10;
        usedfood = numberofbuildings;
        pop = numberofbuildings;
         
        //  food = food - usedfood;
        //  power = powercollected / numberofbuildings;
        // power = power - usedpower;
        //  Debug.Log(power + " power");
        //  food = food + collectedfood - usedfood;
        //  Debug.Log(food + " food "+ " ( " +collectedfood + " )");
        //  water = water - usedwater + collectedwater;
        Debug.Log(power + "power");
money = numberofbuildings * power;
StartCoroutine(moneycollection());
       moneycollection();
       
         
    }

        IEnumerator moneycollection()
    {
       
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
    //  money = money + 10;
    yield return new WaitForSeconds(5);
    StopCoroutine(moneycollection());
    
}
    
void collecting()
{
    int collected = 0;

}
    void buildingplaced()
    {
        numberofbuildings++;
    }

    void collectedpower()
    {
        powercollected++;

        sellpower();
    }

    void sellpower()
    {
        int value = powercollected /2;
        money = money + value;
    Debug.Log(powercollected + " sold" + value + " recieved");  
        powercollected=0;
        value = 0;
    }

    void sellfood()
    {
    int value = food /2;
    money = money + value;
        food = 0;
    }

    void buyfood()
    {
        int boughtfood = 0;
        int totalcost = boughtfood * costfood;
      money =  money - costfood;
      food = food + boughtfood;

    }
    
    void buypower()
    {
        int boughtpower= 0;
        costpower = boughtpower * costpower;
      money =  money - costpower;
      power = power + boughtpower;
    }

void buywater()
{
    int boughtwater = 0;
    costwater = boughtwater * costwater;
    money = money - costwater;
    water = money + costwater;
}
    void initialstart()
    {
        power = 1000;
        costpower = 10;
        costfood = 20;
        money = 1000;
        food = 1000;
        water = 1000;

    }
}
