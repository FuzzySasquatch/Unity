﻿using UnityEngine;
using System.Collections;

public class LaserPush : MonoBehaviour {

	public GameObject sam;
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
			Vector2 vel = other.gameObject.rigidbody2D.velocity;
			other.gameObject.SetActive(false);
			other.gameObject.GetComponent<Sam>().stop = true;
			GameObject samDust = (GameObject) Instantiate(sam, pos, Quaternion.identity); 
			samDust.rigidbody2D.velocity = vel;
//			yield return new WaitForSeconds(0.1f);
//			samDust.collider2D.isTrigger = false;

//			SoundEffectsHelper.Instance.MakeLaserSound(); // change this
			yield return new WaitForSeconds(2f);

			if (checkPointCtrl.currentCheckPoint > -1)
			{
				other.gameObject.SetActive(true);
				Destroy(samDust.gameObject);
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
