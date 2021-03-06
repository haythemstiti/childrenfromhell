﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	public float movementSpeed;
	private Animator anim;
	private bool isJumping=false;
	private float timeJumping = 0f;
	public Text textTvGlag;
	public GameObject tvOff;
	public GameObject CubeTv;
	public GameObject CubeTransformation;
	public GameObject note;
	public GameObject skeleton;
	public GameObject player;
	private bool transformation;
	public Image image;
	private Image img;
	public AudioClip audioTv;
	private AudioSource sourceTv;

	private bool action;
	private bool actionTransformation;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		action = false;
		transformation = false;
		img = image.GetComponent<Image> ();
		sourceTv = GetComponent<AudioSource> ();

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
		if(CFInput.GetKey(KeyCode.A) && action == true){
			Debug.Log("destroy");
			Destroy(tvOff);
			Destroy(CubeTv);
			textTvGlag.text = "";
			Instantiate(note,new Vector3(-8.124f,3.788f,-2.022f),transform.rotation);
			Instantiate(note,new Vector3(-8.01f,3.788f,-4.89f),transform.rotation);
			Instantiate(note,new Vector3(-7.88f,4.44f,-3.73f),transform.rotation);
			action = false;
			transformation = true;
			img.fillAmount = 0.5f;
			sourceTv.Play();
			
		}
		if(CFInput.GetKey(KeyCode.A) && actionTransformation == true && transformation==true){
			Debug.Log("destroy");
			Destroy(CubeTransformation);
			textTvGlag.text = "";
			actionTransformation = false;
			Instantiate(skeleton,new Vector3(-10.64806f,0.02599978f,-17.27503f), transform.rotation);
			Destroy(player);
			Destroy(CubeTransformation);
			transformation = false;

			
		}

	}
	void OnTriggerEnter(Collider other) {
		if (other.name == "TvGlag") {
			Debug.Log("Enter");
			textTvGlag.text = "Turn on the Tv to anger your brother?";
			action = true;
		}
		if (other.name == "CubeTransformation" && transformation == true) {
			Debug.Log("Enter");
			textTvGlag.text = "Want to dress up to scary your brother?";
			actionTransformation = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.name == "TvGlag"){
			Debug.Log("Exit");
			textTvGlag.text = "";
			action = false;
		}
		if(other.name == "CubeTransformation"){
			Debug.Log("Exit");
			textTvGlag.text = "";
			actionTransformation = false;
		}
}
 
}