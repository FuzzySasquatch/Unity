using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour {

	private bool hitSeven = false;
	public bool HitSeven
	{
		get
		{
			return hitSeven;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Slink") {
			hitSeven = true;
		}
	}
}
