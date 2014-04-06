using UnityEngine;
using System.Collections;

public class Enemy_Walker : MonoBehaviour {

	public GameObject shot_left;
	public GameObject shot;
	public GameObject shot_right;
	public float fire_interval;
	public float hp;
	float last_shot;
	bool left;
	int fired = 0;

	void Start() {
		last_shot = Time.time;
		left = false;
	}

	// Update is called once per frame
	void Update () {
		if(left) {
			Vector3 temp = transform.position;
			temp.x += 0.05f;
			transform.position = temp;
			if(transform.position.x > 2.8f)
				left = false;
		}
		else {
			Vector3 temp = transform.position;
			temp.x -= 0.05f;
			transform.position = temp;
			if(transform.position.x < -2.8f)
				left = true;
		}
		if(Time.time-last_shot>fire_interval){
			switch(fired){
			case 0:
				Instantiate(shot_left, transform.position, transform.rotation);
				last_shot = Time.time;
				fired++;
				break;
			case 1:
				Instantiate(shot, transform.position, transform.rotation);
				last_shot = Time.time;
				fired++;
				break;
			case 2:
				Instantiate(shot_right, transform.position, transform.rotation);
				last_shot = Time.time;
				fired++;
				break;
			default:
				fired = 0;
				break;
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "player_shot"){
			hp -= 1f;
		}
		if(hp==0) Destroy(gameObject);
	}
}
