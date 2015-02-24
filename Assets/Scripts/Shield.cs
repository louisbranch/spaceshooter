using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D coll) {
		Destroy(coll.gameObject);
	}
}
