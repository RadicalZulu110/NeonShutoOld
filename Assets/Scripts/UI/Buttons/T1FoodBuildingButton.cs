using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1FoodBuildingButton : MonoBehaviour
{
    public GameObject T1FoodText;

    // Start is called before the first frame update
    void Start()
    {
        T1FoodText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        T1FoodText.SetActive(true);
    }

    public void OnMouseExit()
    {
        T1FoodText.SetActive(false);
    }
}
