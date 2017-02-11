using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour {

    public int speed;
    public int maxSpeed;
    Rigidbody rb;


    public float lookSpeed = 10;
    private Vector3 curLoc;
    private Vector3 prevLoc;

    Vector3 lookAtThat;

    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();



    }
	
	// Update is called once per frame
	void Update () {
        
        
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

    void FixedUpdate()
    {
        prevLoc = curLoc;
        curLoc = transform.position;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        //Objetos
    }

    void Movement()
    {

    }

    void Interactuate()
    {

    }

    void Take()
    {

    }

    void Use()
    {

    }

    void Hide()
    {

    }

    public void Dead()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<fadeout>().fade = true;
        
    }





}
