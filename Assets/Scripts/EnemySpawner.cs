using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	public float enemySpeed = 1.0f;

	public Vector2 direction = Vector3.left;

	private float nextSpawn;

	private void Update () {
		if (Time.time > nextSpawn) {
			Vector3 position = transform.position;
			GameObject ufo = (GameObject)Instantiate(enemy, position, Quaternion.identity);
			ufo.rigidbody2D.velocity = direction * enemySpeed;
			nextSpawn = Time.time + Random.Range(3, 5);
		}
	}
}
