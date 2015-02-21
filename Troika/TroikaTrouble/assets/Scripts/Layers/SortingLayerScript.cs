using UnityEngine;
using System.Collections;

public class SortingLayerScript : MonoBehaviour {
		
	public string SortingLayerName = "Sam";
	public int SortingOrder = 0;
	
	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
	}

}
