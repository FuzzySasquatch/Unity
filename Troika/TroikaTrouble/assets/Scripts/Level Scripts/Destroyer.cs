using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public CheckPointControl checkPointCtrl;

	void OnTriggerEnter2D(Collider2D other)
	{
		/*  if (checkpoint)
		    move characters to checkpoint
		    else
		    load level*/
//		print("collison");
		if (other.tag == "Sam" || other.tag == "Biggie" || other.tag == "Slink" || other.tag == "Terminal")
		{
			checkPointCtrl.Reset();
			if (other.tag == "Sam")
			{
				other.gameObject.GetComponent<Sam>().stop = true;
			}
		}
		else 
		{
//			Debug.Log(other);
			Destroy(other.gameObject);
		}
	}
}
