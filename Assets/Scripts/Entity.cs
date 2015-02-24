using UnityEngine;
using System.Collections;

abstract public class Entity : MonoBehaviour {

	public int health = 1;

	// Reduce entity health and kill it when reaches 0
	public void TakeDamage(int dmg) {
		health -= dmg;
		if (health <= 0) {
			Kill();
		}
	}

	// Method to destroy the enity
	abstract public void Kill ();

}
