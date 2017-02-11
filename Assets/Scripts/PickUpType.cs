using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpType : MonoBehaviour {

    public Inventory.Items type;
    private Transform promptItem;
    
	// Use this for initialization
	void Start () {
        promptItem = transform.Find("promptItem");
	}

    void Update()
    {
    }

    void OnTriggerEnter() {
        promptItem.gameObject.SetActive(true);
    }

    void OnTriggerExit() {
        promptItem.gameObject.SetActive(false);
    }

}
