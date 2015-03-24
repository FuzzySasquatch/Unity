using UnityEngine;
using System.Collections;

public class LearnThrow : MonoBehaviour {
	
	public GameObject moveWithTerminal;
	public GameObject pickUp;
	public GameObject moveLeft;
	public GameObject throwRight;

	public GameObject moveRight;

	public GameObject terminal;

	public LittleTutorial sam;


	private bool terminalGrabbed;
	private bool firstPass = true;

	// Use this for initialization
	void Start () {
		moveLeft.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
//		if (pickUp.activeInHierarchy) {
//			print("pickup");
//		}
		if (terminal.activeInHierarchy && throwRight.activeInHierarchy) {
			if (moveWithTerminal) moveWithTerminal.SetActive(false); // added this
			throwRight.SetActive(false);
			sam.moveRight.SetActive(true);
			sam.moveNHack = true;
		}
		/* get terminal is activeInHierarchy
           if it is then set throwRight.SetActive(false);
           call function for littletutorial */
	}

	// pickup the terminal
	public void TerminalGrabbed() {
		Destroy(moveLeft);
		Destroy(pickUp);//.SetActive(false);

		if (moveRight) moveRight.SetActive(false);

		if (moveWithTerminal) moveWithTerminal.SetActive(true);
		if (gameObject.GetComponent<Collider2D>())
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		// move left to terminal and pickup on entry
		bool isBig = other.tag == "Biggie";
		if (isBig && firstPass) {
			firstPass = false;
			if (pickUp) pickUp.SetActive(true);
			Destroy(moveLeft);//.SetActive(false);

			Destroy(this.gameObject.GetComponent<Collider2D>());

		}

		// move right with terminal
		if (moveWithTerminal.activeInHierarchy && isBig) {
			if (moveWithTerminal) Destroy(moveWithTerminal);//.SetActive(false);
			throwRight.SetActive(true);
		}
	}

	public void TerminalGrabbedEarly() {
		Destroy(this.gameObject.GetComponent<Collider2D>());
	}
}
