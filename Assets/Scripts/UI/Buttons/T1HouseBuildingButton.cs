using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1HouseBuildingButton : MonoBehaviour
{
    public GameObject T1HouseText;

    void Start()
    {
        T1HouseText.SetActive(false);
    }

    public void OnOver()
    {
        T1HouseText.SetActive(true);
    }

    public void OnExit()
    {
        T1HouseText.SetActive(false);
    }
}