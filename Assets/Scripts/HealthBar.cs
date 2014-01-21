using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public GameObject player;
	private float tempHealth;
	private float maxHealth;
	// Use this for initialization
	void Start () {
		tempHealth = PlayerMoveScript.healthbar;
		maxHealth = tempHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(tempHealth != PlayerMoveScript.healthbar) {
			Vector3 pos = transform.position;
			pos.x = pos.x - ((tempHealth-PlayerMoveScript.healthbar)*2f)/20f;
			transform.position = pos;
			Color temp = renderer.material.color;
			temp.r += (tempHealth-PlayerMoveScript.healthbar)/maxHealth;
			temp.g -= (tempHealth-PlayerMoveScript.healthbar)/maxHealth;
			renderer.material.color = temp;
			tempHealth = PlayerMoveScript.healthbar;
		}
		transform.localScale = new Vector3 ((PlayerMoveScript.healthbar * 2f) / 10f, 0.2f, 1f);
		if (player == null || PlayerMoveScript.healthbar == 0) {
			transform.localScale = new Vector3(0f, 0f, 0f);
		}   

	}
}
