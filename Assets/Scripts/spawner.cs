
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
 {
    public GameObject Gridobject;
    public Transform[] teleport;
    public GameObject[] prefab;
    public Transform[] teleport2;
    public GameObject[] prefab2;

    float x;
    float y;
    float z;
    
    Vector3 pos;  


    public GameObject [,] Spawnposition;

    void Start () 
    {
        Spawnposition = Gridobject.GetComponent<Grid>().getGrid();
        
        for (int i=0;i<=30;i++)
        {
            spawntargetpoint();
            //  SpawnPrefab();
        }
    }
    
    void SpawnPrefab()
    {
        int   Spawnpositionx = Random.Range(0,100);
        int   Spawnpositiony = Random.Range(0,100);

        //sets how many object types can be added currently only 2 can be added
        int prefab_num = Random.Range(0,2);
        Instantiate (prefab [prefab_num], Spawnposition[Spawnpositionx,Spawnpositiony].transform); 
    }
    
    void spawntargetpoint()
    {
        x = Random.Range(-49, 49);
        z = Random.Range(-49, 49);
        y = 0;

        pos = new Vector3(x, y, z);
        transform.position = pos;

        int tele_num2 = Random.Range (0, 0);
        int prefab_num2 = Random.Range (0, 2);

        Instantiate (prefab [prefab_num2],  pos, Quaternion.identity);
        Debug.Log(x);
        Debug.Log(y);
    }
}
