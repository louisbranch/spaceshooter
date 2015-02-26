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
	public GameObject shield;
	public GameObject turret;
	
	private float nextFire = 0f;
	private bool dead = false;

	private Animator anim;

	private Vector2 minBounds;
	private Vector2 maxBounds;

	private void Awake () {
		anim = GetComponent<Animator>();
		Camera mainCamera = Camera.main;


	}

	private void Update() {
		if (dead) return;

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		Vector2 oldP = transform.position;
		Vector2 newP;

		// Vertical movement at constant speed
		if (vMove != 0) {
			newP = oldP + (Vector2.up * speed * Mathf.Sign(vMove) * Time.deltaTime);
			transform.position = newP;
		}

		oldP = transform.position;
		// Horizontal movement at constant speed
		if (hMove != 0) {
			newP = oldP + (Vector2.right * speed * Mathf.Sign(hMove) * Time.deltaTime);
			transform.position = newP;
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
			GameObject laser = (GameObject)Instantiate(projectile, cannon.transform.position, transform.rotation);
			laser.rigidbody2D.velocity = Vector3.right * laserSpeed;
		} 
	}


	private void OnTriggerEnter2D (Collider2D coll) {
		switch (coll.tag) {
		case "Enemy":
			TakeDamage(1);
			coll.GetComponent<Entity>().TakeDamage(1);
			break;
		case "Shield":
			shield.GetComponent<Shield>().Activate();
			Destroy(coll.gameObject);
			break;
		case "Turret":
			turret.GetComponent<Turret>().Activate();
			Destroy(coll.gameObject);
			break;
		default:
			break;
		}
	}

	override public void Kill () {
		anim.SetTrigger("Explode");				// play animation
		transform.collider2D.enabled = false;  	// disable further collisions
		dead = true;							// prevent further interactions
		engine.SetActive(false);				// disable engine sprites
		turret.renderer.enabled = false;		// disable turret
	}

	// Callback to destroy object after the end of animation
	public void DestroyInstance () {
		Application.LoadLevel("MainMenu");
	}

}