using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum Levels {
		main_menu,
		puzzle_box_01,
		cargo_bay_02,
		cargo_bay_03,
		pipe_level_04
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
