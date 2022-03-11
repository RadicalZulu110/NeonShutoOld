using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1PowerBuidlingButton : MonoBehaviour
{
    public GameObject T1PowerText;

    void Start()
    {
        T1PowerText.SetActive(false);
    }

    public void OnOver()
    {
        T1PowerText.SetActive(true);
    }

    public void OnExit()
    {
        T1PowerText.SetActive(false);
    }
}
