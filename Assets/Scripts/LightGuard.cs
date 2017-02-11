using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGuard : MonoBehaviour {
    public float radiusA = 5;
    public float radiusB = 10;
    public float speed = 1;

    private float angle;
    public Vector3 center = new Vector3(0, 1, 0);
    public GameObject guard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        angle += speed * Time.deltaTime;


        float x = radiusA * Mathf.Cos(angle);
        float y = radiusB * Mathf.Sin(angle);

        guard.transform.position = center + new Vector3(x, 0, y);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<PenguinController>().Dead();
        }
    }
}
