using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	private bool sam = false;
	private bool biggie = false;
	private bool slink = false;
	private bool exit = false;
	
	public GameObject samObj;
//	public LevelControl lvlCtrl;
	
	void Update () 
	{
		exit = samObj.GetComponent<Sam>().exit;
		if (biggie && slink && sam && (Input.GetKeyDown(KeyCode.Escape) || exit)) 
		{
//			lvlCtrl.NextLevel();
			Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
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
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Sam") {
			sam = false;
		}
		if (other.tag == "Slink") {
			slink = false;
		}
		if (other.tag == "Biggie") {
			biggie = false;
		}
	}
}
