using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeActivator : MonoBehaviour {

    //public int ID;
    GameObject Player;
    Inventory inv;
    /*public GameObject P1;
    public GameObject P2;
    public GameObject P3;*/
    public bool activated;
    public GameObject MyPuzzleManager;
    public GameObject PipeToActivateFromScene;

    public Inventory.Items neededPipe;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        if(gm != null)
            inv = gm.GetComponent<Inventory>();
        activated = false; //esto habria que cambiarlo en caso de que restauremos estado tras completar puzzles

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player) {
            if (Input.GetAxis("PickUp") != 0 && inv.Contains(neededPipe) && !activated)
            {
                activated = true;
                MyPuzzleManager.GetComponent<PuzzleManager>().AddPipePlaced();
                inv.removeObject(neededPipe);
                PipeToActivateFromScene.SetActive(true);
                
            }
        }
    }
}
