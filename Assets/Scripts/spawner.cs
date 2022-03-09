using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
 {
     public Transform[] teleport;
     public GameObject[] prefeb;
      public Transform[] teleport2;
     public GameObject[] prefeb2;
float x;
 float y;
 float z;
 Vector3 pos;
     // Use this for initialization
     void Start () 
        {
     
         for (int i=0;i<=30;i++){
             spawntargetpoint();
            //  SpawnPrefeb();
         }
     }
 
     // Update is called once per frame
     void Update () {
 
     }
     void SpawnPrefeb(){
         int tele_num = Random.Range (0, 0);
         int prefeb_num = Random.Range (0, 2);
         Instantiate (prefeb [prefeb_num], teleport [tele_num].position, teleport [tele_num].rotation);
 
     }

     void spawntargetpoint(){
         x = Random.Range(-49, 49);
     z = Random.Range(-49, 49);
     y = 0;
     pos = new Vector3(x, y, z);
     transform.position = pos;
             int tele_num2 = Random.Range (0, 0);
         int prefeb_num2 = Random.Range (0, 2);
         Instantiate (prefeb [prefeb_num2],  pos, Quaternion.identity);
    Debug.Log(x);
    Debug.Log(y);
     }
 }
