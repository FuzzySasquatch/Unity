using UnityEngine;
using System.Collections;

public class Lap : MonoBehaviour {

	public bool lap = false;
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Slink")
		{
			lap = true;
		}
	}
	
}
