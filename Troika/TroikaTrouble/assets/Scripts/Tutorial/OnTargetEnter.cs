using UnityEngine;
using System.Collections;

public class OnTargetEnter : MonoBehaviour {

	public SlinkTutorial slink;
	private bool isGreen = false;
	private int correctSide = 0;

	void OnTriggerEnter2D(Collider2D other) {
		print("Enter");
		if (other.tag == "Slink") {
			isGreen = other.gameObject.GetComponent<Slinky>().left;
			correctSide = slink.ConditionIndex % 2;
			bool shouldUpdate = (isGreen && correctSide == 0) || (!isGreen && correctSide == 1);
			if (shouldUpdate) {
				slink.UpdateOK = true;
	//			Destroy(this.gameObject);
				this.gameObject.SetActive(false);
			}
		}
	}
}
