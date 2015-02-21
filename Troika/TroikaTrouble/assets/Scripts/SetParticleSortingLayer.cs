using UnityEngine;
using System.Collections;

public class SetParticleSortingLayer : MonoBehaviour
{
	public string sortingLayerName;		// Name of the sorting layer
	public int sortingOrder;			// Order in the layer
	
	void Start ()
	{
		// Set the sorting layer of the particle system
		particleSystem.renderer.sortingLayerName = sortingLayerName;
		
		particleSystem.renderer.sortingOrder = sortingOrder;
	}
}
