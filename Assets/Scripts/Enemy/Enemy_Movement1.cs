using UnityEngine;
using System.Collections;

public class Enemy_Movement1 : MonoBehaviour {
	public float x, y;
	public Vector2 direction;
	public float speed;
	private Vector2 movement;

	void Update(){
		movement = new Vector2 (speed * direction.x, (Mathf.Cos(direction.x * Mathf.Deg2Rad)*(1/2)));
	}

	void FixedUpdate(){
		this.rigidbody2D.velocity = movement;
	}

}
