using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerMoveScript : MonoBehaviour
{
	public float speed = 1f;
	public Boundary boundary;
	public float fireRate;
	public List<GameObject> shots = new List<GameObject> ();
	public List<Transform> shotSpawns = new List<Transform>();
	public float health = 10;
	static public float healthbar = 10;
	float invinsTime = 0;

	private float nextFire;

	void Start() {
		Vector3 pos = new Vector3 (rigidbody2D.transform.position.x, rigidbody2D.transform.position.y, rigidbody2D.transform.position.z);

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
		invinsTime -= Time.deltaTime;
		if (invinsTime > 0) {
			MeshRenderer[] renderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach(MeshRenderer renderer in renderers) {
				renderer.enabled = !renderer.enabled;
			}
			BoxCollider2D[] colliders = this.gameObject.GetComponentsInChildren<BoxCollider2D>();
			foreach(BoxCollider2D collider in colliders) {
				collider.enabled = false;
			}
		} else {
			MeshRenderer[] renderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach(MeshRenderer renderer in renderers) {
				renderer.enabled = true;
			}
			BoxCollider2D[] colliders = this.gameObject.GetComponentsInChildren<BoxCollider2D>();
			foreach(BoxCollider2D collider in colliders) {
				collider.enabled = true;
			}
		}
	}

	public void doDamage(float damage) {
		if(invinsTime <= 0) {
			health -= damage;
			if (health <= 0)
						Destroy (this.gameObject);
			invinsTime = .5f;
		}
	}


	void FixedUpdate ()	{

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