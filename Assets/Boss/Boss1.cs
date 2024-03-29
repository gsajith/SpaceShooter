﻿using UnityEngine;
using System.Collections;

/*
 *   Laser every few seconds
 */

public class Boss1 : MonoBehaviour {

	public bool activated;
	public float hp;
	public GameObject shot;
	int timer = 10;
	int fired = 0;
	public float firerate = 0.5f;
	private float nextshot = 0F;
	bool dir;
	bool special = false;
	float special_timer = 0;

	// Use this for initialization
	void Start () {
		activated = false;
		hp = 100f;
		dir = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated) {
			if(transform.position.y > 4) {
				Vector2 temp = transform.position;
				temp.y -= 0.05f;
				transform.position = temp;
			}
			else {
				if(!special){
					if(dir) {
						Vector2 temp = transform.position;
						temp.x -= 0.03f;
						transform.position = temp;
						if(transform.position.x <= -2.5f) dir = false;
					}
					else {
						Vector2 temp = transform.position;
						temp.x += 0.03f;
						transform.position = temp;
						if(transform.position.x >= 2.5f) dir = true;
					}
					nextshot += Time.deltaTime;
					if (nextshot > firerate) {
						nextshot = 0f;
						fired += 1;
						Instantiate (shot, transform.position, transform.rotation);
						if(fired == 10) {
							special = true;
							special_timer = 0;
							fired = 0;
						}
					}
				}
				else{
					special_timer += Time.deltaTime;
					Instantiate (shot, transform.position, transform.rotation);
					if(special_timer >= 3f)
						special = false;
				}
			}
			if(hp <= 0) {
			//	LevelController lvctrl = GameObject.FindObjectOfType<LevelController>();
			//	lvctrl.trigger = true;
				Destroy(gameObject);
				Application.LoadLevel("GameScene");
			}
		}
	}
	
	IEnumerator waitForSecs(int secs) {
		yield return new WaitForSeconds (secs);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(activated)
			if(other.tag == "player_shot")
				hp-=1f;
	}
}
