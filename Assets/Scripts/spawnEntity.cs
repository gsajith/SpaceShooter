using UnityEngine;
using System.Collections;

public class spawnEntity : MonoBehaviour {

	public GameObject entity;
	public float spawnrate;
	float t = Time.time;

	void Update(){
		if (Time.time >= spawnrate + t)
			Instantiate (entity, transform.position, transform.rotation);
			t = Time.time;
		}
}
