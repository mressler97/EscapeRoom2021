using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	public string levelOneScene;
	public string levelTwoScene;
	public GameObject Credits;
	public GameObject Home;
	public GameObject Settings;
	public GameObject Play;
	public Button levelTwoButton;
	public Button levelOneButton;
	private Toggle tog;
	public Color oldColor;
	public Color newColor;
	
    // Start is called before the first frame update
	void Awake()
	{
		if (PlayerPrefs.HasKey("levelOneComplete"))
		{
			levelTwoButton.interactable = true;
			ColorBlock cb = levelOneButton.colors;
			cb.normalColor = newColor;
			levelOneButton.colors = cb;
		}
		if (PlayerPrefs.HasKey("2step4"))
		{
			levelTwoButton.interactable = true;
			ColorBlock cb = levelTwoButton.colors;
			cb.normalColor = newColor;
			levelTwoButton.colors = cb;
		}
	}
	

    // Update is called once per frame
    void Update()
    {
        if (GameController.levelOneComplete && levelTwoButton.interactable == false)
		{
			levelTwoButton.interactable = true;
			ColorBlock cb = levelOneButton.colors;
			cb.normalColor = newColor;
			levelOneButton.colors = cb;
		}
		
		if (playerController.step4)
		{
			ColorBlock cb = levelTwoButton.colors;
			cb.normalColor = newColor;
			levelTwoButton.colors = cb;
		}
    }
	
	public void NewGame()
	{
		SceneManager.LoadScene(levelOneScene);
	}
	
	public void levelTwo()
	{
		SceneManager.LoadScene(levelTwoScene);
	}
	
	public void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
	
	public void OpenCredits()
	{
		Credits.SetActive(true);
		Home.SetActive(false);
	}
	
	public void CloseCredits()
	{
		Credits.SetActive(false);
		Home.SetActive(true);
	}
	
	public void OpenSettings()
	{
		Settings.SetActive(true);
		Home.SetActive(false);
	}
	
	public void ClearLevels()
	{
		PlayerPrefs.DeleteAll();
		level1_puzzle1.puzzle1 = false;
		level1_puzzle2.puzzle2 = false;
		keypadControl.puzzle3 = false;
		GameController.levelOneComplete = false;
		SelectionManager.isKeyHeld = false;
		keypadControl.playerCode = "";
		
		//GameController2.instance.seconds = 160.0f;
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
		
		levelTwoButton.interactable = false;
		ColorBlock cb = levelOneButton.colors;
		cb.normalColor = oldColor;
		levelOneButton.colors = cb;
	}
	
	public void CloseSettings()
	{
		Settings.SetActive(false);
		Home.SetActive(true);
	}
	
	public void OpenPlay()
	{
		Play.SetActive(true);
		Home.SetActive(false);
	}
	
	public void ClosePlay()
	{
		Play.SetActive(false);
		Home.SetActive(true);
	}
	
	public void toggleAudio()
	{
		tog = GameObject.Find("Sound Toggle").GetComponent<Toggle>();
		if (tog.isOn)
		{
			AudioController.instance.gameObject.GetComponent<AudioSource>().Play();
		}
		else
		{
			AudioController.instance.gameObject.GetComponent<AudioSource>().Pause();
		}
	}
}
