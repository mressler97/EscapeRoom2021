using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayCode : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip fullStep;
	public float volume = 0.75f;
	

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = keypadControl.playerCode;
		
    }

}
