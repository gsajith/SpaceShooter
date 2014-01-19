using UnityEngine;
using System.Collections;

public class spawnEntity : MonoBehaviour {

	public GameObject entity;
	public float spawnrate;
	float nextSpawn;

	void Start(){
		nextSpawn = Time.time + spawnrate;
		Instantiate (entity, transform.position, transform.rotation);
	}

	void Update(){
				if (nextSpawn < Time.time) {
						nextSpawn = Time.time + spawnrate;
						Instantiate (entity, transform.position, transform.rotation);
				}
		}
}
