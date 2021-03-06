﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControlTinyWarrior : MonoBehaviour {
	public float movementSpeed;
	private Animator anim;
	private bool isJumping=false;
	private float timeJumping = 0f;
	private bool actionTransformation;
	public bool skatePlaced = false;
	//public Text textScream;
	//private string textScream;
	private bool action = false;
	public GameObject cubeScream;
	public Text textInstruct;
	private bool hoverBoardPicked = false;
	public GameObject hoverBoard, hoverBoard2;
	public GameObject Battery;

	private bool batteriesToken = false;
	public bool putHoverBoard = false;

	private GameObject BatteryA1;
	private GameObject BatteryA2;
	private GameObject BatteryA3;
	private GameObject BatteryA4;
	private GameObject BatteryA5;
	private GameObject BatteryA6;
	private GameObject BatteryA7;
	private Vector3 v = new Vector3();
	private bool init = true;
	private AudioSource sourceBattery;
	public GameObject bigHead;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		sourceBattery = GetComponent<AudioSource> ();
		//		textScream = GameObject.FindGameObjectsWithTag ("Text");

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
			putHoverBoard = true;
		}
		if(BatteryA1!= null) 
		if (Vector3.Distance(BatteryA1.transform.position,transform.position)<=1f) {
			sourceBattery.Play();
			Destroy(BatteryA1);
			init = false;
		}
		if(BatteryA2!= null) 
		if (Vector3.Distance(BatteryA2.transform.position,transform.position)<=1f) {
			Destroy(BatteryA2);
			sourceBattery.Play();
			init = false;
		}
		if(BatteryA3!= null) 
		if (Vector3.Distance(BatteryA3.transform.position,transform.position)<=1f) {
			Destroy(BatteryA3);
			init = false;
		}
		if(BatteryA4!= null) 
		if (Vector3.Distance(BatteryA4.transform.position,transform.position)<=1f) {
			Destroy(BatteryA4);
			sourceBattery.Play();
		}
		if(BatteryA5!= null) 
		if (Vector3.Distance(BatteryA5.transform.position,transform.position)<=1f) {
			Destroy(BatteryA5);
			sourceBattery.Play();
			init = false;
		}
		if(BatteryA6!= null) 
		if (Vector3.Distance(BatteryA6.transform.position,transform.position)<=1f) {
			Destroy(BatteryA6);
			sourceBattery.Play();
			init = false;
		}
		if(BatteryA7!= null) 
		if (Vector3.Distance(BatteryA7.transform.position,transform.position)<=1f) {
			Destroy(BatteryA7);
			sourceBattery.Play();
			init = false;
		}
		if (BatteryA1 == null && BatteryA2 == null && BatteryA3 == null && BatteryA4 == null && BatteryA5 == null && BatteryA6 == null && BatteryA7 == null && init == false) {
			batteriesToken = true;		
		}
		if(batteriesToken){

		}
		if (gameObject != null && putHoverBoard == true && !skatePlaced) {
			v = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			v.y = transform.position.y + 1;
			v.z = -4.04f;
			Instantiate(hoverBoard2,v,Quaternion.identity);
			putHoverBoard = false;
			Debug.Log("CBON2");
			skatePlaced = true;

		}
	} 
	void OnTriggerEnter(Collider other) {
		if (other.name == "CubeTinyWarrior") {
			Debug.Log("Enter");
			textInstruct.text = "Find a way to piss off you brother";

		}
		if (other.name == "CubeTinyWarrior" && hoverBoardPicked == true) {
			Debug.Log("Enter");
			//textInstruct.text = "Your hover board is out of energy";

			BatteryA1 =(GameObject) Instantiate(Battery,new Vector3(-18.92215f,0.251f,-0.5312214f),transform.rotation);
			BatteryA2 =(GameObject)Instantiate(Battery,new Vector3(-18.92f,0.251f,-9.46f),transform.rotation);
			BatteryA3 =(GameObject)Instantiate(Battery,new Vector3(-14.58f,0.251f,16.75f),transform.rotation);
			BatteryA4 =(GameObject)Instantiate(Battery,new Vector3(12.77f,0.251f,-20.44f),transform.rotation);
			BatteryA5 =(GameObject)Instantiate(Battery,new Vector3(21.19f,0.251f,16.33f),transform.rotation);
			BatteryA6 =(GameObject)Instantiate(Battery,new Vector3(-8.86f,0.251f,-19.27f),transform.rotation);
			BatteryA7 =(GameObject)Instantiate(Battery,new Vector3(20.32f,0.251f,-0.67f),transform.rotation);
			hoverBoardPicked = false;
		}
		if (other.name == "Hoverboard") {
			Debug.Log("Enter");
			hoverBoardPicked = true;
			Destroy(hoverBoard);
		}
		if (other.name == "CubeTrap" && batteriesToken) {
			Debug.Log("t");
			textInstruct.text = "Put the hover board?";
			action = true;
		}
		
	}
	void OnTriggerExit(Collider other) {
		if(other.name == "CubeTinyWarrior"){
			Debug.Log("Exit");
			textInstruct.text = "";
			action = false;
		}
		if(other.name == "CubeTrap" && batteriesToken){
			textInstruct.text = "";
			action = false;
		}
	}
}