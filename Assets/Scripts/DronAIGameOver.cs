using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAIGameOver : MonoBehaviour {

    public Fadeout camera;
    public RAIN.Core.AIRig ai;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            Destroy(ai);
            col.gameObject.GetComponent<PenguinController>().Dead();
            
            camera.fade = true;
        }
    }
}
