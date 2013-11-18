using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	// Variables: 
	Vector3 inputVector;
	public float speed = .5f;
	public float jumpSpeed = 10;
	public float moveSpeed = 10f;
	public bool grounded = true; 
	public float turnSpeed = 50;
	public float fallSpeed = 20; 
	public float movement;
	public float turning;
	public AudioSource jumpSound; 
	
	void Update () {
		inputVector=Vector3.zero;
		
		if (Input.GetAxis ("Vertical") != 0) {
			movement = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			transform.Translate (0f,0f, movement);
			Debug.Log (movement);
		}
		
		if (Input.GetAxis ("Horizontal") != 0) {
			turning = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
			transform.Rotate (0f, turning, 0f);
		}
		
		/* Arrow Key Movement
		inputVector = Vector3.zero;
		if(Input.GetKey(KeyCode.UpArrow)||(Input.GetKey(KeyCode.W))){
			inputVector += transform.forward;
		}
		if(Input.GetKey(KeyCode.DownArrow)||(Input.GetKey(KeyCode.S))){
			inputVector += -transform.forward;
		}
		if(Input.GetKey(KeyCode.LeftArrow)||(Input.GetKey(KeyCode.A))){
			transform.Rotate(0f,-turnSpeed* Time.deltaTime,0f);
		}
		if(Input.GetKey(KeyCode.RightArrow)||(Input.GetKey(KeyCode.R))){
			transform.Rotate(0f,turnSpeed* Time.deltaTime,0f);
		}
	*/
		if (Input.GetKeyDown(KeyCode.Space))
        jumpSound.Play();
		
	}
	
	void FixedUpdate(){
		// Jump
		// Detect if Grounded
		
		  Ray ray = new Ray(transform.position, -transform.up);
			RaycastHit rayHit = new RaycastHit();
			//detect if grounded, and if only a single jump has taken place
			if (Physics.Raycast(ray, out rayHit, transform.localScale.y)){ 
				grounded = true;
			}
		// If grounded, jump is possible. Space = jump. 
			if(Input.GetKeyDown(KeyCode.Space)){
				if(grounded){
					inputVector += (Vector3.up * jumpSpeed); 
					grounded = false;
				}}
	
		
		if (inputVector != Vector3.zero){
				rigidbody.AddForce(inputVector * speed, ForceMode.VelocityChange);
		} else {
				rigidbody.AddForce(-rigidbody.velocity + Physics.gravity * fallSpeed, ForceMode.Acceleration);
		}
	
		
		
	
	}
	}

