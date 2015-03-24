using UnityEngine;
using System.Collections;

public class LaserPush : MonoBehaviour {

	public BigArmsController control;
	public GameObject sam, big;
	private GameObject samDust, bigDust;
	public AudioClip buzzSound;
	public CheckPointControl checkPointCtrl;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{


		// make Saxon and Sam burn when going through the laser
		// if it's slink he is shocked
//		print ("buzz");
		AudioSource.PlayClipAtPoint(buzzSound, transform.position);
		if (other.tag == "Sam" || other.tag == "Biggie")
		{
				Vector3 pos = other.gameObject.transform.position;
				Vector2 vel = other.gameObject.GetComponent<Rigidbody2D>().velocity;
				other.gameObject.SetActive(false);

			if (other.tag == "Sam") {
//				other.gameObject.GetComponent<Sam>().stop = true;
				samDust = (GameObject) Instantiate(sam, pos, Quaternion.identity); 
				samDust.GetComponent<Rigidbody2D>().velocity = vel;
				other.gameObject.GetComponent<Sam>().stop = true;
			} else {
				// Disable raging
				if (control.raging) {
					control.raging = false;
					control.rageHead.GetComponent<Renderer>().enabled = false;
					control.regHead.GetComponent<Renderer>().enabled = true;
					control.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
				bigDust = (GameObject) Instantiate(big, pos, Quaternion.identity); 
				bigDust.GetComponent<Rigidbody2D>().velocity = vel;
			}
//			yield return new WaitForSeconds(0.1f);
//			samDust.collider2D.isTrigger = false;

//			SoundEffectsHelper.Instance.MakeLaserSound(); // change this
			yield return new WaitForSeconds(2f);

			if (checkPointCtrl.currentCheckPoint > -1)
			{
				other.gameObject.SetActive(true);
				if (samDust) Destroy(samDust.gameObject);
				if (bigDust) Destroy(bigDust.gameObject);
				checkPointCtrl.Reset();
			}
			else
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
//		if (other.tag == "Slink")
//		{
//			this.collider2D.isTrigger = false;
//			yield return new WaitForSeconds(0.05f);
//			this.collider2D.isTrigger = true;
//		}
	}
}
