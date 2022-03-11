using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadButton : MonoBehaviour
{
    public GameObject RoadText;

    void Start()
    {
        RoadText.SetActive(false);
    }

    public void OnOver()
    {
        RoadText.SetActive(true);
    }

    public void OnExit()
    {
        RoadText.SetActive(false);
    }
}
