using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum Levels {
		main_menu,
		puzzle_box_01,
		camera_02
	}

	private Levels currentLevel = Levels.main_menu;

	public GameObject player;

	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

	public void LoadFirstLevel() {
		LoadLevel(Levels.puzzle_box_01);
	}

	public void LoadLevel(Levels level) {
		Debug.Log(level.ToString());
		SceneManager.LoadSceneAsync(level.ToString());
	}
}
