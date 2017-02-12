using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePickup : MonoBehaviour {

	public float rotationSpeed = 0;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
		transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.timeSinceLevelLoad)/3f + 0.8f, transform.position.z);
	}
}
