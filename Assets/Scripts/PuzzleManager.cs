using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public bool Activated;
    private int TotalPuzzlePieces = 3;
    private int PipesPlaced = 0;
    // Use this for initialization
    void Start () {
		
	}
	public void AddPipePlaced()
    {
        if (!Activated)
        {
            PipesPlaced++;
            if (PipesPlaced >= TotalPuzzlePieces)
            {
                Activated = true;
                print("COMPLETED");
            }
        }
    }
}
