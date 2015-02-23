using UnityEngine;
using System.Collections;

// Class responsible for firing and picking up player weapons and powerups
public class PlayerWeapon : MonoBehaviour {

	public float fireRate = 3.0f;
	public float laserSpeed = 3.0f;

	public GameObject projectile;

	private float nextFire = 0f;

	// Instanciate a new player laser every time the fire button is pressed, with a delay of fireRate between shots
	private void Update () {
		bool fire = Input.GetButton("Fire1");
		if (fire && (Time.time > nextFire)) {
			nextFire = Time.time + fireRate;
			GameObject laser = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			laser.rigidbody2D.velocity = Vector3.right * laserSpeed;
		} 
	}

}
