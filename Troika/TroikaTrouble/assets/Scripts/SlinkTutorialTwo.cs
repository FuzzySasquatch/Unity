using UnityEngine;
using System.Collections;

public class SlinkTutorialTwo : MonoBehaviour {

	public Slinky curSlink;

	public GameObject[] instructions;
	public GameObject[] targets;
	private GameObject curInstruction;
	private GameObject curTarget; 

	public OnTargetStay target;
	
	private bool heldDown = false;
	private bool pickedUp = false;
	private bool started = false;

	private bool firstDeleted = false;

	void displayInstructions(bool pressed) {
		// is the current instruction being executed?
		if (pressed) {
			curInstruction.SetActive(false);
			curTarget.SetActive(true);
		} else {
			curInstruction.SetActive(true);
			curTarget.SetActive(false);
		}
	}

	void updateInstructions(int instruction, int target) {
		curInstruction = instructions[instruction];
		curTarget = targets[target];
	}

	void Update () {
		if (started) {
			// Get inputs
			heldDown = curSlink.Held;
			pickedUp = curSlink.MiddleHeld;

			targets[0].GetComponent<SpriteRenderer>().enabled = false;

			bool inside = target.IsInside;

			instructions[0].SetActive(false);	// lmb
			instructions[1].SetActive(false);	// mmb

//			targets[0].SetActive(false);	// target 6
			targets[1].SetActive(false); // target 7


			if (!heldDown) {
				// display lmb
				print ("display lmb");
				instructions[0].SetActive(true);
				// everything else is inactive
			}
			else if (pickedUp) {
				print ("display target 7");
				// display target 7

				targets[1].SetActive(true); // target 7
			}
			else if (heldDown && !inside) {
				print ("display target 6");
				// display target 6
				targets[0].GetComponent<SpriteRenderer>().enabled = true;
				targets[0].SetActive(true);	// target 6
			}
			else if (heldDown && inside) {
				print ("display mmb");
				// display mmb
				instructions[1].SetActive(true);	// mmb
			}

		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Biggie" && !firstDeleted) {
			// Start tutorial
			print ("Start tutorial");
			started = true;
			updateInstructions(0, 0);
			Destroy(this.GetComponent<Collider2D>());
			firstDeleted = true;


		}
		if (other.tag == "Slink" && targets[1].activeInHierarchy) {
			print ("hit 7");
			for (int i = 0; i < 2; i++) {
				Destroy (targets[i]);
				Destroy(instructions[i]);
			}
			Destroy(this);
		}
	}
}
