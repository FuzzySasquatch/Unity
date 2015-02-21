using UnityEngine;
using System.Collections;
using Jolly;

public class Sam : MonoBehaviour
{
	public int sideSpeed;
	public int JumpForce;
	public GameObject GroundDetector;
	public Camera RenderingCamera;
	public BigArmsController BigBro;
	public TextMesh Text;
	public Cursor cursor;
//	public GameObject objectToDisable;
	public bool exit = false;
	public Console console;
	public ConsoleIntro consoleIntro;

	public GameObject bubble;
	public Sprite normal;
	public Sprite taunt1;
	public Sprite taunt2;
	public Sprite taunt3;
	public Sprite taunt4;
	public Sprite taunt5;

	private string command;
	public bool nearConsole = false;
//	public float hackSeconds = 7f;

	public bool moving = false;
	public bool jump;
	public bool left;
	public bool right;
	public bool stop;
	public bool typedStop;
	public bool typedTaunt;
	private int tauntCounter = 4;
	public bool hack;

	public AudioClip jumpSound;

	public CheckPointControl checkPointCtrl;

	void Start ()
	{
		left = false;
		right = false;
		command = "";
	}
	
	void Update ()
	{
		//check if grounded for jump handling
		bool grounded = Physics2D.Linecast(this.transform.position, this.GroundDetector.transform.position, 1 << LayerMask.NameToLayer ("Ground"));

//		print (grounded);
		//make sure grounded on feet


		// taunt randomization
		tauntCounter = ++tauntCounter % 5;

		// get input
		foreach (char c in Input.inputString) {
			// backspace
			if (c == "\b"[0]){
				if (command.Length != 0)
					command = command.Substring(0, command.Length - 1);
			}
			// return or enter a command
			else if (c == "\n"[0] || c == "\r"[0]){
				this.Command(command);
				command = "";
			}
			// update string
			else if (command.Length < 10) {
				cursor.renderer.enabled = true;
				bubble.GetComponent<SpriteRenderer>().sprite = normal;
				command += c;
			}
		}

		// update cursor position
		// need more info on this for fixing space
		Bounds bounds = Text.renderer.bounds;
		cursor.length = bounds.extents.x * 2;
		Text.text = command;
		if (jump && !grounded) 
			jump = false;
	}

	// movement handling
	void FixedUpdate ()
	{
//		Debug.Log(stop);
		if (jump)
		{
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
//			SoundEffectsHelper.Instance.MakeJumpSound();		// replace
			this.rigidbody2D.AddForce(Vector2.up * JumpForce);
			this.jump = false;
		}

		Vector2 velocity = this.rigidbody2D.velocity;
		if (stop)
		{
			velocity.x = 0;
			stop = false;
			right = false;
			left = false;
		}
		else if (right) 
		{
			//print ("right");
			velocity.x = sideSpeed;
		}
		else if (left)
		{
			//print ("left");
			velocity.x = -1 * sideSpeed;
		}

		this.rigidbody2D.velocity = velocity;

	}


	//flip if side frames are created
//	void Flip ()
//	{
//		this.FacingRight = !this.FacingRigh
//		this.transform.localScale = this.transform.localScale.SetX(this.FacingRight ? 1.0f : -1.0f);
//	}


	void taunt(){
		cursor.renderer.enabled=false;

		if (tauntCounter == 0)
			bubble.GetComponent<SpriteRenderer> ().sprite = taunt1;
		else if (tauntCounter == 1)
			bubble.GetComponent<SpriteRenderer> ().sprite = taunt2;
		else if (tauntCounter == 2)
			bubble.GetComponent<SpriteRenderer> ().sprite = taunt3;
		else if (tauntCounter == 3)
			bubble.GetComponent<SpriteRenderer> ().sprite = taunt4;
		else if (tauntCounter == 4)
			bubble.GetComponent<SpriteRenderer> ().sprite = taunt5;


	}

	public void Command(string text)
	{
		text = text.ToLower();
		if (text == "right") 
		{
//				moving = true;
				right = true;
				left = false;
		} 
		else if (text == "left") 
		{
//				moving = true;
				left = true;
				right = false;
		} 
		else if (text == "jump") 
		{
//				moving = true;
				jump = true;
		} 
		else if (text == "jump right") 
		{
//				moving = true;
				jump = true;
				right = true;
				left = false;
		} 
		else if (text == "jump left") 
		{
//				moving = true;
				jump = true;
				left = true;
				right = false;
		} 
		else if (text == "stop") 
		{
//				moving = false;
				right = false;
				left = false;
			stop = true;
			typedStop = true;
		} 
		else if (text == "taunt") 
		{
				typedTaunt = true;
				taunt();
				BigBro.rager();
		} 
		else if (text == "reset" || text == "restart") 
		{
			checkPointCtrl.Reset();
			stop = true;
			// if checkpoint go to that otherwise do this:
		} 
		else if (text == "quit" || text == "quit") 
		{
				Application.Quit();
		} 
//		Debug.Log(nearConsole);
//		print(console);
		if (text == "hack" && nearConsole && console != null) 
		{
			print ("hack");
			print (nearConsole);

//			if (nearConsole) {
//			SoundEffectsHelper.Instance.MakeHackSound(); // change this
			stop = true;
			StartCoroutine(console.Hack());
//			}
		}
		else if (text == "hack" && nearConsole && consoleIntro != null)
		{
			stop = true;
			hack = true;
			StartCoroutine(consoleIntro.Hack());
		}
		else if (text == "ignore") 
		{
			gameObject.GetComponent<ToggleIgnoreColl>().ignore = true;
			gameObject.GetComponent<ToggleIgnoreColl>().ignores += 1;
		} 
		else if (text == "exit") 
		{
			exit = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
//		print ("Trigger Enter");
		if (collider.gameObject.tag == "Terminal") {
			console = collider.gameObject.GetComponent<Console>();
//			print("NEAR CONSOLE");
			nearConsole = true;
		}
		else if (collider.gameObject.tag == "Terminal Intro") {
			consoleIntro = collider.gameObject.GetComponent<ConsoleIntro>();
			//			print("NEAR CONSOLE");
			nearConsole = true;
		}
	}

//	IEnumerator Hack() {
//	
//		objectToDisable.SetActive(false);
//		SoundEffectsHelper.Instance.MakeLaserSound(); // change this
//		yield return new WaitForSeconds(hackSeconds);
//		objectToDisable.SetActive(true);
//
//	}
	

}	