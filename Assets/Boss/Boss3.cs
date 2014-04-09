using UnityEngine;
using System.Collections;

/*
 * 	 Dashing down
 */

public class Boss3 : MonoBehaviour {

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
	Vector3 special_pos;
	int dash_stat; //0 for dashing, 1 for returning, 2 for finish
	float wait_timer;
	
	// Use this for initialization
	void Start () {
		activated = true;
		dir = false;
		dash_stat = 0;
		wait_timer = 0;
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
							special_pos = transform.position;
							fired = 0;
						}
					}
				}
				else{
					Dash ();
				}
			}
			if(hp <= 0) {
				LevelController lvctrl = GameObject.FindObjectOfType<LevelController>();
				lvctrl.trigger = true;
				Destroy(gameObject);
			}
		}
	}

	void Dash() {
		if(dash_stat==0) {
			if(wait_timer<1.5f) wait_timer+=Time.deltaTime;
			else{
				if(transform.position.y>-6f) {
					Vector3 temp = transform.position;
					temp.y -= 0.3f;
					transform.position = temp;
				}
				else {
					transform.position = special_pos + new Vector3(0, 2f, 0);
					dash_stat = 1;
				}
			}
		}
		else if(dash_stat ==1) {
			if(transform.position.y>4f){
				Vector3 temp = transform.position;
				temp.y -= 0.3f;
				transform.position = temp;
			}
			else {
				dash_stat = 2;
			}
		}
		else {
			special = false;
			wait_timer = 0;
			dash_stat = 0;
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
