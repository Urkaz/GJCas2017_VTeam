using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinController: MonoBehaviour {

    GameObject currentCollidedObject;
    Inventory inv;
    Rigidbody rb;
	
	public int speed;
    public int maxspeed;
    private State currentState = State.ALIVE;
	
	public float lookSpeed = 10;
    private Vector3 curLoc;
    private Vector3 prevLoc;

    Vector3 lookAtThat;
    
    public enum State
    {
        ALIVE,
        DUDU,
        DEAD,
        PUSHING
    };

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<Inventory>();
        inv = gameObject.GetComponent<Inventory>();
        GameObject[] arraySpawns = GameObject.FindGameObjectsWithTag("Spawn");
        if (PlayerPrefs.GetInt("TargetSpawn", -1)==-1)
        {
            PlayerPrefs.SetInt("TargetSpawn", 2);
        }
        foreach (GameObject spawn in arraySpawns)
        {
            if (spawn.GetComponent<SpawnInfo>().SpawnIndex == PlayerPrefs.GetInt("TargetSpawn"))
            {
                transform.position = spawn.transform.position;
                break;
            }
        }
        PlayerPrefs.SetInt("TargetSpawn", -1);
		rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("PickUp")!=0)
        {
            PickUp();
        }

        //transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		if(Input.GetAxis("Horizontal")!= 0 && Input.GetAxis("Vertical") ==0){

            transform.localEulerAngles = new Vector3(0, Mathf.Sign(Input.GetAxis("Horizontal")) * 90, 0);
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.localEulerAngles = new Vector3(0,0, 0);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {

        }
        Debug.Log(Mathf.Sign(Input.GetAxis("Horizontal")));
        //transform.LookAt(lookAtThat);
	}
	

    private void FixedUpdate()
    {
		prevLoc = curLoc;
        curLoc = transform.position;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;

        if (rb.velocity.magnitude > maxspeed)
		{
			rb.velocity = rb.velocity.normalized * maxspeed;
        }
	}
	
    private void OnTriggerEnter (Collider collision)
    {
        if(collision.gameObject.tag == "Pickable")
        {
            currentCollidedObject = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Door")
        {
            EnterDoor(collision.gameObject);
        }
    }

    private void OnTriggerExit (Collider collision)
    {
        if (currentCollidedObject==collision.gameObject)
        {
            currentCollidedObject = null;
        }

    }
    public void SetState(State state)
    {
        currentState = state;
    }
    void PickUp()
    {
        if(currentCollidedObject!=null)
        {
            inv.addObject((currentCollidedObject.GetComponent<PickUpType>().type));
            Destroy(currentCollidedObject);
            currentCollidedObject = null;
        }
    }

    void EnterDoor(GameObject door)
    {
        int[] a = door.GetComponent<SwitchScene>().GetTargetDoor(); //0 = nivel , 1 = puerta
        PlayerPrefs.SetInt("TargetSpawn", a[1]);
        SceneManager.LoadScene(a[0]);
    }

    public void Dead()
    {
        if(!currentState.Equals(State.DEAD))
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Fadeout>().fade = true;
        }
    }
}
