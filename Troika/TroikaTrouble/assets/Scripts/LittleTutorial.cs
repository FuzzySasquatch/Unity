using UnityEngine;
using System.Collections;

public class LittleTutorial : MonoBehaviour {

	public Sam sam;
	public PacingCounter pace;

	private bool typedRight;
	private bool typedLeft;
	private bool typedStop;
	private bool typedTaunt;
	private bool typedHack;
	private bool typedJumpRight;

	public GameObject moveRight;
	public GameObject moveLeft;
	public GameObject stop;
	public GameObject taunt;
	public GameObject hack;
	public GameObject jumpRight;

	public CameraFollow cam1;
	public CameraFollow2 cam2;

	public CheckPoint inCheckpoint;

	public bool first = true;

	private bool pacing;
	private bool canHack;
	public bool moveNHack;

	public float fallSeconds;

	private bool canJump;

	public GameObject big;

	void Start() {
		if (first)
			moveRight.SetActive(true);
	}

	void Update() {
		if (first) {
			typedRight = sam.right;
			typedLeft = sam.left;
			typedStop = sam.typedStop;
			typedJumpRight = sam.right && sam.jump;
			typedTaunt = sam.typedTaunt;
			LittleTutorialOne();
		}

		if (moveNHack) {
			MoveAndHack();
			typedRight = sam.right;
		}

		typedHack = sam.hack;

		if (canJump) {
			typedJumpRight = sam.jump && sam.right;
			if (typedJumpRight || inCheckpoint.sam) {
				canJump = false;
				Destroy(jumpRight);//.SetActive(false);
			}

		}

//		print(sam.right);
//		if (moveNHack) {
//			typedLeft = sam.left;
//			MoveAndHack();
//		}
	}
	
	void LittleTutorialOne() {
		if (typedRight) {
			print ("right");
			typedRight = false;
//			Destroy (moveRight);
			moveRight.SetActive(false);
			if (moveLeft) moveLeft.SetActive(true);
		}

		if (typedLeft && moveLeft) {
			moveRight.SetActive(false);
			Destroy(moveLeft);
//			moveLeft.SetActive(false);
			if (stop) stop.SetActive(true);
			// move sam right and left
			pacing = true;
			typedLeft = false;
			StartCoroutine(SamPacing());
		}

		if (typedStop && pacing) {
			sam.stop = true;
			print("stop");
			pacing = false;
			typedStop = false;
			stop.SetActive(false);
			if (taunt) taunt.SetActive(true);

			// stop moving sam
		}

		if (typedTaunt) {
			big.transform.position = new Vector2(-9.0f, big.transform.position.y);
			Destroy(moveLeft);
			moveRight.SetActive(false);//Destroy(moveRight);
			Destroy(stop);
			taunt.SetActive(false);
			first = false;
		}

	}

	public void MoveAndHack() {
//		moveNHack = true;



		// wait until typed right
		if (typedRight) {
			moveNHack = false;
			moveRight.SetActive(false);
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

			typedRight = false;
		}

//		canHack = true;


	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Sam"){// && canHack) {
			hack.SetActive(true);
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (typedHack && other.tag == "Sam") {
			hack.SetActive(false);
			StartCoroutine(Fall());
		}
	}

	IEnumerator SamPacing () {
		yield return new WaitForSeconds(3.0f);
		while (pacing) {
			sam.left = false;
			if (!typedStop) sam.right = true;
			yield return new WaitForSeconds(3.0f);
			sam.right = false;
			if (!typedStop) sam.left = true;
			yield return new WaitForSeconds(3.0f);
		}

//		sam.stop = true;
	}

	IEnumerator Fall() {
		yield return new WaitForSeconds(fallSeconds);
		cam1.enabled = true;
		cam2.enabled = false;
		if (jumpRight) jumpRight.SetActive(true);
		canJump = true;
	}
}