using UnityEngine;
using System.Collections;

public class spawnEntity : MonoBehaviour {

	public GameObject entity;
	public float spawnrate;
	public bool isRespawning;
	float t = Time.time;
	void Start(){
		Instantiate (entity, transform.position, transform.rotation);
	}
	void Update(){
		if (isRespawning && (Time.time >= spawnrate + t))
			Instantiate (entity, transform.position, transform.rotation);
			t = Time.time;
		}
}
