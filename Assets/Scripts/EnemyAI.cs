using UnityEngine;
using System.Collections;

// Class responsible to handle enemy shooting and lifecycle
public class EnemyAI : MonoBehaviour {
	
	public GameObject projectile;
	public GameObject cannon;

	private float nextFire = 0f;
	private float speed = 1.5f;

	private void Update () {
		// fires a new projectile between 1..5 seconds
		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range(1,5);
			GameObject laser = (GameObject)Instantiate(projectile, cannon.transform.position, transform.rotation);
			laser.rigidbody2D.velocity = rigidbody2D.velocity * speed;
		}

		// destroy enemy if it is out of camera bounds
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
	}
	
}
