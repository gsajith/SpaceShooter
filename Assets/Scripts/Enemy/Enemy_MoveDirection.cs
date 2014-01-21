using UnityEngine;
using System.Collections;

public class Enemy_MoveDirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	//public float maxEnemies;
	public float h, v;
	public float speed = 1;
	public float health = 1;
	public float bounty = 100;
	//public GameObject Enemy;
	//float count = 0;
	// Update is called once per frame
	//var projectile : Rigidbody2D;

	void Update () {
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (h,v);
		rigidbody2D.velocity = movement * speed;

		/*	var clone : Rigidbody2D;
		clone = Instantiate (projectile, transform.positon, transform.rotation);
		clone.velocity = transform.TransformDirection(Vector2.right);
	*/}

}
