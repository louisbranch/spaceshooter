using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

	public GameObject[] powerups;

	public float spawnSpeed = 10f;

	private float nextSpawn = 0;

	private void Update () {
		// spawn a new powerup every 10s around the spawner point
		if (Time.time > nextSpawn) {
			int rnd = Random.Range(0, powerups.Length);
			GameObject powerup = powerups[rnd];
			Vector2 position;
			position.x = transform.position.x + Random.Range(-1f, 1f);
			position.y = transform.position.y + Random.Range(-1f, 1f);
			nextSpawn = Time.time + spawnSpeed;
			GameObject instance = (GameObject)Instantiate(powerup, position, transform.rotation);
			instance.rigidbody2D.velocity = Vector3.left * 3f;
		}
	}

}
