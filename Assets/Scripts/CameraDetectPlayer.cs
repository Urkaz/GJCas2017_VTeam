using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetectPlayer : MonoBehaviour {

    private GameObject player;
    public Camera myCamera;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {	
	}

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            Vector3 playerViewport = myCamera.WorldToViewportPoint(player.transform.position);
            Ray ray = myCamera.ViewportPointToRay(playerViewport);
            Vector3 vectorRight = new Vector3(ray.direction.z, 0, -ray.direction.x).normalized * (player.GetComponent<CapsuleCollider>().radius - 0.1f);
            //Debug.DrawLine(myCamera.transform.position, myCamera.transform.position + ray.direction);
            //Debug.DrawLine(player.transform.position, player.transform.position + vectorRight * 10);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.DrawLine(ray.origin, hit.point);

                if (hit.transform.gameObject.tag.Equals("Player"))
                {
                    player.GetComponent<PenguinController>().Dead();

                }
                else
                {
                    playerViewport = myCamera.WorldToViewportPoint(player.transform.position + vectorRight);
                    ray = myCamera.ViewportPointToRay(playerViewport);
                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        Debug.DrawLine(ray.origin, hit.point);
                        if (hit.transform.gameObject.tag.Equals("Player"))
                        {
                            player.GetComponent<PenguinController>().Dead();

                        }
                        else
                        {

                            playerViewport = myCamera.WorldToViewportPoint(player.transform.position - vectorRight);
                            ray = myCamera.ViewportPointToRay(playerViewport);
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                Debug.DrawLine(ray.origin, hit.point);
                                if (hit.transform.gameObject.tag.Equals("Player"))
                                {
                                    player.GetComponent<PenguinController>().Dead();

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
