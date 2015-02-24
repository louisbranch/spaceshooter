using UnityEngine;
using System.Collections;

abstract public class Entity : MonoBehaviour {

	public int health = 1;
	
	public void TakeDamage(int dmg) {
		health -= dmg;
		if (health <= 0) {
			Kill();
		}
	}

	abstract public void Kill ();

}
