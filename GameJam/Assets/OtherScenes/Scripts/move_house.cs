using UnityEngine;
using System.Collections;

public class move_house : MonoBehaviour {
	public GameObject homes_left, homes_right;
	public float timer = 0;
	public GameObject[] obstacles;
	GameObject obstacle;
	bool isShownObstacle = false;
	GameObject leftSpawn, leftSpawn2, leftSpawn3, rightSpawn, rightSpawn2, rightSpawn3;
	bool createLeftSpawn = true, createLeftSpawn2 = true, createLeftSpawn3 = true, createRightSpawn = true, createRightSpawn2 = true, createRightSpawn3 = true;
	void Start () {
	}
	void Update () {
		timer += Time.deltaTime;
		if (timer>0.1f && !isShownObstacle)
		{
			isShownObstacle = true;
			obstacle = (GameObject) Instantiate(obstacles[Random.Range(0,2)],new Vector3 (32.8f,0,Random.Range(-12,-4)+0.11f), Quaternion.identity); 
		}
		if (createLeftSpawn) {
			leftSpawn = (GameObject)Instantiate (homes_left, new Vector3 (0,0,-15.8f), Quaternion.identity);
			createLeftSpawn = false;
		}
		if (createLeftSpawn2) {
			leftSpawn2 = (GameObject)Instantiate (homes_left, new Vector3 (20,0,-15.8f), Quaternion.identity);
			createLeftSpawn2 = false;
		}
		if (createLeftSpawn3) {
			leftSpawn3 = (GameObject)Instantiate (homes_left, new Vector3 (40,0,-15.8f), Quaternion.identity);
			createLeftSpawn3 = false;
		}
		if (createRightSpawn) {
			rightSpawn = (GameObject)Instantiate (homes_right, new Vector3 (17.25078f,0,-7.020847f), Quaternion.identity);
			createRightSpawn = false;
		}
		if (createRightSpawn2) {
			rightSpawn2 = (GameObject)Instantiate (homes_right, new Vector3 (37.25078f,0,-7.020847f), Quaternion.identity);
			createRightSpawn2 = false;
		}
		if (createRightSpawn3) {
			rightSpawn3 = (GameObject)Instantiate (homes_right, new Vector3 (57.25078f,0,-7.020847f), Quaternion.identity);
			createRightSpawn3 = false;
		}
		leftSpawn.transform.Translate (-0.1f,0,0);
		leftSpawn2.transform.Translate (-0.1f,0,0);
		leftSpawn3.transform.Translate (-0.1f,0,0);
		rightSpawn.transform.Translate (-0.1f,0,0);
		rightSpawn2.transform.Translate (-0.1f,0,0);
		rightSpawn3.transform.Translate (-0.1f,0,0);
		if (leftSpawn.transform.position.x < -40) {
			Destroy (leftSpawn);
			createLeftSpawn = true;
		}
		if (leftSpawn2.transform.position.x < -40) {
			Destroy (leftSpawn2);
			createLeftSpawn2 = true;
		}
		if (leftSpawn3.transform.position.x < -40) {
			Destroy (leftSpawn3);
			createLeftSpawn3 = true;
		}
		if (rightSpawn.transform.position.x < -10) {
			Destroy (rightSpawn);
			createRightSpawn = true;
		}
		if (rightSpawn2.transform.position.x < -10) {
			Destroy (rightSpawn2);
			createRightSpawn2 = true;
		}
		if (rightSpawn3.transform.position.x < -10) {
			Destroy (rightSpawn3);
			createRightSpawn3 = true;
		}
		if (isShownObstacle)
		{
			obstacle.transform.Translate(-0.1f,0,0);
	}
		if (obstacle != null)
		if (obstacle.transform.position.x < -10)
		{
			timer = 0;
			isShownObstacle = false;
			Destroy(obstacle);
		}
}
}
