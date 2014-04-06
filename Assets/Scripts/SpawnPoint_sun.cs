using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint_sun : MonoBehaviour {

	public GameObject enemy;
	public int number;
	public List<float> time;
	public List<Vector2> location;
	float startup_time;
	bool sleep;
	int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(i<number){
			if(Time.time >= time[i]) {
				SpawnEnemy(i);
				i++;
			}
		}
	}

	void SpawnEnemy(int n){
		Instantiate(enemy, location[i], Quaternion.identity);
	}
}
