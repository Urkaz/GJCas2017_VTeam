using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMatrix : MonoBehaviour {
    public Material deactivate;
    public Material activate;
    int[,] floor;
    public int height, width;
    public GameObject GO;
	// Use this for initialization
	void Start () {
        createMatrix();
        floor = new int[height, width];
	}

    void createMatrix() {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                floor[i, j] = 0;
                GameObject go;
                go = Instantiate(GO) as GameObject;
                go.transform.position = new Vector3(i*3+10,0, j * 3 + 10);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
