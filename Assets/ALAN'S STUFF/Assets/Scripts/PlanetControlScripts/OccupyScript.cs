using UnityEngine;
using System.Collections;

public class OccupyScript : MonoBehaviour {

	public Sprite userGreen;
	public Sprite enemyRed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.parent.GetComponent<PlanetStatsScript> ().occupy == 1) {
						GetComponent<SpriteRenderer> ().sprite = userGreen;
				} else if (transform.parent.GetComponent<PlanetStatsScript> ().occupy == 2) {
						GetComponent<SpriteRenderer> ().sprite = enemyRed;
				} else {
			GetComponent<SpriteRenderer> ().sprite = null;
				}
	
	}
}
