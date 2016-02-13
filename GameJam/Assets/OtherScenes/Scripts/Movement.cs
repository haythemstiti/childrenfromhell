using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//public GameControlScript control;
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;


	//private Animator anim;
	//start 
	void Start () {
		PlayerPrefs.SetString ("save","Level1");
		controller = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update (){
		//anim.SetFloat ("Speed",0.6f);
		if (controller.isGrounded) {

		
			//animation.Play("run");            //play "run" animation if spacebar is not pressed
			moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			//Gyroscope
			//moveDirection = new Vector3(-Input.acceleration.x,0,0);

			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			//moveDirection = transform.Translate(Input.acceleration.x,0,-Input.acceleration.z);
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 
					
			
			/*if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
				animation.Stop("run");
				animation.Play("jump_pose");
				moveDirection.y = jumpSpeed;         //add the jump height to the character
			}*/
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		}
		
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}


}