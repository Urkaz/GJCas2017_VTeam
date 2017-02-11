using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public GameObject cam;
    public float Amplitude = 0.75f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        cam.transform.Rotate(new Vector3(0, (Amplitude*Mathf.Sin(Time.timeSinceLevelLoad )), 0));
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<PenguinController>().Dead();
        }
    }
}
