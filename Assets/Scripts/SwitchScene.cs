using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour {
    public int SpawnTarget;
	public GameManager.Levels level = GameManager.Levels.main_menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[] GetTargetDoor()
    {
        return new int[] { (int)level, SpawnTarget };
    }
}
