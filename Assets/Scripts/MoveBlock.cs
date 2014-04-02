using UnityEngine;
//using System.Collections;
using System;

public class MoveBlock : MonoBehaviour {
	public bool canMove;
	private bool instantiated = true;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseOver() {
		if(instantiated){
			OnMouseDrag ();
			instantiated = false;
		}
	}

	void OnMouseDrag() {
		if(canMove) {
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			point.z = 0.0f;
			this.gameObject.transform.position = point;
		}
	}

	private float round(float x) {
		double hold = x / 0.5;
		int hold2 = (int)Math.Round (hold, 0);
		float hold3 = (float)(hold2 * 0.5);
		return hold3;
	}

	void OnMouseUp() {
		if(canMove) {
			
			Vector3 point = gameObject.transform.position;
			point.x = round (point.x);
			point.y = round (point.y);

			if(point.x <= -2.25f || point.x >= 2.25f
			   || point.y <= -1.25f || point.y >= 3.25f)
				DestroyObject(gameObject);
			else
			gameObject.transform.position = point;

		}

	}
	// Update is called once per frame
	void Update () {

	}
}
