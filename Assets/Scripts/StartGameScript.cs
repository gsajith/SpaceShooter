using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {
	public GameObject healthBarObject;

	void Start () {
		GameObject playerPrefab = Instantiate (Resources.Load ("PlayerPrefab", typeof(GameObject))) as GameObject;
		Vector3 localScale = playerPrefab.transform.localScale;
		localScale.x = localScale.x * .5f;
		localScale.y = localScale.y * .5f;
		localScale.z = localScale.z * .5f;
		playerPrefab.transform.localScale = localScale;
		PlayerMoveScript pms = playerPrefab.GetComponent<PlayerMoveScript> ();
		if(pms != null) {
			pms.fireRate = .3f;
			pms.speed = .03f;
		}
		HealthBar healthBar = healthBarObject.GetComponent<HealthBar> ();
		if(healthBar != null) {
			healthBar.player = playerPrefab;
		}
	}

	void Update () {
	
	}
}
