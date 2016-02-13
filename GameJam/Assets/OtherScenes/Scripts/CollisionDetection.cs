using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public  class CollisionDetection : MonoBehaviour {


	private GameObject player,ground,attack;
	private HealthBar hb;
	public bool isAlive = false;
	private GroundControl gc;
	private SpawnScript2 sc;
	public GameObject quad1;
	public GameObject quad2;
	public GameObject quad3;
	private int life=3;

	private float maxJauge=100;
	private float jauge=50;



	public GameObject ball;
	private GameObject image;
	private progressBar pb;
	private Animator anim;





	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera");
		ground = GameObject.FindGameObjectWithTag ("ground");
		attack = GameObject.FindGameObjectWithTag ("attack");

		hb = player.GetComponent<HealthBar> ();
		gc = ground.GetComponent<GroundControl> ();
		sc = attack.GetComponent<SpawnScript2> ();

		ball = GameObject.Find("Attack");

		image = GameObject.FindGameObjectWithTag ("image");

		pb = image.GetComponent<progressBar> ();
		anim = GetComponent<Animator> ();




	}
	
	// Update is called once per frame
	void Update () {



		if (hb.life <= 0) {
		Destroy(ball.gameObject);
		}


	}

	void OnCollisionEnter(Collision col){
			if (col.gameObject.tag == "sphere") {
			//Debug.Log("obstacle"+hb.life);
			hb.life= hb.life - 10;
			Destroy(col.gameObject);


			life -- ;
			switch(life){
			case 2:
				Destroy(quad1.gameObject);
				break;
			case 1:
				Destroy(quad2.gameObject);
				break;
			case 0:
				Destroy(quad3.gameObject);				Application.LoadLevel("Menu");
				break;
			
			}



			if(hb.life <= 0){
				isAlive = true;
				gc.stopMoving = true;
				sc.createBalls = false;


			}
				
		}



		if (!pb.hitObstacle && (col.gameObject.tag == "brick" ||col.gameObject.tag == "wood" || col.gameObject.tag == "box") ) {
				
				pb.hitObstacle = true;
				anim.SetBool("isHit",true);
			Debug.Log ("here1");
				
			}
			



		}

}
