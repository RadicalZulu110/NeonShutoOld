using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadButton : MonoBehaviour
{
    public GameObject RoadText;

    // Start is called before the first frame update
    void Start()
    {
        RoadText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        RoadText.SetActive(true);
    }

    public void OnMouseExit()
    {
        RoadText.SetActive(false);
    }
}
