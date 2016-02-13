using UnityEngine;
using System.Collections;

public class aaa : MonoBehaviour {
	
	public float movementSpeed;
	private Animator anim;
	private int currentGoal = 1;
	public GameObject bigBang,holyBlast,lightening;
	private bool explode = false;
	private float explodeTime = 0f;
	private bool touch1,touch2,touch3,touch4 = false;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("save","Level4");
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = CFInput.GetAxis ("Horizontal")*movementSpeed;
		float y = CFInput.GetAxis ("Vertical")*movementSpeed;
		//var moveDirection = new Vector3 (x,0f,y); 
		var rotateDirection = new Vector3 (0f,x*20*Time.deltaTime,0f); 
		var translateDirection = new Vector3 (0f,0f,y*2*Time.deltaTime);
		this.transform.Rotate (rotateDirection);
		this.transform.Translate (translateDirection);
		
		if (x >= 0.2f) {
			anim.SetBool ("run", true);
		} else {
			anim.SetBool ("run", false);
		}
		if (x <= -0.2f) {
			anim.SetBool ("runBack", true);
		} else {
			anim.SetBool ("runBack", false);
		}
		//		Debug.Log (y);
		//this.transform.Translate (translateDirection);
		//transform.Rotate (rotateDirection,Space.Self);
		if  (CFInput.GetKey(KeyCode.Space)) {
			anim.SetBool ("jump", true);
		} else {
			anim.SetBool ("jump", false);
		}
		if (CFInput.GetKey (KeyCode.A)) {
			anim.SetBool ("jump", true);
		} else {
			anim.SetBool ("jump", false);
		}
		if(currentGoal == 5){
			Instantiate(lightening,new Vector3(-2.29f,0.79f,1.75f),transform.rotation);
			Debug.Log("You win");
		}
		if(explode){
			explodeTime +=Time.deltaTime;
		}
		if (explodeTime > 2f)
			Application.LoadLevel ("Menu");
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "pumpkin1" && touch1 == false) {
			if(currentGoal == 1){
				//Debug.Log("okokok");
				currentGoal++;
				touch1 = true;
				Instantiate(holyBlast,transform.position,transform.rotation);
			}
			else {
				//Debug.Log("boom");
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				explode = true;
			}
			
			
		}
		if (other.tag == "pumpkin2" && touch2 == false) {
			if(currentGoal == 2){
				//Debug.Log("okokok");
				currentGoal++;
				touch2 = true;
				Instantiate(holyBlast,transform.position,transform.rotation);
			}
			else {
				//Debug.Log("boom");
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				explode = true;
			}
		}
		if (other.tag == "pumpkin3"  && touch3 == false) {
			if(currentGoal == 3){
				//Debug.Log("okokok");
				currentGoal++;
				touch3 = true;
				Instantiate(holyBlast,transform.position,transform.rotation);
			}
			else {
				//Debug.Log("boom");
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				Instantiate(bigBang,transform.position,transform.rotation);
				explode = true;
			}
		}
		if (other.tag == "pumpkin4" && touch4 == false) {
			if (currentGoal == 4) {
				//	Debug.Log ("okokok");
				currentGoal++;
				touch4 = true;
				Instantiate(holyBlast,transform.position,transform.rotation);
			} else {
				//Debug.Log ("boom");
				Instantiate (bigBang, transform.position, transform.rotation);
				Instantiate (bigBang, transform.position, transform.rotation);
				Instantiate (bigBang, transform.position, transform.rotation);
				explode = true;
			}
		}
	}
}
