using UnityEngine;
using System.Collections;

public class BigHeadMove : MonoBehaviour {
	public int movementSpeed;
	private GameObject warior;
	private PlayerControlTinyWarrior pctw;
	private bool flipped = false;
	private float flippedTime = 0f;
	private AudioSource sourceScream;
	public GameObject camera;
	private AudioSource sourceBg;
	// Use this for initialization
	void Start () {
		warior = GameObject.FindGameObjectWithTag ("warior");
		pctw = warior.GetComponent<PlayerControlTinyWarrior> ();
		sourceScream = GetComponent<AudioSource> ();
		sourceBg = camera.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (flipped)
						flippedTime += Time.deltaTime;
		if (flipped && flippedTime < 2) {
		//	transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation*Quaternion.Euler (180,0,0), Time.deltaTime * .1f);
		//	return;
			sourceBg.Stop();
			sourceScream.Play();
		}
		if (flippedTime > 4f) {
			Destroy(gameObject);
				}
		transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
	}
	void OnTriggerEnter(Collider other) {
		if (flipped)
						return;
		if (pctw.skatePlaced) {
			if (other.tag == "hover")
			{
				flipped= true;
				Destroy(other.gameObject);
				Debug.Log(flipped);
			}
		}
		if (other.name == "CubeBigHead") {
			Debug.Log("Enter");
			transform.Translate(Vector3.zero);
			transform.Rotate(new Vector3(0f,180f,0f));
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		if (other.name == "CubeBigHead1") {
			Debug.Log("Enter1");
			transform.Translate(Vector3.zero);
			transform.Rotate(new Vector3(0f,180f,0f));
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		if (other.name == "CubeTrap" && pctw.putHoverBoard ==true) {
			Debug.Log("Blo9");
		}
	}	
}