using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public float fireRate = 3.0f;

	private float nextFire = 0f;

	private void Update () {
		bool fire = Input.GetButton("Fire1");
		if (fire && (Time.time > nextFire)) {
			nextFire = Time.time + fireRate;
			Debug.Log ("FIRE!");
		} 
	}

}
