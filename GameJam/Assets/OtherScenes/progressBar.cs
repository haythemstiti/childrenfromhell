using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class progressBar : MonoBehaviour {

	public bool hitObstacle = false;
	public GameObject player;
	private Animator anim;
	public float elapsedTime = 0f;


	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("player");
		anim = player.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		Debug.Log(anim.GetBool("isHit"));

		Image image = GetComponent<Image> ();
		image.fillAmount = Mathf.Lerp (image.fillAmount, 0f, Time.deltaTime*0.05f);
		if (image.fillAmount <0.1f) {
			Debug.Log("you win");
				}

		if ( hitObstacle)
		{
			elapsedTime  += Time.deltaTime;
				image.fillAmount = 1f;
				


		}
		if (elapsedTime > 0.3f) {
			hitObstacle = false;
			elapsedTime = 0;
			anim.SetBool("isHit",false);
		
		}
		Debug.Log (hitObstacle);


	}
}
