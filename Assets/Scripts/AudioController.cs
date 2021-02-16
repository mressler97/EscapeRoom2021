using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public static AudioController instance;
	
    void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

}
