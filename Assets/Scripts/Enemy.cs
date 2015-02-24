using UnityEngine;
using System.Collections;

// Class responsible to handle enemy shooting and lifecycle
public class Enemy : Entity {
	
	public GameObject projectile;
	public GameObject cannon;

	private float nextFire = 0f;
	private float speed = 1.5f;
	private Vector3 laserVel;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	private void Start () {
		laserVel = rigidbody2D.velocity * speed;
	}

	private void Update () {
		// fires a new projectile between 1..5 seconds
		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range(1,5);
			GameObject laser = (GameObject)Instantiate(projectile, cannon.transform.position, transform.rotation);
			laser.rigidbody2D.velocity = laserVel;
		}

		// destroy enemy if it is out of camera bounds
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
	}

	override public void Kill () {
		anim.SetTrigger("Explode");				// play animation
		transform.collider2D.enabled = false;  	// disable further collisions
		rigidbody2D.velocity = Vector3.zero; 	// stop movement
	}

	// Callback to destroy object after the end of animation
	public void DestroyInstance () {
		Transform[] allChildren =  GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			Destroy(child.gameObject);       	// destroy each child of enemy
		}
		Destroy(this.gameObject);
	}
}
