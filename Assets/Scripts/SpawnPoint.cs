using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour {
	
	public GameObject enemy;
	public int number;
	public List<float> time;
	public List<Vector2> location;
	public int key;
	public float cooldown;
	float startup_time;
	int i;
	bool spawning;
	float cd_timer;

	// Use this for initialization
	void Start () {
		cd_timer = cooldown;
		i = number;
		startup_time = Time.time;
		spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!spawning){
			switch(key) {
			case 1:
				if(Input.GetKeyDown("1")){
					SetStart();
				}
				break;
			case 2:
				if(Input.GetKeyDown("2")){
					SetStart();
				}
				break;
			case 3:
				if(Input.GetKeyDown("3")){
					SetStart();
				}
				break;
			case 4:
				if(Input.GetKeyDown("4")){
					SetStart();
				}
				break;
			case 5:
				if(Input.GetKeyDown("5")){
					SetStart();
				}
				break;
			case 6:
				if(Input.GetKeyDown("6")){
					SetStart();
				}
				break;
			case 7:
				if(Input.GetKeyDown("7")){
					SetStart();
				}
				break;
			case 8:
				if(Input.GetKeyDown("8")){
					SetStart();
				}
				break;
			default:
				break;
			}
		}
		else {
			if(i<number){
				if(Time.time -startup_time>= time[i]) {
					SpawnEnemy(i);
					i++;
				}
			}
			else {
				if(cd_timer >= 0) {
					cd_timer -= Time.deltaTime;
				}
				else{
					spawning = false;
					cd_timer = cooldown;
				}
			}
		}
	}

	void SetStart() {
		startup_time = Time.time;
		i = 0;
		spawning = true;
	}

	void SpawnEnemy(int n){
		Instantiate(enemy, location[i], Quaternion.identity);
	}
}
