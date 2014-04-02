using UnityEngine;
using System.Collections;

public class MapCameraScript : MonoBehaviour {

	public Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		movement = transform.position;

		if (Input.GetKey(KeyCode.W) && (transform.position.y < 2.4f)) {
			movement.y = transform.position.y + 0.1f;
			transform.position = movement;

		}

		if (Input.GetKey (KeyCode.S) && (transform.position.y > -2.3f)) {
			movement.y = transform.position.y - 0.1f;
			transform.position = movement;
			
		}

		if (Input.GetKey (KeyCode.D) && (transform.position.x < 1.3f)) {
			movement.x = transform.position.x + 0.1f;
			transform.position = movement;
			
		}

		if (Input.GetKey (KeyCode.A) && (transform.position.x > -1.4f)) {
			movement.x = transform.position.x - 0.1f;
			transform.position = movement;
			
		}


		if (Input.GetKey (KeyCode.Z) && (camera.orthographicSize < 4.8f)) {
			camera.orthographicSize = camera.orthographicSize + 0.1f;
		}

		if (Input.GetKey (KeyCode.X) && (camera.orthographicSize > 2.5f)) {
			camera.orthographicSize = camera.orthographicSize - 0.1f;
		}


		}


	
	
}
