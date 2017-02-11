using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelix : MonoBehaviour {

    Transform tr;
    public float rotspeed;

	// Use this for initialization
	void Start () {
        tr = transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * rotspeed * Time.deltaTime);
    }
}
