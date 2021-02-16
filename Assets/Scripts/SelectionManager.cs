using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
	public Text events;
	
	private float timeToAppear = 6f;
	private float timeToDisappear;
	
	private bool step1 = false;
	private bool step2 = false;
	private bool step3 = false;
	public static bool isKeyHeld = false;
	
	public ParticleSystem particlesBooks;
	public ParticleSystem particlesPhone;
	public ParticleSystem particlesKey;
	
	public AudioSource audioSource;
	public AudioClip oldLadySounds;
	public AudioClip smallStep;
	public AudioClip fullStep;
	public float volume = 0.75f;
	
	public GameObject clipboard;
	public GameObject key;
	public GameObject keyImg;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 2.0f))
		{
			var selection = hit.transform;
			
			//collect books step
			if (selection.CompareTag("step1") && !level1_puzzle1.puzzle1)
			{
				if (!step1)
				{
					particlesBooks.Play();
					audioSource.PlayOneShot(oldLadySounds);
					EnableText();
					step1 = true;
				}
			}
			//phone step
			if (selection.CompareTag("step1") && level1_puzzle1.puzzle1 && !level1_puzzle2.puzzle2)
			{
				if (!step2)
				{
					particlesPhone.Play();
					audioSource.PlayOneShot(oldLadySounds);
					EnableText2();
					step2 = true;
				}
			}
			//wardrobe step
			if (selection.CompareTag("step1") && level1_puzzle1.puzzle1 && level1_puzzle2.puzzle2)
			{
				if (!step3)
				{
					audioSource.PlayOneShot(oldLadySounds);
					EnableText3();
					step3 = true;
				}
			}
			
			if (selection.CompareTag("step2") && (Input.GetMouseButtonDown(0)) && level1_puzzle2.puzzle2)
			{
				selection.position = new Vector3(-0.8f, selection.position.y , selection.position.z);
				clipboard.SetActive(true); 
			}
			
			if (selection.CompareTag("key") && (Input.GetMouseButtonDown(0)))
			{
				key.SetActive(false);
				keyImg.SetActive(true);
				isKeyHeld = true;
				audioSource.PlayOneShot(smallStep);
				particlesKey.Play();
			}
			
			if (selection.CompareTag("keyhole") && (Input.GetMouseButtonDown(0)) && isKeyHeld)
			{
				audioSource.PlayOneShot(fullStep);
				GameController.levelOneComplete = true;
			}
		}
		
		if (events.enabled && (Time.time >= timeToDisappear))
		{
			events.enabled = false;
		}
        
    }
	
	// grandma dialogue
	public void EnableText()
	{
		events.enabled = true;
		events.text = "If you want me to help, gather my books laying around and put them onto the shelf by the door!";
		timeToDisappear = Time.time + timeToAppear;
	}
	
	public void EnableText2()
	{
		events.enabled = true;
		events.text = "Now help me find my phone and put it on this table!";
		timeToDisappear = Time.time + timeToAppear;
	}
	
	public void EnableText3()
	{
		events.enabled = true;
		events.text = "Fine, I'll take the vaccine now. The keys to the door are in the safe... the password is around here somewhere.";
		timeToDisappear = Time.time + timeToAppear;
	}
}
