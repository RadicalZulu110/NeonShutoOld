using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBuildingButton : MonoBehaviour
{
    public GameObject StartBuildingText;

    void Start()
    {
        StartBuildingText.SetActive(false);
    }

    public void OnOver()
    {
        StartBuildingText.SetActive(true);
    }

    public void OnExit()
    {
        StartBuildingText.SetActive(false);
    }
}
