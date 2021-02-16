using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
	public static GameController2 instance;
	public static bool levelTwoComplete = false;
	
	public Text events;
	public Text outOfTime;
	public Text timeText;
	public Text step1;
	public Text step2;
	public Text step3;
	public Text step4;
	public Text levelComplete;
	
	public float seconds = 180.0f;
	
	public bool flag = true;
	
	public GameObject doorway;
    
	void Awake()
    {
        if (instance == null)
		{
			instance = this;
			if (PlayerPrefs.HasKey("time2"))
			{
				seconds = PlayerPrefs.GetFloat("time2");
				timeText.text = seconds.ToString("F2");
			}
			if (PlayerPrefs.HasKey("2step1"))
			{
				playerController.step1 = true;
			}
			if (PlayerPrefs.HasKey("2step2"))
			{
				playerController.step2 = true;
			}
			if (PlayerPrefs.HasKey("2step3"))
			{
				playerController.step3 = true;
			}
			if (PlayerPrefs.HasKey("2step4"))
			{
				playerController.step4 = true;
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
			PlayerPrefs.SetFloat("time2", seconds);
			timeText.text = seconds.ToString("F2");
			}
			
			if (seconds <= 0)
			{
				
				outOfTime.text = "YOU RAN OUT OF TIME!";
				PlayerPrefs.DeleteKey("time2");
				PlayerPrefs.DeleteKey("2step1");
				PlayerPrefs.DeleteKey("2step2");
				StartCoroutine(lost());
				
			}
			
			if (playerController.step1)
			{
				step1.text = "Step 1 complete";
				PlayerPrefs.SetInt("2step1", 1);

			}
			
			if (playerController.step2)
			{
				step2.text = "Step 2 complete";
				PlayerPrefs.SetInt("2step2", 1);
				doorway.SetActive(false);
			}
			
			if (playerController.step3)
			{
				step3.text = "Step 3 complete";
				PlayerPrefs.SetInt("2step3", 1);
			}
			
			if (playerController.step4)
			{
				step4.text = "Step 4 complete";
				levelComplete.text = "Level 2 Passed!";
				PlayerPrefs.SetInt("2step4", 1);
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
