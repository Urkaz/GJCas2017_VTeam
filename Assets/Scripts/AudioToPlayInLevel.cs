using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToPlayInLevel : MonoBehaviour {

    public List<GameManager.AudioEnum> listOfAudios;

	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<GameManager>().setSoundsToPlay(listOfAudios);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
