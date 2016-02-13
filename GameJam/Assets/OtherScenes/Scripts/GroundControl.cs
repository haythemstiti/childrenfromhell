using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

	//Material texture offset rate
	float speed = 0.5f;
	public bool stopMoving = false;
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	//Offset the material texture at a constant rate
	void Update () {
		float offset = Time.time * speed;  
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);

		if (stopMoving) {
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 0);
		}

	}
}
