using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_puzzle1 : MonoBehaviour
{
	private int count = 0;
	public static bool puzzle1 = false;
	public ParticleSystem particlesBooks;
	
	public AudioSource audioSource;
	public AudioClip smallStep;
	public AudioClip fullStep;
	public float volume = 0.75f;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("puzzle1"))
		{
			count++;    
			other.gameObject.tag = "Untagged";
			audioSource.PlayOneShot(smallStep, volume);

			if (count == 3)
			{
				particlesBooks.Stop();
				puzzle1 = true;
				audioSource.PlayOneShot(fullStep, volume);
			}
		}
	}
	 
 }
