using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
 {
     public Transform[] teleport;
     public GameObject[] prefeb;
     // Use this for initialization
     void Start () 
        {
         for (int i=0;i<=1;i++){
             SpawnPrefeb();
         }
     }
 
     // Update is called once per frame
     void Update () {
 
     }
     void SpawnPrefeb(){
         int tele_num = Random.Range (0, 0);
         int prefeb_num = Random.Range (0, 1);
         Instantiate (prefeb [prefeb_num], teleport [tele_num].position, teleport [tele_num].rotation);
 
     }
 }
