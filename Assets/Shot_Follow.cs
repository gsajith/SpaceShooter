using UnityEngine;
using System.Collections;

public class Shot_Follow : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.y -= 0.09f;
		if(transform.position.y < -5f){
			Destroy(gameObject);
		}
		if(player.transform.position.x > transform.position.x) {
			temp.x += 0.02f;
		}
		else if(player.transform.position.x < transform.position.x) {
			temp.x -= 0.02f;
		}
		transform.position = temp;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
			Destroy(gameObject);
	}
}
