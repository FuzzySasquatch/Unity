using UnityEngine;
using System.Collections;

public class SetParticleEmissionRate : MonoBehaviour {

	public GameObject sam;
	private bool moving;

	void FixedUpdate()
	{

		print(sam.GetComponent<Rigidbody2D>().velocity);
		moving = sam.GetComponent<Sam>().moving;
		if (moving)
			GetComponent<ParticleSystem>().emissionRate = 40f;
		else
			GetComponent<ParticleSystem>().emissionRate = 12f;
	}
}
