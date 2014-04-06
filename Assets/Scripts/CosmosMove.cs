using UnityEngine;
using System.Collections;

public class CosmosMove : MonoBehaviour {
	public float moveSpeed = .03f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 trans = this.transform.position;
		trans.y -= moveSpeed;
		if (trans.y <= -22.1f)
						trans.y = 43.79366f;
		this.transform.position = trans;
	}

}
