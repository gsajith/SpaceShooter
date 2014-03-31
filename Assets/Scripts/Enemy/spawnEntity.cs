using UnityEngine;
using System.Collections;

public class spawnEntity : MonoBehaviour {

	public GameObject entity;
	public float spawnRate;
	public float spawnDelay;
	public int numToSpawn;
	public float horizSpeed;
	public float vertSpeed;
	float nextSpawn;
	int numLeft;

	void Start(){
			nextSpawn = Time.time + spawnRate;
			Random.seed = numToSpawn;
			numLeft = numToSpawn;
	}

	void Update(){
		spawnDelay -= Time.deltaTime;
		if (spawnDelay <= 0 && nextSpawn < Time.time && numToSpawn > 0) {
			numToSpawn--;
			nextSpawn = Time.time + spawnRate + Random.value*(spawnRate/4.0f);
			GameObject enemy = Instantiate (entity, transform.position, transform.rotation) as GameObject;
			Enemy_MoveDirection moveScript = enemy.GetComponent<Enemy_MoveDirection>();
			if(moveScript != null) {
				moveScript.speed = 1;
				moveScript.h = horizSpeed;
				moveScript.v = vertSpeed;
				moveScript.spawner = this.gameObject;
			}
		}
	}

	public void removeOneEnemy() {
		numLeft--;
	}

	public int getNumLeft() {
		return numLeft;
	}
}
