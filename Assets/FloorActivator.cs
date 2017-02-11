using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorActivator : MonoBehaviour {
    public Material ac;
    public Material de;
    public bool activated = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            activated = !activated;
            ChangeMat();
        }
    }

    private void ChangeMat()
    {
        if (activated)
        {
            gameObject.GetComponent<MeshRenderer>().material = ac;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = de;
        }
    }

    // Use this for initialization
    void Start () {
        ChangeMat();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
