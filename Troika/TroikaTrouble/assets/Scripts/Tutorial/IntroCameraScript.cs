using UnityEngine;
using System.Collections;

public class IntroCameraScript : MonoBehaviour {

	public Vector3 posA, posB, posC, posD;							// camera positions to be set in inspector
	private Vector3 targetPos;
		
	public float moveTime = 1.0f;								// horizontal movement time
	Vector3 velocity = Vector3.zero;

	private bool zooming = false;
	private float zoomedIn = 2.57f;								// zoomed in
	private float t = 0f;										// zoovement time
	public float zoomTime = 1.7f;								// orignially 0.86f

	public PacingCounter counter;
	public int countLimit;

	public Lap wall1, wall2, wall3, wall4;

	public BigArmsController bigHasBeen;

	private bool changeCam = false;

	public GameObject samTutorial;
	public GameObject learnThrow;

	private bool grabbedEarly = true;

	void Start()
	{
		targetPos = posA;
	}

	void Update ()
	{	
//		print (bigHasBeen.taunted);

		print (wall1.lap + " " + wall2.lap + " " + wall3.lap + " " + wall4.lap);
		bool lapComplete = wall1.lap && wall2.lap && wall3.lap && wall4.lap;

		if (zooming)
			Zoom();		// make this a function that gives different time values
		
		// moves camera horizontally to a target position
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveTime);

		// begins process to change camera scripts (e.g. terminal grabbed by big)
		changeCam = bigHasBeen.terminalGrab;

		// change the camera
		if (changeCam || Input.GetKeyDown(KeyCode.Equals))
		{
			changeCam = true;
			StartCoroutine(ChangeCam());

			learnThrow.SetActive(true);
			if (grabbedEarly) {
				grabbedEarly = false;
				learnThrow.GetComponent<LearnThrow>().TerminalGrabbedEarly();
			} else if (!grabbedEarly) {
				learnThrow.GetComponent<LearnThrow>().TerminalGrabbed();
			}
//			if (counter.count == countLimit)
			if (counter.moveLeft) Destroy(counter.moveLeft);//.SetActive(false);

			samTutorial.SetActive(true);
			LittleTutorial sam = samTutorial.GetComponent<LittleTutorial>();
			sam.first = false;
//			sam.MoveAndHack();

		}

		// move to big
		if ((bigHasBeen.taunted && samTutorial.activeInHierarchy) || Input.GetKeyDown(KeyCode.Comma)) 
		{
			ChangeTarget(posA);
			learnThrow.SetActive(true);
			bigHasBeen.taunted = false;
		}

		// move to little
		if (lapComplete || Input.GetKeyDown(KeyCode.Period)) 
		{
			ChangeTarget(posB);
			wall1.lap = false;
			grabbedEarly = false;
			// enable sam tutorial
			samTutorial.SetActive(true);
			Destroy(counter.moveLeft);//.SetActive(false);
			Destroy(counter.moveRight);//.SetActive(false);
			if (counter.gameObject) Destroy(counter.gameObject);//.SetActive(false);

		}

		// move to slink
		if (counter.count == countLimit || Input.GetKeyDown(KeyCode.Slash)) {
			ChangeTarget(posC);
		}

		// if (hacked moved camera to pos4)
	}

	// zooms out
	IEnumerator ChangeCam()
	{
		if (camera.orthographicSize < 4.84f) 
		{
			camera.orthographicSize += 0.03f;
			targetPos = posD;
		} 
		else 
		{
			this.enabled = false;
//			yield return new WaitForSeconds(.5f);
			yield return null;
			this.GetComponent<CameraFollow2>().enabled = true;
		}
	}

	void ChangeTarget(Vector3 newPos)
	{
		zooming = true;
		targetPos = newPos;
	}

	void Zoom()
	{
		t += Time.deltaTime;
		if (t < zoomTime)							// zoom in
			camera.orthographicSize += 0.03f;
		if (t >= zoomTime) 							// zoom out
			camera.orthographicSize -= 0.03f;
		// has reached orthographicSize 1
		// reset zooming and time, t
		if (t > zoomTime && camera.orthographicSize <= zoomedIn)
		{
			zooming = false;
			t = 0;
		}
	}
}
