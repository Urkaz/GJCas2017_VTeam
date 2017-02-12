using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathByHeat : MonoBehaviour {
    public Texture2D fadeTexture;
    float fadeSpeed;
    int drawDepth;
    GameObject player;

    private float alpha;
    private int fadeDir;
    public bool fade = false;
    public float timerUntilDeath; 
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeSpeed = 0.2f;
        drawDepth = -1000;
        alpha = 0.0f;
        fadeDir = -1;
    }

    void Update()
    {
        alpha = Time.timeSinceLevelLoad / timerUntilDeath;
        if (alpha >= 1)
        {
            player.GetComponent<PenguinController>().Dead();
        }
    }

    void OnGUI()
    {
        Color thisColor = GUI.color;
        thisColor.a = alpha;
        GUI.color = thisColor;
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
