using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public Sheep dolly;
	public TextMesh fameMeter; //assign this reference in the inspector.
	
	
	
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		// if rayHit==sheep
		if (Physics.Raycast (ray, out rayHit, 1000f)){
			if (rayHit.collider.tag == "Sheep" && Input.GetMouseButtonDown(0)){
				Sheep selectedSheep = rayHit.collider.GetComponent<Sheep>();
				fameMeter.text = ("sheep fame = " + selectedSheep.fame.ToString ());
			/*whatever code runs here is when the mouse is
			 * over a GameObject with a collider and Sheep tag
			 * and when the mouse is left-clicked*/
			}
			if (Input.GetMouseButtonDown(1)){
				Sheep newSheep = Instantiate(dolly, rayHit.point, Quaternion.identity) as Sheep;
				newSheep.fame = Random.Range (1,100);
			}
	
		}
	}
}
