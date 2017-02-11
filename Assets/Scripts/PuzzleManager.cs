using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public static bool P1;
    public static bool P2;
    public static bool P3;
    public static bool Activated;
	// Use this for initialization
	void Start () {
		
	}
	public static void GetPipe(int num)
    {
        Activated = true;
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
            default:
                break;
        }

    }
}
