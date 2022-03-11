using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1StoneBuildingButton : MonoBehaviour
{
    public GameObject T1StoneBuildingText;

    void Start()
    {
        T1StoneBuildingText.SetActive(false);
    }

    public void OnOver()
    {
        T1StoneBuildingText.SetActive(true);
    }

    public void OnExit()
    {
        T1StoneBuildingText.SetActive(false);
    }
}
