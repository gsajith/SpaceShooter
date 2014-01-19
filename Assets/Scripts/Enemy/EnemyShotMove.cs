using UnityEngine;
using System.Collections;

public class EnemyShotMove : MonoBehaviour {

	public float speed = 10F;
	public float damage = 1.0f;
	public Vector2 direction = new Vector2(-1,0);
	private Vector2 movement;
	void OnTriggerEnter2D(Collider2D other){
		Transform t = other.transform;
		Debug.Log (other.transform);
		PlayerMoveScript isPlayer = (PlayerMoveScript)t.parent.GetComponent (typeof(PlayerMoveScript));
		if(isPlayer != null) {
			isPlayer.health -= damage;
			Destroy (this.gameObject);
			if(isPlayer.health <= 0) {
				Destroy (other.transform.parent.gameObject);
			}
		}

	}


	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed * direction.x,
			speed * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}

}
