using UnityEngine;
using System.Collections;

public class HackWall : MonoBehaviour {

	public GameObject terminal;

	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.name == "Throwable Terminal")
		{
			terminal.SetActive(true);
//			Instantiate(terminal, other.gameObject.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		}	
	}
}
