using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

	public GameObject[] powerups;

	public float spawnSpeed = 10f;

	private float nextSpawn = 0;

	private void Update () {
		// spawn a new powerup every 10s around the spawner point
		if (Time.time > nextSpawn) {
			GameObject powerup = powerups[Random.Range(0, powerups.Length - 1)];
			Vector2 position;
			position.x = transform.position.x + Random.Range(-1f, 1f);
			position.y = transform.position.y + Random.Range(-1f, 1f);
			nextSpawn = Time.time + spawnSpeed;
			GameObject laser = (GameObject)Instantiate(powerup, position, transform.rotation);
		}
	}

}
