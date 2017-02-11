using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour {
    public int LevelIndex, SpawnTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[] GetTargetDoor()
    {
        return new int[] { LevelIndex, SpawnTarget };
    }
}
