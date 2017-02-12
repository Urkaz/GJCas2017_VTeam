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
		tile_puzzle_05,
		patrol_level_06,
		video_intro,
		video_end
	}

	private string controllerName = "";
    AudioSource audioSourceBocina;
    AudioSource audioSourceDesert;
    AudioSource audioSourceSea;
    AudioSource audioSourceEngines;

    public List<AudioClip> audioList;
    public List<AudioSource> audioSourceList;
    private List<AudioEnum> soundsToPlay;

	public Levels initialLevel = Levels.puzzle_box_01;

	private int spawnTarget = -1;

    public enum AudioEnum
    {
        Bocina,
        Desert,
        Sea,
        Engines
    }

	void Awake() {
        DontDestroyOnLoad(transform.gameObject);

        audioList.Add((AudioClip)Resources.Load("Audio/Bocina"));
        audioList.Add((AudioClip)Resources.Load("Audio/Desert"));
        audioList.Add((AudioClip)Resources.Load("Audio/sea"));
        audioList.Add((AudioClip)Resources.Load("Audio/engines"));

        audioSourceBocina = gameObject.AddComponent<AudioSource>();
        audioSourceBocina.clip = audioList[0];
        audioSourceBocina.loop = false;

        audioSourceDesert = gameObject.AddComponent<AudioSource>();
        audioSourceDesert.clip = audioList[1];
        audioSourceDesert.loop = true;

        audioSourceSea = gameObject.AddComponent<AudioSource>();
        audioSourceSea.clip = audioList[2];
        audioSourceSea.loop = true;

        audioSourceEngines = gameObject.AddComponent<AudioSource>();
        audioSourceEngines.clip = audioList[3];
        audioSourceEngines.loop = true;

        audioSourceList.Add(audioSourceBocina);
        audioSourceList.Add(audioSourceDesert);
        audioSourceList.Add(audioSourceSea);
        audioSourceList.Add(audioSourceEngines);
    }

	public void LoadFirstLevel() {
		LoadLevel(initialLevel);
		setSpawnTarget(0);

		string[] c = Input.GetJoystickNames();
		if(c.Length > 0)
			controllerName = c[0];

		Debug.Log(controllerName);
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

	public string getController() {
		return controllerName;
	}

    public void setSoundsToPlay(List<AudioEnum> list)
    {
        soundsToPlay = list;
        foreach (AudioEnum item in list)
        {
            if(soundsToPlay.Contains(item))
            {
                if(!audioSourceList[(int)item].isPlaying)
                {
                    if(item.Equals(AudioEnum.Bocina))
                    {
                        audioSourceList[(int)item].PlayDelayed(UnityEngine.Random.Range(10, 30));
                    }
                    else
                    {
                        audioSourceList[(int)item].Play();
                    }
                        
                }
            }
            else
            {
                audioSourceList[(int)item].Stop();
            }
        }
    }

    private void Update()
    {
        if(!audioSourceBocina.isPlaying)
        {
            audioSourceBocina.PlayDelayed(UnityEngine.Random.Range(10, 30));
        }
    }
}
