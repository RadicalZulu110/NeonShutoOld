using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1FoodBuildingButton : MonoBehaviour
{
    public GameObject T1FoodText;

    void Start()
    {
        T1FoodText.SetActive(false);
    }

    public void OnOver()
    {
        T1FoodText.SetActive(true);
    }

    public void OnExit()
    {
        T1FoodText.SetActive(false);
    }
}
