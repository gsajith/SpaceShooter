using UnityEngine;
using System.Collections;

/*
 * Spawns minions
 */

public class Boss4 : MonoBehaviour {

	public GameObject minions1;
	public GameObject minions2;
	public GameObject minions3;
	int wave = 0;
	public Vector3[] location;
	float spawn_timer;
	public float hp = 100f;

	// Use this for initialization
	void Start () {
		spawn_timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y>4f) {
			Vector3 temp = transform.position;
			temp.y -= 0.05f;
			transform.position = temp;
		}
		if(Time.time - spawn_timer > 2f){
			switch(wave) {
			case 0:
				Instantiate(minions1, transform.position+location[0], transform.rotation);
				Instantiate(minions1, transform.position+location[1], transform.rotation);
				Instantiate(minions1, transform.position+location[2], transform.rotation);
				wave++;
				spawn_timer = Time.time;
				break;
			case 1:
				Instantiate(minions1, transform.position+location[3], transform.rotation);
				Instantiate(minions1, transform.position+location[4], transform.rotation);
				spawn_timer = Time.time;
				wave++;
				break;
			case 2:
				Instantiate(minions2, transform.position+location[3], transform.rotation);
				Instantiate(minions2, transform.position+location[4], transform.rotation);
				Instantiate(minions3, transform.position+location[3], transform.rotation);
				Instantiate(minions3, transform.position+location[4], transform.rotation);
				spawn_timer = Time.time;
				wave++;
				break;
			default:
				wave = 0;
				break;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "player_shot") {
			hp -= 1f;
		}
		if(hp <= 0) {
			LevelController lvctrl = GameObject.FindObjectOfType<LevelController>();
			lvctrl.trigger = true;
			Destroy(gameObject);
		}
	}
}
