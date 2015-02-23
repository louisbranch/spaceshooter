using UnityEngine;
using System.Collections;

// Class responsible to handle enemy shooting and lifecycle
public class EnemyAI : MonoBehaviour {

	public float laserSpeed = 4.5f;

	public GameObject projectile;

	private float nextFire = 0f;

	private void Update () {
		// fires a new projectile between 1..5 seconds
		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range(1,5);
			GameObject laser = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			laser.rigidbody2D.velocity = Vector3.left * laserSpeed;
		}

		// destroy enemy if it is out of camera bounds
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
	}
	
}
