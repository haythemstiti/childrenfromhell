using UnityEngine;
using System.Collections;

public class positionning : MonoBehaviour {

	public Vector3 screenPosition = new Vector3(0,0,-1.5f);
	// Use this for initialization
	void Start () {
		if(gameObject != null)
		{
			gameObject.transform.position = GetComponent<Camera>().ScreenToWorldPoint(screenPosition);
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
