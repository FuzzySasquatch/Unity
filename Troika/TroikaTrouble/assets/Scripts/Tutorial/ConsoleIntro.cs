using UnityEngine;
using System.Collections;

public class ConsoleIntro : MonoBehaviour 
{
	public GameObject objectToDisable;
	public float hackSeconds = 7f;

	public AudioClip keyPressSound;
	public AudioClip floorSwitchSound;

	void OnTriggerEnter2D(Collider2D collider){
		print ("Trigger Enter");
		if(collider.tag == "Sam") {
			print ("NEAR CONSOLE");
			collider.GetComponent<Sam>().nearConsole = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider){
		print ("Trigger Exit");
		if(collider.tag == "Sam") {
			print ("NOT NEAR CONSOLE");
			collider.GetComponent<Sam>().nearConsole = false;
		}
	}

	public IEnumerator Hack() {
//		Debug.Log("start coroutine");
		AudioSource.PlayClipAtPoint(keyPressSound, transform.position);
		yield return new WaitForSeconds(4.0f);

		objectToDisable.SetActive(false);
		this.rigidbody2D.isKinematic = false;
		Destroy(this.gameObject.collider2D);
		this.gameObject.GetComponent<ToggleIgnoreColl>().enabled = true;

		AudioSource.PlayClipAtPoint(floorSwitchSound, transform.position);
		//		SoundEffectsHelper.Instance.MakeLaserSound(); // change this
		yield return new WaitForSeconds(hackSeconds);
		this.collider2D.enabled = true;
		Destroy(this);
//		this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

//		AudioSource.PlayClipAtPoint(laserSound, transform.position);
		//		SoundEffectsHelper.Instance.MakeLaserSound(); // change this
	}
}
