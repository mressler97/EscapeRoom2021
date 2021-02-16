using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaScript : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player") && !playerController.step1)
		{
			other.gameObject.transform.position = new Vector3(0.907f, -0.08f, 1.45f);
		}
		if (other.gameObject.CompareTag("Player") && playerController.step2)
		{
			other.gameObject.transform.position = new Vector3(33.56f, 3.25f, 1.45f);
		}
	}
}
