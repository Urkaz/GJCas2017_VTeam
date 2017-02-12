using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class SearchNextKey : MonoBehaviour {

    public AIRig ai;

    public float range;

    public List<GameObject> keys;

    private GameObject nextKeyLoc;

    void Start()
    {
        GetNextKey();
    }

	// Update is called once per frame
	void Update () {
        if (keys.Count <= 0)
        {
            ai.AI.WorkingMemory.SetItem<bool>("exit", true);
            return;
        }
        if (Vector3.Distance(nextKeyLoc.transform.position, transform.position) <= range)
            GetNextKey();

        //Debug.Log(Vector3.Distance(transform.position, nextKeyLoc.transform.position));
	}

    private void GetNextKey()
    {
        if(keys.Count <= 0)
        {
            ai.AI.WorkingMemory.SetItem<bool>("exit", true);
            return;
        }

        nextKeyLoc = keys[0];
        float distance = Vector3.Distance(transform.position, nextKeyLoc.transform.position);
        foreach (GameObject key in keys)
        {
            float dist = Vector3.Distance(key.transform.position, transform.position);
            if (dist < distance)
            {
                nextKeyLoc = key;
                distance = dist;
            }
        }
        keys.Remove(nextKeyLoc);

        ai.AI.WorkingMemory.SetItem<GameObject>("bestKeyToSearch", nextKeyLoc);

    }
}
