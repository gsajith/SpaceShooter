using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class PlayerMoveScript : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 5.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax), 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);

	}
}