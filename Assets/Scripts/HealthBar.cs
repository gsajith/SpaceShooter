using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Scale = transform.localScale;
		transform.localScale = new Vector3 ((PlayerMoveScript.healthbar * 2f) / 100f, 0.2f, 0.015f);
	}
}
