using UnityEngine;
using System.Collections;

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

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "EnemyProjectile") {
			Destroy(this);
		}
	}
}