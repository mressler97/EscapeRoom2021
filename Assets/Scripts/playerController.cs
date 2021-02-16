using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
	public Text events;
	
	private float timeToAppear = 2f;
	private float timeToAppear2 = 5f;
	private float timeToDisappear;
	private bool doorsound = false;
	public static bool step1 = false;
	public static bool step2 = false;
	public static bool step3 = false;
	public static bool step4 = false;
	public static bool isVaccineHeld = false;

	public GameObject vaccine;
	public GameObject vaccineImg;
	public GameObject endTrigger;
	public ParticleSystem particlesEnd;
	
	public AudioSource audioSource;
	public AudioClip smallStep;
	public AudioClip fullStep;
	public float volume = 0.75f;
	private Camera cam;
	public GameObject pwd;
	public GameObject pwd2;
	

    // Update is called once per frame
    void Update()
    {

		
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 2.0f))
		{
			var selection = hit.transform;
			
			if (selection.CompareTag("computer") && (Input.GetMouseButtonDown(0)))
			{
				cam = selection.GetComponentInChildren<Camera>();
				pwd.SetActive(true);
				pwd2.SetActive(true);
				cam.enabled = true;
				EnableTextComputers();
			}
			if (selection.CompareTag("vaccine") && (Input.GetMouseButtonDown(0)))
			{
				step3 = true;
				vaccine.SetActive(false);
				//keyImg.SetActive(true);
				
				isVaccineHeld = true;
				audioSource.PlayOneShot(smallStep);
				endTrigger.SetActive(true);
				particlesEnd.Play();
				EnableTextFinish();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.E) && cam.enabled == true)
		{
			cam.enabled = false;
			pwd.SetActive(false);
			pwd2.SetActive(false);
		}
		
		if (events.enabled && (Time.time >= timeToDisappear))
		{
			events.enabled = false;
		}
    }
	
	public void EnableTextComputers()
	{
		events.enabled = true;
		events.text = "Press E to go back!";
		timeToDisappear = Time.time + timeToAppear;
	}
	
	public void EnableTextFinish()
	{
		events.enabled = true;
		events.text = "Now get back to the front door and get out!";
		timeToDisappear = Time.time + timeToAppear2;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!step1)
		{
			if(other.gameObject.CompareTag("step1"))
			{
				audioSource.PlayOneShot(fullStep, volume);
				step1 = true;
			}
		}
		
		if (!doorsound)
		{
			if(other.gameObject.CompareTag("step2"))
			{
				audioSource.PlayOneShot(fullStep, volume);
				step1 = true;
				doorsound = true;
			}
		}
		
		if (other.gameObject.CompareTag("step4"))
		{
			step4 = true;
			audioSource.PlayOneShot(fullStep, volume);
		}
	}
	


}
