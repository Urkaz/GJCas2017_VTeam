using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerIcon : MonoBehaviour {

	public Sprite xbo;
	public Sprite pc;

	// Use this for initialization
	void Start () {
		if(GameObject.FindObjectOfType<GameManager>().getController().Equals("Xbox Bluetooth Gamepad")) {
			Image i = GetComponent<Image>();
			if(i != null)
				i.sprite = xbo;
			SpriteRenderer s = GetComponent<SpriteRenderer>();
			if(s != null)
				s.sprite = xbo;
		}	
		else {
			Image i = GetComponent<Image>();
			if(i != null)
				i.sprite = pc;
			SpriteRenderer s = GetComponent<SpriteRenderer>();
			if(s != null)
				s.sprite = pc;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
