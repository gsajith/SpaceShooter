using UnityEngine;
using System.Collections;

public class Enemy_MoveRight : MonoBehaviour {
	public GameObject bullet;
	public float fire_interval;
	public float speed;
	float last_shot;
	public float hp;

	void Start() {
		last_shot = Time.time;
		rigidbody2D.velocity = new Vector2 (0.5f, speed * -1f);
	}

	// Update is called once per frame
	void Update () {
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
