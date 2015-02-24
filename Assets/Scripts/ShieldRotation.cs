using UnityEngine;
using System.Collections;

public class ShieldRotation : MonoBehaviour {

	private void Update () {
		transform.Rotate(new Vector3(0, 0, -3f));
	}
}
