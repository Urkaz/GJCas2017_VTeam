using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptFade : MonoBehaviour {

	public float hideAfter = 5;
	public float speed = 15;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > hideAfter)
			if(transform.position.y - transform.GetComponent<RectTransform>().rect.height < Screen.height)
				transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
	}
}
