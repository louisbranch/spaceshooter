using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;

	private void Update() {
		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		if (vMove != 0) {
			transform.Translate(Vector3.up * speed * Mathf.Sign(vMove) * Time.deltaTime);
		} 

		if (hMove != 0) {
			transform.Translate(Vector3.right * speed * Mathf.Sign(hMove) * Time.deltaTime);
		}
	
	}
}
