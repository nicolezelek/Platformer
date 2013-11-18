using UnityEngine;
using System.Collections;

public class water : MonoBehaviour {
	public Rigidbody player;
 
	public float scrollSpeed = 0.5F;
	
	void Update () {
		
		float offset = Time.time * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
	
	}
	void OnTriggerEnter(){
		player.transform.position = new Vector3(1f,1f,-9f);
	
	}
}
