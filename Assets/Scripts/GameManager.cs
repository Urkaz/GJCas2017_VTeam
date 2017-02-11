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
		pipe_level_04,
		tile_puzzle_05
	}

	public Levels initialLevel = Levels.puzzle_box_01;

	private int spawnTarget = -1;

	private Levels currentLevel = Levels.main_menu;

	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

	public void LoadFirstLevel() {
		LoadLevel(initialLevel);
		setSpawnTarget(0);
	}

	public void LoadLevel(Levels level) {
		Debug.Log(level.ToString());
		SceneManager.LoadSceneAsync(level.ToString());
	}

	public void setSpawnTarget(int spawnTarget) {
		this.spawnTarget = spawnTarget;
	}

	public int getSpawnTarget() {
		return spawnTarget;
	}
}
