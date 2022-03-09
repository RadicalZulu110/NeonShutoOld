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

    public void OnMouseOver()
    {
        T1HouseText.SetActive(true);
    }

    public void OnMouseExit()
    {
        T1HouseText.SetActive(false);
    }
}
