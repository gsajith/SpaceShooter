using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject playerPrefab = Instantiate (Resources.Load ("PlayerPrefab", typeof(GameObject))) as GameObject;
		Vector3 localScale = playerPrefab.transform.localScale;
		localScale.x = localScale.x * .5f;
		localScale.y = localScale.y * .5f;
		localScale.z = localScale.z * .5f;
		playerPrefab.transform.localScale = localScale;
		PlayerMoveScript pms = playerPrefab.GetComponent<PlayerMoveScript> ();
		if(pms != null) {
			pms.fireRate = .5f;
			pms.speed = 4f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
