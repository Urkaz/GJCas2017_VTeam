using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public float timer = 0;
	public GameManager.Levels level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > timer)
			GameObject.FindObjectOfType<GameManager>().LoadLevel(level);
	}
}
