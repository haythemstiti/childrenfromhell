using UnityEngine;
using System.Collections;

public class PersonFollow : MonoBehaviour {

	private Intro intro;
	public GameObject perso;
	// Use this for initialization
	void Start () {
		intro = GetComponent<Intro> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (intro.elapsetTime > 45f) {	

			transform.position = Vector3.Lerp(transform.position, perso.transform.position, Time.fixedDeltaTime * 3f);	
						transform.LookAt (perso.transform);
				}
	}
}
