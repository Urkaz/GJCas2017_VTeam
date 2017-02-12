using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadeout_ : MonoBehaviour {
    //public Texture2D fadeTexture;
    float fadeSpeed;
    private float alpha;
    private int fadeDir;
    public bool fade = false;
    public GameObject resetPrompt;
    public Image fadeTexture;

    // Use this for initialization
    void Start () {
        fadeSpeed = 0.5f;
        alpha = 0.0f;
        fadeDir = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (alpha >= 1)
        {
            resetPrompt.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetAxis("ResetRoom") != 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

            fadeTexture.color = thisColor;
        }
    }
}
