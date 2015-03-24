using UnityEngine;
using System.Collections;

public class SlinkTutorial : MonoBehaviour {

	public Slinky[] slinkSides;
	private Slinky curSlink;

	private bool updateOK = false;
	public bool UpdateOK
	{
		set
		{
			updateOK = value;
		}
	}
	private bool lapComplete = false;
	public bool LapComplete
	{
		get
		{
			return lapComplete;
		}
		set
		{
			lapComplete = value;
		}
	}

	private int conditonIndex = 0;
	public int ConditionIndex
	{
		get 
		{
			return conditonIndex;
		}
	}

	public GameObject[] instructions;
	public GameObject[] targets;
	private GameObject curInstruction;
	private GameObject curTarget; 

	private bool heldDown;
	private bool waitForScroll = false;


	void checkDownScroll() {
		float downScroll = Input.GetAxis("Mouse ScrollWheel");
		if (downScroll < 0) {
			waitForScroll = false;
			curInstruction.SetActive(false);
			curInstruction = null;
			lapComplete = true;
//			Destroy(this);

		}
	}

	void displayInstructions() {
		heldDown = curSlink.Held;	// is the current instruction being executed?
		if (heldDown) {
			curInstruction.SetActive(false);
			curTarget.SetActive(true);
		} else {
			curInstruction.SetActive(true);
			curTarget.SetActive(false);
		}
	}

	void checkIndex() {
		print (conditonIndex);
		updateOK = false;
		conditonIndex++;

		switch (conditonIndex) {
		case 1:
			// instruction, target, slink
			updateInstructions(1, 1, 1);
			print("first done");
			break;
		case 2:
			updateInstructions(0, 2, 0);
			print("second done");
			break;
		case 3:
			updateInstructions(1, 3, 1);
			print("third done");
			break;
		case 4:
			updateInstructions(0, 4, 0);
			print("fourth done");
			break;
		case 5:
			curInstruction = instructions[2];
			curInstruction.SetActive(true);
			curTarget.SetActive(false);
			curTarget = null;
			waitForScroll = true;
			break;
		default:
			break;
		}
	}

	void updateInstructions(int instruction, int target, int slink) {
		curInstruction = instructions[instruction];
		curTarget = targets[target];
		curSlink = slinkSides[slink];
	}

	// Set up first instruction and target
	void Start () { 
		updateInstructions(0, 0, 0);
	}

	void Update () {
		// If a target has been hit update the index and instructions/target
		if (updateOK) {
			heldDown = false;
			checkIndex();
		}
		// If there is a target and instruction display them
		if (curInstruction && curTarget)
			displayInstructions();
		// Wait until the scroll wheel is used
		if (waitForScroll)
			checkDownScroll();
	}
}
