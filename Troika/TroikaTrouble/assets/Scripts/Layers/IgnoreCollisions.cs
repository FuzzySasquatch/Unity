using UnityEngine;
using System.Collections;

public class IgnoreCollisions : MonoBehaviour {

	public GameObject other1;

	void FixedUpdate () 
	{
		Physics2D.IgnoreCollision(other1.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
	}
}
