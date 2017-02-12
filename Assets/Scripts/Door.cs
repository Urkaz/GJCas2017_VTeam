using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject door;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Enemy"))
        {
            Vector3 scale = door.transform.localScale;
            scale.z = 0.1f;
            door.transform.localScale = scale;

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Enemy"))
        {
            Vector3 scale = door.transform.localScale;
            scale.z = 0.1f;
            door.transform.localScale = scale;

        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Enemy"))
        {
            Vector3 scale = door.transform.localScale;
            scale.z = 1.0f;
            door.transform.localScale = scale;

        }
    }
}
