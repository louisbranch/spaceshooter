using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	private void Update () {
		// destroy powerup if it is out of camera bounds
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
	}

}
