using UnityEngine;
using System.Collections;

public class CheckPointControl : MonoBehaviour {

	private Vector3[] checkPointPositions;
	public Transform[] characters;

	public int currentCheckPoint = -1;

	public void UpdateCheckPoint(int data, Vector3[] positions)
	{
		currentCheckPoint = data;
//		print (positions);
		checkPointPositions = positions;
	}

	public void Reset()
	{

		if (currentCheckPoint > -1) 
		{
			for (int i = 0; i < characters.Length; i++)
			{
				characters[i].position = checkPointPositions[i];
			}
			// add fade
		}
		else 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}



}
