using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject perso1;
	public GameObject perso2;
	public GameObject perso3;
	public GameObject perso4;
	public GameObject destination;
	public GameObject fence;
	private bool open = false;

	public float elapsetTime=0f;
	private Animator anim1,anim2,anim3,anim4;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("save","Level3");
		anim1 = perso1.GetComponent<Animator> ();
		anim2 = perso2.GetComponent<Animator> ();
		anim3 = perso3.GetComponent<Animator> ();
		anim4 = perso4.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		elapsetTime += Time.deltaTime;
//		Debug.Log ("ela" + elapsetTime);
		if (elapsetTime > 10f) {
						perso1.transform.position = Vector3.MoveTowards (perso1.transform.position, destination.transform.position, 5f * Time.deltaTime);	
						perso1.transform.LookAt (destination.transform);
						anim1.SetBool ("walking", true);
				}

		if (elapsetTime > 15f) {
						perso2.transform.position = Vector3.MoveTowards (perso2.transform.position, destination.transform.position, 5f * Time.deltaTime);	
						perso2.transform.LookAt (destination.transform);
						anim2.SetBool ("walking", true);
				}

		if (elapsetTime > 25f ) {
						perso3.transform.position = Vector3.MoveTowards (perso3.transform.position, destination.transform.position, 5f * Time.deltaTime);	
						perso3.transform.LookAt (destination.transform);
						anim3.SetBool ("walking", true);
				}

		if (elapsetTime > 35f) {
						perso4.transform.position = Vector3.MoveTowards (perso4.transform.position, destination.transform.position, 5f * Time.deltaTime);	
						perso4.transform.LookAt (destination.transform);
						anim4.SetBool ("walking", true);
				}

		if (elapsetTime > 53f) {
		
						if ((CFInput.GetButton ("Action")) && !open) {
								Debug.Log ("Destroy !!!!");
								fence.transform.Rotate (-90f, 0f, 0f);
								open = true;
						} 		
				}

			

	}

	void OnGUI(){
		if (elapsetTime > 10f && elapsetTime < 15f) {
				GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,300 ,50), "I need to pee");
			}
		if (elapsetTime > 15f && elapsetTime < 25f) {
			GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,300 ,50), "I need to pee Too");
		}
		if (elapsetTime > 25f && elapsetTime < 35f) {
			GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,500 ,50), "Where did everyone go ? Hmmm");
		}
		if (elapsetTime > 35f && elapsetTime < 40f) {
			GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,500 ,50), "This is weird !! Where's everyone !! I need to check it out !!");
		}
		if (elapsetTime > 48f && elapsetTime <53) {
			GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,500 ,50), "What do we do NOW ??????!");
		}
		if (open) {
			GUI.Box (new Rect (Screen.width/2-150, Screen.height-Screen.height/10,500 ,50), "Let's go and look for our friends");
		}
 	}


}
