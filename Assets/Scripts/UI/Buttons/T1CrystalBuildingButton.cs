using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1CrystalBuildingButton : MonoBehaviour
{
    public GameObject T1CrystalFarmText;

    void Start()
    {
        T1CrystalFarmText.SetActive(false);
    }

    public void OnOver()
    {
        T1CrystalFarmText.SetActive(true);
    }

    public void OnExit()
    {
        T1CrystalFarmText.SetActive(false);
    }
}
