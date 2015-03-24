using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	private float force = 100f;
	public float waitDuration = 2f;
//	private bool fly = false;
	public GameObject parent;
	public GameObject arms;
	private bool raging = false;

	public AudioClip woodBreak;
	 
	void Update () {
//		if (fly)
//			gameObject.rigidbody2D.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)));
		raging = arms.GetComponent<BigArmsController>().raging;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "BigArms" && raging) {
			this.GetComponent<Rigidbody2D>().isKinematic = false;
//			AudioSource.PlayClipAtPoint(woodBreak, transform.position);
//			StartCoroutine(WallFly());
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)));
			StartCoroutine(WallFly());
		}
	}

	IEnumerator WallFly()
	{
//		fly = true;
		yield return new WaitForSeconds(waitDuration);
		parent.GetComponent<Collider2D>().enabled = false;
		this.GetComponent<Collider2D>().enabled = false;
		//Destroy(parent);
//		Destroy(gameObject);
//		fly = false;
	}
}
