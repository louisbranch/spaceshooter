using UnityEngine;
using System.Collections;

// Class responsible for player movement on screen,
// firing weapons and picking powerups
public class Player : Entity {
	
	public float speed = 1.0f;
	public float fireRate = 3.0f;
	public float laserSpeed = 3.0f;

	public GameObject engine;
	public GameObject projectile;
	public GameObject cannon;
	
	private float nextFire = 0f;
	private bool dead = false;

	public Animator anim;
	
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
	
		// Instanciate a new player laser every time the fire button is pressed, with a delay of fireRate between shots
		bool fire = Input.GetButton("Fire1");
		if (fire && (Time.time > nextFire)) {
			nextFire = Time.time + fireRate;
			GameObject laser = (GameObject)Instantiate(projectile, cannon.transform.position, Quaternion.identity);
			laser.rigidbody2D.velocity = Vector3.right * laserSpeed;
		} 
	}


	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Enemy") {
			TakeDamage(1);
			coll.GetComponent<Entity>().TakeDamage(1);
		}
	}

	override public void Kill () {
		anim.SetTrigger("Explode");				// play animation
		transform.collider2D.enabled = false;  	// disable further collisions
		dead = true;							// prevent further interactions
		engine.SetActive(false);				// disable engine sprites
	}

	// Callback to destroy object after the end of animation
	public void DestroyInstance () {
		Application.LoadLevel("MainMenu");
	}

}