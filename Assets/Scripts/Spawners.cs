using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawners : MonoBehaviour {
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;


    public GameObject[] keySpawners;

    // Use this for initialization
    void Start () {
        int spawn1 = UnityEngine.Random.Range(0, keySpawners.Length - 1);
        int spawn2 = UnityEngine.Random.Range(0, keySpawners.Length - 1);

        while(spawn2 == spawn1)
        {
            spawn2 = UnityEngine.Random.Range(0, keySpawners.Length - 1);
        }

        int spawn3 = 0; //= UnityEngine.Random.Range(0, keySpawners.Length - 1);

        while(spawn3 == spawn1 && spawn3 == spawn2)
        {
            spawn3 = UnityEngine.Random.Range(0, keySpawners.Length - 1);
        }

        key1.transform.position = keySpawners[spawn1].transform.position;
        key2.transform.position = keySpawners[spawn2].transform.position;
        key3.transform.position = keySpawners[spawn3].transform.position;
    }
}
