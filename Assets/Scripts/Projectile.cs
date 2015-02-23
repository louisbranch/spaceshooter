using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public string target;

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == target) {
			Transform[] allChildren =  coll.GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren) {
				Destroy(child.gameObject);
			}
			Destroy(this);
		}
	}
}
