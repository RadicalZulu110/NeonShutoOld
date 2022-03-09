using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBuildingButton : MonoBehaviour
{
    public GameObject StartBuildingText;

    // Start is called before the first frame update
    void Start()
    {
        StartBuildingText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        StartBuildingText.SetActive(true);
    }

    public void OnMouseExit()
    {
        StartBuildingText.SetActive(false);
    }
}
