using UnityEngine;
using System.Collections;

public class PacingCounter : MonoBehaviour {

	public int count = 0;
	public GameObject moveRight;
	public GameObject moveLeft;
	private const int paceCount = 1;

//	public Animator[] anims;
//	public Animator b;
//	public Animator big;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		// triggers when big walks far enough left
		if (other.gameObject.tag == "Biggie") 
		{
			// destroys the left counter
			Destroy(this.gameObject.GetComponent<Collider2D>());
			if (count < paceCount)
			{
				// changes the animation
				moveLeft.SetActive(false);
				moveRight.SetActive(true);

				// enables the right counter
				yield return new WaitForSeconds(0.2f);
				this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
			}
			count += 1;

			// disables move right animation
			if (count > paceCount)
			{
				moveRight.SetActive(false);
				yield return new WaitForSeconds(0.2f);
				count += 1;
			}
		}
	}
}
