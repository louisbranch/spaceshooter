using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float laserSpeed = 4.5f;

	public GameObject projectile;

	private float nextFire = 0f;

	private void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range(1,5);
			Vector3 position = transform.position;
			position.y -= 0.03f;
			GameObject laser = (GameObject)Instantiate(projectile, position, Quaternion.identity);
			laser.rigidbody2D.velocity = Vector3.left * laserSpeed;
		}
	}

}
