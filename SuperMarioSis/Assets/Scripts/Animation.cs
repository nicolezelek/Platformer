using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {
		public Rigidbody myRigidbody;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	// if the player is moving
		//is the player holding down any buttons?
		// remember our last transform.position in a variable, then take our current one
		// grab the rigidbody.velocity and look at magnitude
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
			
			animation.CrossFade("Walk");
		} else if (Input.GetKey(KeyCode.Space)){
			animation.CrossFade("Jump");
		} 
		
		else {
        	animation.CrossFade ("Idle");
		}

		
	}
}
