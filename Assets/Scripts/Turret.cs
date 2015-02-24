using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	
	public float duration = 5f;
	public GameObject projectile;
	public GameObject cannon;

	private float nextFire = 0f;	
	private float counter;
	
	public void Activate () {
		counter = Time.time;
		gameObject.SetActive(true);
	}
	
	private void Update () {
		if (counter > 0 && (Time.time - counter > duration)) {
			gameObject.SetActive(false);
			counter = 0;
		}

		// fires a new projectile every second
		if (counter > 0 && Time.time > nextFire) {
			nextFire = Time.time + 1;
			GameObject laser = (GameObject)Instantiate(projectile, cannon.transform.position, transform.rotation);
			//laser.rigidbody2D.velocity;
		}

		if (Input.GetKey("z")) {
			transform.Rotate(new Vector3(0, 0, 3f));
		}

		if (Input.GetKey("x")) {
			transform.Rotate(new Vector3(0, 0, -3f));
		}
	}
}
