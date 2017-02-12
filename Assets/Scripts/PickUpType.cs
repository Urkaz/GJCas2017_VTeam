using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpType : MonoBehaviour {

    public Inventory.Items type;
    private Transform promptItem;
    private Transform item;
    
	// Use this for initialization
	void Start () {
        promptItem = transform.Find("promptItem");
        item = transform.Find("Item");
	}

    void OnTriggerEnter() {
        promptItem.gameObject.SetActive(true);
        item.GetComponent<Renderer>().material.SetColor("_OutColor", new Color(1,0.5f,0));
    }

    void OnTriggerExit() {
        promptItem.gameObject.SetActive(false);
        item.GetComponent<Renderer>().material.SetColor("_OutColor", Color.white);
    }

}
