using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileParent : MonoBehaviour {
    int activatedTiles = 0;
    bool completed = false;
    int totalpieces = 0;
    bool canInteract = false;
	// Use this for initialization
	void Start () {
		Transform[] tiles = GetComponentsInChildren<Transform>();
        foreach (var item in tiles)
        {
            if(item.gameObject.activeInHierarchy == true)
            {
                totalpieces++;
            }
        }
        totalpieces--;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setTileColored(bool activated)
    {
        
        FloorActivator[] aux = GetComponentsInChildren<FloorActivator>();

        if (activated == true)
        {
            foreach (var item in aux)
            {
                item.eraseActivated();
            }
            activatedTiles = 0;
            canInteract = false;
        }
        else
        {
            activatedTiles++;
            if(activatedTiles >= totalpieces)
            {
                completed = true;
            }
        }
    }
    public bool getCompleted()
    {
        return completed;
    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
    }
    public bool getCanInteract()
    {
        return canInteract;
    }
}
