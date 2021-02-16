using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController instance;
	public static bool levelOneComplete = false;
	
	public Text events;
	public Text outOfTime;
	public Text step1;
	public Text step2;
	public Text step3;
	public Text step4;
	public Text levelComplete;
	public Text timeText;
	
	public float seconds = 120.0f;
	
	public bool flag = true;
	public AudioSource audioSource;
	public AudioClip smallStep;
	public AudioClip fullStep;
	public float volume = 0.1f;
	
	public GameObject safe;
	public GameObject key;
	
	private bool keyflag = true;
    
	void Awake()
    {
        if (instance == null)
		{
			instance = this;
			if (PlayerPrefs.HasKey("time"))
			{
				seconds = PlayerPrefs.GetFloat("time");
				timeText.text = seconds.ToString("F2");
			}
			if (PlayerPrefs.HasKey("1step1"))
			{
				level1_puzzle1.puzzle1 = true;
			}
			if (PlayerPrefs.HasKey("1step2"))
			{
				level1_puzzle2.puzzle2 = true;
			}
			if (PlayerPrefs.HasKey("1step3"))
			{
				keypadControl.puzzle3 = true;
			}
			if (PlayerPrefs.HasKey("levelOneComplete"))
			{
				levelOneComplete = true;
			}
		}
		else if (instance != null)
		{
			Destroy(gameObject);
		}
    }
	
	void Start()
	{
		timeText.text = seconds.ToString();
	}
	
	void Update()
	{
		if (flag)
		{
			if (seconds > 0)
			{
			seconds -= Time.deltaTime;
			PlayerPrefs.SetFloat("time", seconds);
			timeText.text = seconds.ToString("F2");
			}
			
			if (seconds <= 0)
			{
				
				outOfTime.text = "YOU RAN OUT OF TIME!";
				PlayerPrefs.DeleteKey("time");
				PlayerPrefs.DeleteKey("1step1");
				PlayerPrefs.DeleteKey("1step2");
				PlayerPrefs.DeleteKey("1step3");
				level1_puzzle1.puzzle1 = false;
				level1_puzzle2.puzzle2 = false;
				keypadControl.puzzle3 = false;
				keypadControl.playerCode = "";
				StartCoroutine(lost());
				
			}
			
			
			if (level1_puzzle1.puzzle1)
			{
				step1.text = "Step 1 complete";
				PlayerPrefs.SetInt("1step1", 1);

			}
			if (level1_puzzle2.puzzle2)
			{
				step2.text = "Step 2 complete";
				PlayerPrefs.SetInt("1step2", 1);

			}
			if (keypadControl.puzzle3)
			{
				step3.text = "Step 3 complete";
				PlayerPrefs.SetInt("1step3", 1);
				safe.SetActive(false);
				if (keyflag)
				{
					key.SetActive(true);
					keyflag = false;
				}
			}
			if (levelOneComplete)
			{
				step4.text = "Step 4 complete";
				PlayerPrefs.SetInt("levelOneComplete", 1);
				levelComplete.text = "Level 1 Passed!";
				StartCoroutine(won());

			}
		}
	}
	

	
 
	IEnumerator lost() {
		int counter = 4;
		while (counter > 0) {
			yield return new WaitForSeconds (1);
			counter--;
		}
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
		SceneManager.LoadScene("menu");
	}
	
	IEnumerator won() {
		int counter = 3;
		while (counter > 0) {
			yield return new WaitForSeconds (1);
			counter--;
		}
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
		SceneManager.LoadScene("menu");
	}
}
