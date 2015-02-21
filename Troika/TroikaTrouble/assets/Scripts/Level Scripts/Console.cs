using UnityEngine;
using System.Collections;

public class Console : MonoBehaviour 
{
	public GameObject objectToDisable;
	public float hackSeconds = 7f;

	public AudioClip hackSound;
	public AudioClip laserSound;

	void OnTriggerEnter2D(Collider2D collider){
//		print ("Trigger Enter");
		if(collider.tag == "Sam") {
//			print ("NEAR CONSOLE");
			collider.GetComponent<Sam>().nearConsole = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider){
//		print ("Trigger Exit");
		if(collider.tag == "Sam") {
//			print ("NOT NEAR CONSOLE");
			collider.GetComponent<Sam>().nearConsole = false;
		}
	}

	public IEnumerator Hack() {
//		Debug.Log("start coroutine");

		AudioSource.PlayClipAtPoint(hackSound, transform.position);
		yield return new WaitForSeconds(4.0f);
		objectToDisable.SetActive(false);
		AudioSource.PlayClipAtPoint(laserSound, transform.position);
//		SoundEffectsHelper.Instance.MakeLaserSound(); // change this
		yield return new WaitForSeconds(hackSeconds);
		AudioSource.PlayClipAtPoint(laserSound, transform.position);
//		SoundEffectsHelper.Instance.MakeLaserSound(); // change this
		objectToDisable.SetActive(true);
	}
}
