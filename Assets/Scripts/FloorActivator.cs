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
        if(!GetComponentInParent<FloorTileParent>().getCompleted() && GetComponentInParent<FloorTileParent>().getCanInteract())
        {
            if (col.gameObject.tag.Equals("Player"))
            {
                if (GetComponentInParent<FloorTileParent>().getCompleted() != true)
                {
                    GetComponentInParent<FloorTileParent>().setTileColored(activated);

                    if (GetComponentInParent<FloorTileParent>().getCanInteract())
                    {
                        activated = !activated;
                        ChangeMat();
                    }
                }
            }
        }
        
    }
    public void eraseActivated()
    {
        activated = false;
        gameObject.GetComponent<MeshRenderer>().material = de;
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
