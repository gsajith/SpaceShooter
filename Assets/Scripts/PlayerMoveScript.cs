using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMoveScript : MonoBehaviour
{
	public GridBuilder grid = new GridBuilder ();
	public float speed = 1f;
	public float timeLeft;
	public float tilt;
	public Boundary boundary;
	public float fireRate;
	public List<GameObject> shots = new List<GameObject> ();
	public List<Transform> shotSpawns = new List<Transform>();
	public float health = 10;
	static public float healthbar = 10;

	private float nextFire;

	void Start() {
		timeLeft = speed;
		grid.sizeGrid (6.0f, 10.0f);
		grid.positionGrid (-2.5f, -8.5f);
		grid.specifyGrid (60,100);
		Vector3 pos = new Vector3 (rigidbody2D.transform.position.x, rigidbody2D.transform.position.y, rigidbody2D.transform.position.z);

		pos = grid.alignToGrid (pos);
		//pos = grid.placeOnGrid (30, 30);
		rigidbody2D.transform.position = new Vector3 (pos.x, pos.y, pos.z);

	}

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			int i = 0;
			foreach(Transform shotSpawn in shotSpawns) {
				Instantiate (shots[i], shotSpawn.position, shotSpawn.rotation);
				i++;
			}
			nextFire = Time.time + fireRate;
		}
		healthbar = health;


	}

	void FixedUpdate ()	{

		timeLeft -= Time.deltaTime;

		if(timeLeft < 0) {
			Vector3 pos = new Vector3 (rigidbody2D.transform.position.x, rigidbody2D.transform.position.y, rigidbody2D.transform.position.z);
			if(Input.GetKey (KeyCode.UpArrow)) {
				pos = grid.moveUp (pos);
			} 
			
			if(Input.GetKey (KeyCode.LeftArrow)) {
				pos = grid.moveLeft (pos);
			} 
			
			if(Input.GetKey (KeyCode.DownArrow)) {
				pos = grid.moveDown (pos);
			} 
			
			if(Input.GetKey (KeyCode.RightArrow)) {
				pos = grid.moveRight (pos);
			} 
			
			rigidbody2D.transform.position = new Vector3 (pos.x, pos.y, pos.z);
			timeLeft = speed;
		}
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;
		
		rigidbody2D.transform.position = new Vector3 
			(
				Mathf.Clamp (rigidbody2D.transform.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody2D.transform.position.y, boundary.yMin, boundary.yMax),
				rigidbody2D.transform.position.z);

			}*/
	}
}