using UnityEngine;
using System.Collections;

public class Enemy_MoveRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float maxEnemies;
	public float speed = 1;
	public GameObject Enemy;
	//float count = 0;
	// Update is called once per frame
	//var projectile : Rigidbody2D;

	void Update () {
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (1,0);
		rigidbody2D.velocity = movement * speed;
		if (collider2D.isTrigger) {
			maxEnemies++;

		}
		/*	var clone : Rigidbody2D;
		clone = Instantiate (projectile, transform.positon, transform.rotation);
		clone.velocity = transform.TransformDirection(Vector2.right);
	*/}
}
