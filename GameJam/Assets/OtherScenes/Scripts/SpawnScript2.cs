using UnityEngine;
using System.Collections;

public class SpawnScript2 : MonoBehaviour {


	
	public GameObject powerup;
	public GameObject father;
	
	float timeElapsed = 0;
	float spawnCycle = 0.2f;
	bool spawnPowerup = true;
	public bool createBalls = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log ("" + createBalls);
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnPowerup)
			{
				if(createBalls){
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = father.transform.position;
					temp.transform.position = new Vector3(pos.x,1.5f, Random.Range(-13, -2));
			//	temp.transform.rotation = new Vector3(pos.x, Random.Range(0,180), pos.z);
				
				}
			}
			
			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}	}
}
