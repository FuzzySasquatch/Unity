using UnityEngine;
using System.Collections;

public class ToggleIgnoreColl : MonoBehaviour {

	public bool ignore = false;
	public float ignores = 0;
	public GameObject other1;
	public GameObject other2;
	
	void FixedUpdate () 
	{
		// renables collisions between this and other1 and 2
		if (ignores > 1) 
		{
			ignore = false;
			ignores = 0;
			Physics2D.IgnoreCollision(other1.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>(), false);
			Physics2D.IgnoreCollision(other2.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>(), false);
		}
		// ignores collisions between these objects
		if (ignore) {
			Physics2D.IgnoreCollision(other1.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
			Physics2D.IgnoreCollision(other2.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
		}
	}
}
