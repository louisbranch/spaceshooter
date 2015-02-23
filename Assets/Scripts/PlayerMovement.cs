using UnityEngine;
using System.Collections;

// Class responsible for player movement on screen
public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;

	public GameObject engine;

	private void Update() {
		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		// Vertical movement at constant speed
		if (vMove != 0) {
			transform.Translate(Vector3.up * speed * Mathf.Sign(vMove) * Time.deltaTime);
		} 

		// Horizontal movement at constant speed
		if (hMove != 0) {
			transform.Translate(Vector3.right * speed * Mathf.Sign(hMove) * Time.deltaTime);
		}

		// Toggle engine sprites display
		if (hMove != 0 || vMove != 0) {
			engine.SetActive(true);
		} else {
			engine.SetActive(false);
		}
	
	}


}