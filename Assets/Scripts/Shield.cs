using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Enemy") {
			coll.GetComponent<Entity>().TakeDamage(1);
		}
	}
}
