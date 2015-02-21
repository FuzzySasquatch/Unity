using UnityEngine;
using System.Collections;

public class Slinky : MonoBehaviour
{

	public GameObject[] GroundDetectors;
	public Camera RenderingCamera;
	public Slinky friend;
	public BigController big;
	
	private GameObject grabbed;
	private Vector2 start;
	
	private float speed = 6f;
	private bool grounded;
	
	public bool left;
	public bool pickup;

	public AudioClip clinkSound;

	float time = 0;
	public float fallTime = 0.5f;
	bool falling;
	public float fallSpeed = -10f;

	void Start ()
	{
		grabbed = null;
		grounded = false;
		pickup = false;
	}

	void Update() {
		/* When the middle mouse button is pressed slink drops for fallTime seconds */
		time += Time.deltaTime;

		float downScroll = Input.GetAxis("Mouse ScrollWheel");
		print (downScroll);

		if (downScroll < 0) {//!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && Input.GetMouseButtonDown(2)) {
			falling = true;
			this.rigidbody2D.velocity = new Vector2(0, fallSpeed);
			grounded = false;
			time = 0;
		}
	
		if (time > fallTime) {
			falling = false;
		}
	}

	void FixedUpdate ()
	{
		bool wasGrounded = grounded;

		grounded = false;

		if (!falling) {
			// check for grounded
			foreach (GameObject gd in GroundDetectors){
				if (Physics2D.Linecast(this.transform.position, gd.transform.position, 1 << LayerMask.NameToLayer ("Ground")))
					grounded = true;
			}
		}

		if (grounded && !wasGrounded) {
			AudioSource.PlayClipAtPoint(clinkSound, transform.position);
//			SoundEffectsHelper.Instance.MakeSlinkSound(); // change this
		}

//		print("Grounded = " + grounded);
		// sets the movement state of each slink side
		if (grounded && grabbed != this.gameObject)
				this.rigidbody2D.isKinematic = true;
		else
				this.rigidbody2D.isKinematic = false;

		// picks up one side of slinky
		if ((Input.GetMouseButtonDown(0) && left) || (Input.GetMouseButtonDown(1) && !left))
		{
//			print(Input.GetMouseButtonDown(0));
			this.CastTouchRay (Input.mousePosition, TouchPhase.Began);
		}
		// puts downs the same side of slinky
		if ((Input.GetMouseButtonUp(0) && left) || (Input.GetMouseButtonUp(1) && !left))
		{
			this.CastTouchRay (Input.mousePosition, TouchPhase.Ended);
		}
		// moves slinky
		if ((Input.GetMouseButton(0) && left) || (Input.GetMouseButton(1) && !left))
		{
			this.CastTouchRay (Input.mousePosition, TouchPhase.Moved);
		}
		// if the other side of the slink is held, freeze this side
		if (grabbed == friend.gameObject)
		{
			this.rigidbody2D.velocity = new Vector2();
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}


//		print("Grabbed obj = " + grabbed);
//		print("Mid click down = " + Input.GetMouseButtonDown(2));
//		print("Pickup = " + pickup);

		// picks up big
		// the layermask is the layer big is on
		if (grabbed == this.gameObject && Input.GetMouseButtonDown(2) && !pickup) {
			if (Physics2D.Linecast(this.transform.position, GroundDetectors[0].transform.position, 1 << LayerMask.NameToLayer("Biggie"))){
				print ("Bind");
				big.setDestination(this.gameObject);
				pickup = true;
			}
		}

		// sets down big
		if (Input.GetMouseButtonUp(2) && pickup){
			print ("unbind");
			big.setDestination(null);
			pickup = false;	
		}
	}
	
	void CastTouchRay (Vector2 position, TouchPhase phase)
	{
		// transforms screen space to world space
		Vector2 worldPoint = RenderingCamera.ScreenToWorldPoint(position);
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(worldPoint.x, worldPoint.y), Vector2.zero, 0);
		bool didHit = null != hit.collider;
		if (didHit)
		{
			GameObject recipient = hit.transform.gameObject;
			if(recipient == this.gameObject){		
				if(phase == TouchPhase.Began && friend.grounded){
					friend.rigidbody2D.isKinematic = true;
					grabbed = this.gameObject;
					this.rigidbody2D.gravityScale = 0;
				}
			}
			
		}		

		if(grabbed == this.gameObject){
			if(phase == TouchPhase.Moved || phase == TouchPhase.Stationary)
			{
				Vector2 difference = (worldPoint - this.rigidbody2D.position);

				if(friend.grounded)
					this.rigidbody2D.velocity = (difference * speed);
				else
				{
					grabbed = null;
					this.rigidbody2D.gravityScale = 2;
					this.rigidbody2D.velocity = new Vector2();
				}
			}

			if(phase == TouchPhase.Ended)
			{
				friend.rigidbody2D.isKinematic = false;
				grabbed = null;
				this.rigidbody2D.gravityScale = 2;
			}
		}
	}
}
