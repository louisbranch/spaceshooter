using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public float fireRate = 3.0f;
	public float laserSpeed = 3.0f;

	public GameObject projectile;

	private float nextFire = 0f;

	private void Update () {
		bool fire = Input.GetButton("Fire1");
		if (fire && (Time.time > nextFire)) {
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			position.y -= 0.03f;
			GameObject laser = (GameObject)Instantiate(projectile, position, Quaternion.identity);
			laser.rigidbody2D.velocity = Vector3.right * laserSpeed;
		} 
	}

}
