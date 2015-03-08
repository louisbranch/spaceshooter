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

	private float minX;
	private float maxX;
	private float minY;
	private float maxY;

	private void Awake () {
		anim = GetComponent<Animator>();
		minX = Camera.main.transform.position.x - Camera.main.orthographicSize - 1;
		maxX = Camera.main.transform.position.x + Camera.main.orthographicSize + 1;
		minY = Camera.main.transform.position.y - Camera.main.orthographicSize + 0.5f;
		maxY = Camera.main.transform.position.y + Camera.main.orthographicSize - 0.5f;
	}

	private void Update() {
		if (dead) return;

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		float x = transform.position.x;
		float y = transform.position.y;

		// Vertical movement at constant speed limited by camera size
		if (vMove != 0) {
			y = Mathf.Clamp(y + (speed * Mathf.Sign(vMove) * Time.deltaTime), minY, maxY);
		}

		// Horizontal movement at constant speed
		if (hMove != 0) {
			x = Mathf.Clamp(x + (speed * Mathf.Sign(hMove) * Time.deltaTime), minX, maxX);
		}

		transform.position = new Vector2(x, y);

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
			Instantiate(projectile, cannon.transform.position, transform.rotation);
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