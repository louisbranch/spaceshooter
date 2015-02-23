using UnityEngine;
using System.Collections;

// Class responsible to spawn new enemies ships
public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	public float enemySpeed = 1.0f;

	public Vector2 direction = Vector3.left;

	private float nextSpawn;

	// Spawn a new enemy every 3..5 seconds
	private void Update () {
		if (Time.time > nextSpawn) {
			GameObject ship = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
			ship.rigidbody2D.velocity = direction * enemySpeed;
			nextSpawn = Time.time + Random.Range(3, 5);
		}
	}
}
