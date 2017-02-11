using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public bool P1;
    public bool P2;
    public bool P3;
	// Use this for initialization
	void Start () {
		
	}
	public void GetPipe(int num)
    {
        switch (num)
        {
            case 1:
                P1 = true;
                break;
            case 2:
                P2 = true;
                break;
            case 3:
                P3 = true;
                break;
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
