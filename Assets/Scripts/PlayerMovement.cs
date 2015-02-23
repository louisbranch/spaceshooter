using UnityEngine;
using System.Collections;

// Class responsible for player movement on screen
public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	
	public GameObject engine;

	private bool dead = false;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	private void Update() {
		if (dead) return;

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
		if (coll.tag == "Enemy") {
			Destroy(coll.gameObject);				// destroy enemy
			anim.SetTrigger("Explode");				// play animation
			transform.collider2D.enabled = false;  	// disable further collisions
			dead = true;							// prevent further interactions
			engine.SetActive(false);				// disable engine sprites
		}
	}

	// Callback to destroy object after the end of animation
	public void DestroyInstance () {
		Transform[] allChildren =  GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			Destroy(child.gameObject);       // destroy each child of player
		}
		Destroy(this.gameObject);
	}

}