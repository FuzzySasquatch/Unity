using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	

	// add functionality to check for checkpoint and to move all characters to proper checkpoints

	void Start()
	{

	}

	/*void Update()
	{
		print ("Current lvl = " + currentLevel);
	}

	public void NextLevel()
	{
		print ("next level");
		Application.LoadLevel((currentLevel + 1) % 2);
	}

	public void CheckPoint()
	{
		print ("checkpoint");
		checkPoint = true;
	}

	public void Reset()
	{
		print ("reset");
		print ("Current lvl = " + currentLevel);

		if (checkPoint) {
			currentLevel = Application.loadedLevel + 1;
			print ("Current lvl = " + currentLevel);
		}

		Application.LoadLevel(currentLevel);
	}*/
}
