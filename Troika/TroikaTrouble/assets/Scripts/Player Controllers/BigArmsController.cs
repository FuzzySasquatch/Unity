using UnityEngine;
using System.Collections;

public class BigArmsController : MonoBehaviour {
	
	public float force = 364f;			// force of Big's throw
	public GameObject regHead;			// sprite while not raging
	public GameObject rageHead;			// sprite for raging
	public float rageDuration = 4f;
	public bool raging = false;			// determines if Big is mad
	public bool taunted = false;
	private bool grab = false;			// determines if Big is holding something
	public float wait = 0.02f;			// how often Big fails his arms during rage mode


	private Vector2 centerHands;		// position between the center of big's hands

	public AudioClip throwSound;
	public AudioClip terminalSound;

	public bool terminalGrab = false;
	private bool terminalGrabbed = false;

	void Start()
	{
		Physics2D.IgnoreCollision(transform.parent.transform.collider2D, this.transform.collider2D);
	}

	void Update() 
	{
		// determines if big is holding something
		grab = Input.GetButton("Grab");
		// while raging grab appears to be held down
		if (raging) 
			grab = true;
		// must hold grab to initiate rotating of arms
		if (grab) 
		{
			this.collider2D.enabled = true;
			// gets inputs for right joystick
			float x = Input.GetAxis("Rotate Horz");
			float y = -1 * Input.GetAxis("Rotate Vert");
			
//			Debug.Log("x = " + x + ", y = " + y);

			// gets rid of useless values
			if (Mathf.Abs(x) > 0.35 || Mathf.Abs(y) > 0.35){
				float angle = Mathf.Atan(y/x) * Mathf.Rad2Deg;
				// accounts for strange offset in unity
				if (x > 0)
					angle += 180;
				// sets rotating vector arm position
				// must account for an offset
				this.transform.localEulerAngles = new Vector3(0,0,angle - 90);
			}
		} 
		else 
		{
			this.collider2D.enabled = false;
			// fetches inputs for throwing
			float x = Input.GetAxis("Rotate Horz");
			float y = -1 * Input.GetAxis("Rotate Vert");
			// throws objects
			foreach (Transform child in transform)
			{

				if (child.tag == "Sam" || child.tag == "Terminal") { // disable unparents object, reapplies gravity, and applies a force
					child.gameObject.rigidbody2D.isKinematic = false;
					child.parent = null;
					child.gameObject.rigidbody2D.AddForce((new Vector2(x, y)) * force);
					child.gameObject.transform.rotation = Quaternion.identity;
					AudioSource.PlayClipAtPoint(throwSound, transform.position);
//					SoundEffectsHelper.Instance.MakeGruntSound(); // may change this...
				}
				
			}
			// snap arms back to sides
			transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}


	// accounts for grabbing
	void OnCollisionEnter2D(Collision2D other)
	{
//		Debug.Log("collision");

		// grabs valid objects
		if (Input.GetButton("Grab") && other.gameObject.tag == "Sam" || other.gameObject.tag == "Terminal")
		{
			// obtains center hands position
			foreach (Transform child in transform)
			{
				if (child.name == "Center Hands")
					centerHands = child.position;
			}
			//			Debug.Log(centerHands);
			if (other.gameObject.tag == "Sam")
				other.gameObject.GetComponent<Sam>().stop = true;
			other.gameObject.transform.position = centerHands;
			other.gameObject.transform.parent = this.transform;
			other.gameObject.rigidbody2D.isKinematic = true;

			if (other.gameObject.tag == "Terminal" && !terminalGrabbed) 
			{
				terminalGrab = true;
				AudioSource.PlayClipAtPoint(terminalSound, transform.position);
				terminalGrabbed = true;
			}
		}
	}

	// method called by Sam after a taunt to start rage mode
	public void rager(){
		StartCoroutine (Rage());
	}
	
	IEnumerator Rage()
	{
		// changes Big's head and state to rage
		raging = true;
		taunted = true;
		rageHead.renderer.enabled = true;
		regHead.renderer.enabled = false;
		// Big begins failing arms
		StartCoroutine(CrazyArms());
		yield return new WaitForSeconds(rageDuration);
		// disables raging and renables regular head
		raging = false;
		rageHead.renderer.enabled = false;
		regHead.renderer.enabled = true;
		transform.localEulerAngles = new Vector3(0f, 0f, 0f);
	}

	// fails Big's arms every wait seconds
	IEnumerator CrazyArms()
	{
		while (raging) {
			this.transform.localEulerAngles = new Vector3(0, 0 ,Random.Range(0, 360));
			yield return new WaitForSeconds(wait);
		}
	}
	
}
