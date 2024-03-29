﻿using UnityEngine;
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
	bool frenzy;
	float prev_firerate;
	public GameObject lvlCtrl;
	public LevelController controlScript;

	void Start() {
		lvlCtrl = GameObject.Find ("LevelController");
		controlScript = lvlCtrl.GetComponent<LevelController> ();
		prev_firerate = fire_interval;
		last_shot = Time.time;
		left = false;
	}

	// Update is called once per frame
	void Update () {
		frenzy = controlScript.frenzy_trigger;
		if(frenzy) {
			fire_interval = 0.25f;
		}
		else
			fire_interval = prev_firerate;
		if(left) {
			Vector3 temp = transform.position;
			temp.x += 0.03f;
			transform.position = temp;
			CheckDir();
		}
		else {
			Vector3 temp = transform.position;
			temp.x -= 0.03f;
			transform.position = temp;
			CheckDir();
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
				break;if(transform.position.x > 2.8f)
				left = false;
			default:
				fired = 0;
				break;
			}
		}
	
	}

	void CheckDir(){
		if(transform.position.x > 2.8f)
			left = false;
		if(transform.position.x < -2.8f)
			left = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "player_shot"){
			hp -= 1f;
		}
		if(hp==0) Destroy(gameObject);
	}
}
