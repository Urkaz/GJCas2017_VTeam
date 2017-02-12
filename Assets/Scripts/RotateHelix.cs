using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelix : MonoBehaviour {

    public float rotspeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * rotspeed * Time.deltaTime);
    }
}
