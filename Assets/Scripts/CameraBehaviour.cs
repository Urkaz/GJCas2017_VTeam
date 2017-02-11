using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public GameObject cam;    

    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion angle = Quaternion.Euler(new Vector3(0, 90 + 65 * Mathf.Sin(Time.timeSinceLevelLoad * 0.4f), 0));
        cam.transform.rotation = angle;

    }

    void OnTriggerEnter(Collider col)
    {
        
    }

   


}
