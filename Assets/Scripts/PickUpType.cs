using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpType : MonoBehaviour {

    public Inventory.Items type;
    private Transform promptItem;
    public Transform item;
    
	// Use this for initialization
	void Start () {
        promptItem = transform.Find("promptItem");
	}


    void OnTriggerEnter() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        if(gm != null) {
            if((int)GetComponentInParent<PickUpType>().type < (int)Inventory.Items.Pipe1 || (!(gm.GetComponent<Inventory>().Contains(Inventory.Items.Pipe1) ||
                GameObject.FindObjectOfType<GameManager>().GetComponent<Inventory>().Contains(Inventory.Items.Pipe2) ||
                GameObject.FindObjectOfType<GameManager>().GetComponent<Inventory>().Contains(Inventory.Items.Pipe3))))
            {
                promptItem.gameObject.SetActive(true);
                item.GetComponent<Renderer>().material.SetColor("_OutColor", new Color(1,0.5f,0));
            }
        }
    }

    void OnTriggerExit() {
        promptItem.gameObject.SetActive(false);
        item.GetComponent<Renderer>().material.SetColor("_OutColor", Color.white);
    }

}
