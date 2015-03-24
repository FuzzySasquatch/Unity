using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	private bool checkPoint = false;
	public bool sam = false; 
	private bool slink = false, biggie = false;
	public int checkPointNumber;

	public Vector3[] playerPositions;

	public CheckPointControl checkPointCtrl;

	void Update () 
	{
		checkPoint = sam && slink && biggie;
//		print(checkPoint);

		if (checkPoint)
		{
			checkPointCtrl.UpdateCheckPoint(checkPointNumber, playerPositions);
			sam = false;
			slink = false;
			biggie = false;
			Destroy(this);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Sam") {
			sam = true;
		}
		if (other.tag == "Slink") {
			slink = true;
		}
		if (other.tag == "Biggie") {
			biggie = true;
		}
	}
}
