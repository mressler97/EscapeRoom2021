using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform onHand;
	public Transform PO;

	void OnMouseDown() {
		GetComponent<Rigidbody>().useGravity = false;
		this.transform.position = onHand.transform.position;
		this.transform.parent = PO.transform;
		//this.transform.parent = GameObject.Find("First person controller").transform;
	}

	void OnMouseUp (){
		this.transform.parent = null;
		GetComponent<Rigidbody>().useGravity = true;
	}
}