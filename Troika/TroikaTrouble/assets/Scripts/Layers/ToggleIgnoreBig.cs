using UnityEngine;
using System.Collections;

public class ToggleIgnoreBig : ToggleIgnoreColl {

	void FixedUpdate () 
	{
		if (Input.GetButtonDown("Ignore"))
	   {
		    ignore = true;
		    ignores += 1;
		}
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
