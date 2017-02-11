using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeActivator : MonoBehaviour {

    public int ID;
    GameObject Player;
    Inventory inv;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public bool activate;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag ("Player");
        inv = Player.GetComponent<Inventory>();
        activate = false;

    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject == Player)
        {
            if (Input.GetAxis("PickUp") != 0)
            {
                activate = true;
                Debug.Log("Entro al pikup");
            }
            if (activate)
            {
                activate = false;
                inv.removeObject(Inventory.Items.Pipe);
                switch (ID)
                {
                    case 1:
                        if(PuzzleManager.P1)
                        {
                            P1.SetActive(true);
                        }
                        break;
                    case 2:
                        if (PuzzleManager.P2)
                        {
                            P2.SetActive(true);
                        }
                        break;
                    case 3:
                        if (PuzzleManager.P3)
                        {
                            P3.SetActive(true);
                        }
                        break;
                    default:
                        break;
                    }
                }
        }
    }
}
