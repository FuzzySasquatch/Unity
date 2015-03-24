using UnityEngine;
using System.Collections;

public class OnTargetStay : MonoBehaviour {

	private bool isInside = false;
	public bool IsInside
	{
		set
		{
			isInside = value;
		}
		get
		{
			return isInside;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Slink") {
			isInside = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Slink") {
			isInside = false;

		}
	}
}
