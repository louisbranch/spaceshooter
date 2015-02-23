using UnityEngine;
using System.Collections;

// Class responsible to handle projectile collisions, animations and its lifecycle
public class Projectile : MonoBehaviour {

	public string target;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	// Destroy projectile if it is out of camera bounds
	private void Update () {
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == target) {
			Transform[] allChildren =  coll.GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren) {
				Destroy(child.gameObject);       // destroy each child of target
			}
			Destroy(coll.gameObject);            // destroy target
			anim.SetTrigger("Explode");          // play animation
			rigidbody2D.velocity = Vector3.zero; // stop movement
			transform.collider2D.enabled = false;  // disable further collisions
		}
	}

	// Callback to destroy object after the end of animation
	public void DestroyInstance () {
		Destroy(this.gameObject);
	}
}
