using UnityEngine;
using System.Collections;

public class move_road : MonoBehaviour {
	float speed = .5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * speed;                             
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset); 
	}
}
