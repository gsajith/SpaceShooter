using UnityEngine;
using System.Collections;

public class ShotMoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction = new Vector2(-1, 0);

	public float damage = 1.0f;
	
	private Vector2 movement;

	void Start() {
		Vector3 pos = this.gameObject.transform.position;
		pos.z = 0.0f;
		this.gameObject.transform.position = pos;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Enemy_MoveDirection enemyScript = other.GetComponent<Enemy_MoveDirection> ();
		if(enemyScript != null) {
			enemyScript.health -= damage;
			if(enemyScript.health <= 0) Destroy (other.gameObject);
			Destroy (this.gameObject);
			ScoreScript.score += enemyScript.bounty;
		}
		if (other.tag == "boss")
			Destroy (this.gameObject);
		if(other.tag=="minion") //added by Michael 4/5, used by Level 2
			Destroy(gameObject);
	}

	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

}
