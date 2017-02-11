using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {
    public GameObject player = null;
    private bool wantsToRemovePlayerRef = false;

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
        }*/
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("asasfafafdfasf");
        /*if (collision.gameObject.tag.Equals("Player"))
        {
            player = null;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PenguinController>().SetState(PenguinController.State.ALIVE);
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
            player = other.gameObject;
    }
    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            //print("asfasdf");
            Bounds boxBounds = gameObject.GetComponent<BoxCollider>().bounds;
            float size = (boxBounds.max.x - boxBounds.min.x) / 2;
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            if (Horizontal>0f)
            {
                player.GetComponent<PenguinController>().SetState(PenguinController.State.PUSHING);
                if (transform.position.x > player.transform.position.x)
                {
                    if (Mathf.Abs(transform.position.z - player.transform.position.z) < size)
                    {
                        transform.Translate(new Vector3(Horizontal* Time.deltaTime, 0, 0));
                    }   
                }
                    
  
            }
            /*else if (Horizontal < 0f)
            {
                faceToCheck = new Vector3(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y, boxBounds.center.z);
            }
            if(gameObject.transform.position - player)
            Vector3 rightBox = new Vector3 (boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y, boxBounds.center.z);
            Vector3 dir = rightBox - player.transform.position;
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position, dir, out hit,1000))
            {
                Debug.DrawLine(player.transform.position, hit.point);
            }*/
        }
	}
}
