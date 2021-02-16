using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypadControl : MonoBehaviour
{
	
	public static string correctCode = "0258";
	public static string correctCode2 = "7224";
    public static string playerCode = "";
	public static int totalDigits = 0;
	public static bool puzzle3 = false;
	

	private Scene currentScene;
	

	void Start()
	{
		currentScene = SceneManager.GetActiveScene();
	}
	

    // Update is called once per frame
    void Update()
    {
		if (currentScene.name == "level1")
		{
			if (totalDigits == 4)
			{
				if (playerCode == correctCode)
				{
					if (level1_puzzle2.puzzle2)
					{
						puzzle3 = true;
					}
				}
				else
				{
					playerCode="";
					totalDigits = 0;
				}
			}
		}
		else if (currentScene.name == "level2")
		{
			if (totalDigits == 4)
			{
				if (playerCode == correctCode2)
				{
					playerController.step2 = true;
				}
				else
				{
					playerCode="";
					totalDigits = 0;
				}
			}
		}
    }
	
	void OnMouseUp()
	{
		if (totalDigits < 4)
		{
		playerCode += gameObject.name;
		totalDigits += 1;
		}
	}
	

}
