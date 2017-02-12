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

    void OnTriggerEnter()
    {
        if((int)GetComponentInParent<PickUpType>().type<=(int)Inventory.Items.Pipe1  || (!(GameObject.FindObjectOfType<GameManager>().GetComponent<Inventory>().Contains(Inventory.Items.Pipe1) ||
            GameObject.FindObjectOfType<GameManager>().GetComponent<Inventory>().Contains(Inventory.Items.Pipe2) ||
            GameObject.FindObjectOfType<GameManager>().GetComponent<Inventory>().Contains(Inventory.Items.Pipe3))))
            {
                promptItem.gameObject.SetActive(true);
            }
    }
   
    void OnTriggerExit() {
        promptItem.gameObject.SetActive(false);
    }

}
