using UnityEngine;
using System.Collections;

public class IgnoreCollison : MonoBehaviour {

	public Transform objToIgnore;
//	private bool ignored = false;
	// Use this for initialization

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Sam" || other.gameObject.tag == "Biggie" || other.gameObject.tag == "Dust")
		{
			Physics2D.IgnoreCollision(other.transform.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
			objToIgnore = other.transform;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Physics2D.IgnoreCollision(objToIgnore.transform.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
	}
}
