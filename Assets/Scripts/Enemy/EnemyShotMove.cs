﻿using UnityEngine;
using System.Collections;

public class EnemyShotMove : MonoBehaviour {

	public float speed = 10F;
	public float damage = 1.0f;
	public Vector2 direction = new Vector2(-1,0);
	private Vector2 movement;
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.parent != null){
			PlayerMoveScript isPlayer = other.transform.parent.GetComponent<PlayerMoveScript> ();
			if(isPlayer != null) {
				isPlayer.doDamage(damage);
				Destroy (this.gameObject);
			}
		}
	}


	void Update()
	{
		movement = new Vector2(
			speed * direction.x,
			speed * direction.y);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

}
