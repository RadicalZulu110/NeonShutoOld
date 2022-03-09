using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1PowerBuidlingButton : MonoBehaviour
{
    public GameObject T1PowerText;

    // Start is called before the first frame update
    void Start()
    {
        T1PowerText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        T1PowerText.SetActive(true);
    }

    public void OnMouseExit()
    {
        T1PowerText.SetActive(false);
    }
}
