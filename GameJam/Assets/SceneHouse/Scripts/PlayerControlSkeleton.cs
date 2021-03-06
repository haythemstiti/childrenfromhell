﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControlSkeleton : MonoBehaviour {
	public float movementSpeed;
	private Animator anim;
	private bool isJumping=false;
	private float timeJumping = 0f;
	private bool actionTransformation;
	//public Text textScream;
	//private string textScream;
	private bool action;
	public GameObject cubeScream;
	private GameObject image;
	private Image img;
	private AudioSource sourceScream;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
//		textScream = GameObject.FindGameObjectsWithTag ("Text");
		image = GameObject.FindGameObjectWithTag ("image");
		img = image.GetComponent<Image> ();
		sourceScream = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isJumping)
			timeJumping += Time.deltaTime;
		
		float x = CFInput.GetAxis ("Horizontal")*movementSpeed;
		float y = CFInput.GetAxis ("Vertical")*movementSpeed;
		//var moveDirection = new Vector3 (x,0f,y); 
		var rotateDirection = new Vector3 (0f,x*20*Time.deltaTime,0f); 
		var translateDirection = new Vector3 (0f,0f,y*2*Time.deltaTime);
		//if(x>0){
		//	var moveDirection = new Vector3 (0f,0f,y*Time.deltaTime);
		//}
		//		Debug.Log (y);
		this.transform.Rotate (rotateDirection);
		this.transform.Translate (translateDirection);
		if (CFInput.GetAxis ("Vertical") > 0.2f) {
			anim.SetBool ("run", true);		
		} else {
			anim.SetBool ("run", false);
		}
		if (CFInput.GetKey (KeyCode.Space)) {
			Debug.Log("OK");
			if (timeJumping > 0.50f) {
				anim.SetBool ("jump", false);
				isJumping = false;
				timeJumping = 0f;
			}
			else{
				isJumping = true;	
				anim.SetBool ("jump", true);
			}
		} else {
			anim.SetBool ("jump", false);
			isJumping = false;
			timeJumping = 0f;
		}
		if (CFInput.GetAxis ("Vertical") < -0.2f) {
			anim.SetBool ("runBack", true);
		} else {
			anim.SetBool ("runBack", false);
		}
		if (CFInput.GetKey (KeyCode.A) && action == true) {
			Destroy(cubeScream);
		}

	} 
	void OnTriggerEnter(Collider other) {
		if (other.name == "CubeScrem") {
			Debug.Log("Enter");
			//textScream = "Scream to Scary your Brother?";
			action = true;
			img.fillAmount = 1f;
			sourceScream.Play();
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.name == "CubeScrem"){
			Debug.Log("Exit");
			//textScream = "";
			action = false;
		}
	}
}