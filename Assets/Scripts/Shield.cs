using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public float duration = 5f;

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
	}

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Enemy") {
			coll.GetComponent<Entity>().TakeDamage(1);
		}
	}
}
