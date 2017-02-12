using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeout_ : MonoBehaviour {
    public Texture2D fadeTexture;
    float fadeSpeed;
    int drawDepth;

    private float alpha;
    private int fadeDir;
    public bool fade = false;

    // Use this for initialization
    void Start () {
        fadeSpeed = 0.2f;
        drawDepth = -1000;
        alpha = 0.0f;
        fadeDir = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (alpha >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnGUI()
    {
        if (fade)
        {
            alpha -= fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisColor = GUI.color;
            thisColor.a = alpha;
            GUI.color = thisColor;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }
}
