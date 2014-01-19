using UnityEngine;
using System.Collections;

public class ShotMoveScript : MonoBehaviour {

	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;

	void Start() {
		Vector3 pos = this.gameObject.transform.position;
		pos.z = 5;
		this.gameObject.transform.position = pos;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(!(other.isTrigger)) {
			Debug.Log ("here");
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}

	}

	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}

}
