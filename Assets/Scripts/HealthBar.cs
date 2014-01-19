using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 ((PlayerMoveScript.healthbar * 2f) / 10f, 0.2f, 1f);
		if (PlayerMoveScript.healthbar == 0) {
			transform.localScale = new Vector3(0f, 0f, 0f);
		}                          
	}
}
