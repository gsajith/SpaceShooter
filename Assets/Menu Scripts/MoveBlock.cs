using UnityEngine;
//using System.Collections;
using System;

public class MoveBlock : MonoBehaviour {
	public bool canMove;


	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDrag() {
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		point.y = gameObject.transform.position.y;
		gameObject.transform.position = point;
	}

	private float round(float x) {
		double hold = x / 0.25;
		int hold2 = (int)Math.Round (hold, 0);
		float hold3 = (float)(hold2 * 0.25);
		return hold3;
	}

	void OnMouseUp() {
		Vector3 point = gameObject.transform.position;
		//point.x = (float)Math.Round ((double)point.x, 1);
		Debug.Log (point.x);
		Debug.Log (" ");
		Debug.Log (Math.Round ((double)point.x, 1));
		Debug.Log ((float)Math.Round ((double)point.x, 1));
		//point.z = (float)Math.Round ((double)point.z, 1);
		point.x = round (point.x);
		point.z = round (point.z);
		/*		double rem = point.x / 0.25;
		int intRem = (int)Math.Round (rem-0.5, 0);
		float remain = (float)(rem - intRem);
		point.x = point.x - (float)remain;
		rem = point.z / 0.25;
		intRem = (int)Math.Round (rem-0.5, 0);
		remain = (float)(rem - intRem);
		point.z = point.z - (float)remain;
*/		gameObject.transform.position = point;

	}
	// Update is called once per frame
	void Update () {

	}
}
