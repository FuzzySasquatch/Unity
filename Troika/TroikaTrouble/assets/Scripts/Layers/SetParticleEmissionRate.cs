using UnityEngine;
using System.Collections;

public class SetParticleEmissionRate : MonoBehaviour {

	public GameObject sam;
	private bool moving;

	void FixedUpdate()
	{

		print(sam.rigidbody2D.velocity);
		moving = sam.GetComponent<Sam>().moving;
		if (moving)
			particleSystem.emissionRate = 40f;
		else
			particleSystem.emissionRate = 12f;
	}
}
