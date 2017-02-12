using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathByHeat : MonoBehaviour {
    public Image fadeTexture;
    float fadeSpeed;
    GameObject player;

    private float alpha;
    public bool fade = false;
    public float timerUntilDeath; 
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeSpeed = 0.2f;
        alpha = 0.0f;
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
        fadeTexture.color = thisColor;
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
