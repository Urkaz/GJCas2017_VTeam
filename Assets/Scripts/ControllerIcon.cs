using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerIcon : MonoBehaviour {

	public Sprite xbo;
	public Sprite pc;

	// Use this for initialization
	void Start () {
		string[] c = Input.GetJoystickNames();
		if(c.Length > 0) {
			if(c[0].Equals("Xbox Bluetooth Gamepad")) {
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
	}
}
