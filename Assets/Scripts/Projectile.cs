using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public string target;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == target) {
			Transform[] allChildren =  coll.GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren) {
				Destroy(child.gameObject);
			}
			Destroy(coll.gameObject);
			anim.SetTrigger("Explode");
			rigidbody2D.velocity = Vector3.zero;
		}
	}

	public void DestroyProjectile () {
		Destroy(this.gameObject);
	}
}
