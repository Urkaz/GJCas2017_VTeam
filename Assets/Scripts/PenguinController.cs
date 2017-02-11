using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour {

    public int speed;
    public int maxSpeed;
    Rigidbody rb;
    public SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        //sr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
        //sr.receiveShadows = true;

    }
	
	// Update is called once per frame
	void Update () {
        //rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed) * Time.deltaTime);
    }

    void FixedUpdate()
    {
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
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Fadeout>().fade = true;
        
    }





}
