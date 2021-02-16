using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_puzzle2 : MonoBehaviour
{
	public static bool puzzle2 = false;
	public ParticleSystem particlesBooks;
	
	public AudioSource audioSource;
	public AudioClip smallStep;
	public AudioClip fullStep;
	public float volume = 0.75f;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("puzzle2") && level1_puzzle1.puzzle1)
		{
				particlesBooks.Stop();
				audioSource.PlayOneShot(fullStep, volume);
				puzzle2 = true;

		}
	}
}
