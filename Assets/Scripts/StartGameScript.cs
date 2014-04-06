using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {
	public GameObject healthBarObject;
	public int sceneNum = 2;

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
			pms.speed = 3f;
			pms.boundary.xMin = -2.5f;
			pms.boundary.xMax = 3.5f;
			pms.boundary.yMin = -8.5f;
			pms.boundary.yMax = 1.5f;
		}
		HealthBar healthBar = healthBarObject.GetComponent<HealthBar> ();
		if(healthBar != null) {
			healthBar.player = playerPrefab;
		}
	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.F1)) {
			Application.LoadLevel(sceneNum);
		}
	}
}
