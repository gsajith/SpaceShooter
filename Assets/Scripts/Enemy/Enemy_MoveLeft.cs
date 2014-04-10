using UnityEngine;
using System.Collections;

public class Enemy_MoveLeft : MonoBehaviour {
	public GameObject bullet;
	public float fire_interval;
	public float speed;
	float last_shot;
	public float hp;
	bool frenzy;
	float prev_firerate;
	public GameObject lvlCtrl;
	public LevelController controlScript;

	void Start() {
		lvlCtrl = GameObject.Find ("LevelController");
		controlScript = lvlCtrl.GetComponent<LevelController> ();
		prev_firerate = fire_interval;
		last_shot = Time.time;
		rigidbody2D.velocity = new Vector2 (-0.8f, speed * -1f);
	}

	// Update is called once per frame
	void Update () {
		frenzy = controlScript.frenzy_trigger;
		if(frenzy) {
			fire_interval = 0.25f;
		}
		else
			fire_interval = prev_firerate;
		if(Time.time-last_shot>fire_interval){
			Instantiate(bullet, transform.position, transform.rotation);
			last_shot = Time.time;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "player_shot"){
			hp -= 1f;
		}
		if(hp==0) Destroy(gameObject);
	}
}
