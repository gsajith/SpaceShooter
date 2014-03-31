using UnityEngine;
using System.Collections;

public class Enemy_MoveDirection : MonoBehaviour {

	public float h, v;
	public float speed = 1;
	public float health = 1;
	public float bounty = 100;
	public GameObject spawner;

	void Update () {
		Vector2 movement = new Vector2 (h,v);
		rigidbody2D.velocity = movement * speed;

	}

	void OnDestroy() {
		spawnEntity spawnScript = spawner.GetComponent<spawnEntity> ();
		if(spawnScript != null) {
			spawnScript.removeOneEnemy();
		}
	}

}
