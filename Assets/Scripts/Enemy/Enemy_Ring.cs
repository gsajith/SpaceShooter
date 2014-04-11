using UnityEngine;
using System.Collections;

public class Enemy_Ring : MonoBehaviour {
	public GameObject bullet;
	public float fire_interval;
	float last_shot;
	public float hp;
	bool frenzy;
	float prev_firerate;
	public GameObject lvlCtrl;
	public LevelController controlScript;
	bool left;
	
	void Start() {
		left = false;
		lvlCtrl = GameObject.Find ("LevelController");
		controlScript = lvlCtrl.GetComponent<LevelController> ();
		prev_firerate = fire_interval;
		last_shot = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
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
		frenzy = controlScript.frenzy_trigger;
		if(frenzy) {
			fire_interval = 0.25f;
		}
		else
			fire_interval = prev_firerate;
		if(Time.time-last_shot>fire_interval){
			GameObject temp;
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(0, -1);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(1, -1);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(1, 0);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(1, 1);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(0, 1);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(-1, 1);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(-1, 0);
			temp = Instantiate(bullet, transform.position, transform.rotation)as GameObject;
			temp.GetComponent<EnemyShotMove>().direction = new Vector2(-1, -1);
			last_shot = Time.time;
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
