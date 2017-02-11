using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class PenguinController: MonoBehaviour {

    GameObject currentCollidedObject;
    Inventory inv;
    Rigidbody rb;
    PuzzleManager PipeManager;
	
	public int speed;
    public float rotSpeed;
    public int maxSpeed;
    private State currentState = State.ALIVE;
	
	public float lookSpeed = 10;
    private Vector3 curLoc;
    private Vector3 prevLoc;

    Vector3 lookAtThat;

    Animator anim;

    public float animSpeed;

    public enum State
    {
        ALIVE,
        DUDU,
        DEAD,
        PUSHING
    };

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        gameObject.AddComponent<Inventory>();
        inv = gameObject.GetComponent<Inventory>();

        GameObject[] arraySpawns = GameObject.FindGameObjectsWithTag("Spawn");
        if (PlayerPrefs.GetInt("TargetSpawn", -1)==-1)
        {
            PlayerPrefs.SetInt("TargetSpawn", 0);
        }
        foreach (GameObject spawn in arraySpawns)
        {
            if (spawn.GetComponent<SpawnInfo>().SpawnIndex == PlayerPrefs.GetInt("TargetSpawn"))
            {
                transform.position = spawn.transform.position + Vector3.up * gameObject.GetComponent<CapsuleCollider>().bounds.extents.y;
                break;
            }
        }
        PlayerPrefs.SetInt("TargetSpawn", -1);
		rb = GetComponent<Rigidbody>();
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("PickUp")!=0)
        {
            PickUp();
        }
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if(Input.GetAxis("Horizontal")!= 0 && Input.GetAxis("Vertical") ==0){
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Mathf.Sign(Input.GetAxis("Horizontal")) * 90, 0), Time.deltaTime * rotSpeed);
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * rotSpeed);
                //transform.localEulerAngles = new Vector3(0,0, 0);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotSpeed);

                //transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Horizontal") >= 0 && Input.GetAxis("Vertical") >= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime * rotSpeed);

                //transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            if (Input.GetAxis("Horizontal") <= 0 && Input.GetAxis("Vertical") <= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 225, 0), Time.deltaTime * rotSpeed);

                //transform.localEulerAngles = new Vector3(0, 225, 0);
            }
            if (Input.GetAxis("Horizontal") >= 0 && Input.GetAxis("Vertical") <= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 135, 0), Time.deltaTime * rotSpeed);

                //transform.localEulerAngles = new Vector3(0, 135, 0);
            }
            if (Input.GetAxis("Horizontal") <= 0 && Input.GetAxis("Vertical") >= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 315, 0), Time.deltaTime * rotSpeed);

                //transform.localEulerAngles = new Vector3(0, 315, 0);
            }
        }
        if((Mathf.Abs(Input.GetAxis("Vertical"))) > 0)
        {
            animSpeed = Mathf.Abs(Input.GetAxis("Vertical"));
        }
        else if ((Mathf.Abs(Input.GetAxis("Horizontal"))) > 0)
        {
            animSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
        }


        anim.SetFloat("VSpeed", animSpeed);
        


    }
	
    private void OnTriggerEnter (Collider collision)
    {
        if(collision.gameObject.tag.Equals("Pickable"))
        {
            currentCollidedObject = collision.gameObject;
        }
        else if (collision.gameObject.tag.Equals("Door"))
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
            if (!inv.Contains(currentCollidedObject.GetComponent<PickUpType>().type) && currentCollidedObject.GetComponent<PickUpType>().type == Inventory.Items.Pipe) ;

            if (currentCollidedObject.GetComponent<PickUpType>().type == Inventory.Items.Pipe)
            {
                if (!inv.Contains(currentCollidedObject.GetComponent<PickUpType>().type)){
                    inv.addObject((currentCollidedObject.GetComponent<PickUpType>().type));
                    PipeManager.GetPipe(currentCollidedObject.GetComponent<Pipe>().Pieza);
                    Destroy(currentCollidedObject);
                    currentCollidedObject = null;
                }
            }
            else
            {
                inv.addObject((currentCollidedObject.GetComponent<PickUpType>().type));
                Destroy(currentCollidedObject);
                currentCollidedObject = null;
            }
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
