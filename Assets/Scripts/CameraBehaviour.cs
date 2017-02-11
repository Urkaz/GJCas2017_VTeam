using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public GameObject cam;
    public Camera camera;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion angle = Quaternion.Euler(new Vector3(0, 90 + 65 * Mathf.Sin(Time.timeSinceLevelLoad * 0.4f), 0));
        cam.transform.rotation = angle;

    }

    void OnTriggerEnter(Collider col)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Vector3 playerViewport = camera.WorldToViewportPoint(player.transform.position);
            Ray ray = camera.ViewportPointToRay(playerViewport);
            Vector3 vectorRight = new Vector3(ray.direction.z, 0, -ray.direction.x).normalized * (player.GetComponent<SphereCollider>().radius - 0.1f);
            //Debug.DrawLine(camera.transform.position, camera.transform.position + ray.direction);
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
                    playerViewport = camera.WorldToViewportPoint(player.transform.position + vectorRight);
                    ray = camera.ViewportPointToRay(playerViewport);
                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        Debug.DrawLine(ray.origin, hit.point);
                        if (hit.transform.gameObject.tag.Equals("Player"))
                        {
                            player.GetComponent<PenguinController>().Dead();

                        }
                        else
                        {

                            playerViewport = camera.WorldToViewportPoint(player.transform.position - vectorRight);
                            ray = camera.ViewportPointToRay(playerViewport);
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
