using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMoveScript : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public float fireRate;
	public List<GameObject> shots = new List<GameObject> ();
	public List<Transform> shotSpawns = new List<Transform>();
	public float health = 10;

	private float nextFire;


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
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;
		
		rigidbody2D.transform.position = new Vector3 
			(
				Mathf.Clamp (rigidbody2D.transform.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody2D.transform.position.y, boundary.yMin, boundary.yMax),
				rigidbody2D.transform.position.z);

	}
}