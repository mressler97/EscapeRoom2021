using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	private Scene currentScene;
	
	void Start()
	{
		currentScene = SceneManager.GetActiveScene();
		GameIsPaused = false;
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	 
    }
	
	void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("menu");
	}
	
	public void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
	
	public void Reset()
	{
		if (currentScene.name == "level1")
		{
			PlayerPrefs.DeleteKey("time");
			PlayerPrefs.DeleteKey("1step1");
			PlayerPrefs.DeleteKey("1step2");
			PlayerPrefs.DeleteKey("1step3");
			PlayerPrefs.DeleteKey("levelOneComplete");
			level1_puzzle1.puzzle1 = false;
			level1_puzzle2.puzzle2 = false;
			keypadControl.puzzle3 = false;
			GameController.levelOneComplete = false;
			SelectionManager.isKeyHeld = false;
			keypadControl.playerCode = "";
			GameController.instance.seconds = 120.0f;
			Time.timeScale = 1f;
			GameIsPaused = false;
			SceneManager.LoadScene("level1");
		}
		else if (currentScene.name == "level2")
		{
			GameController2.instance.seconds = 180.0f;
			PlayerPrefs.DeleteKey("time2");
			PlayerPrefs.DeleteKey("2step1");
			PlayerPrefs.DeleteKey("2step2");
			PlayerPrefs.DeleteKey("2step3");
			PlayerPrefs.DeleteKey("2step4");
			playerController.step1 = false;
			playerController.step2 = false;
			playerController.step3 = false;
			playerController.step4 = false;
			playerController.isVaccineHeld = false;
			
			keypadControl.playerCode = "";
			Time.timeScale = 1f;
			GameIsPaused = false;
			SceneManager.LoadScene("level2");	
		}
	}
}
