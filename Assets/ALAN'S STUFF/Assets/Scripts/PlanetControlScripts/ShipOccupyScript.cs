using UnityEngine;
using System.Collections;

public class ShipOccupyScript : MonoBehaviour {

	public Sprite enemyOrbitSprite;
	public RuntimeAnimatorController enemyOrbitController;

	public Sprite playerOrbitSprite;
	public RuntimeAnimatorController playerOrbitController;

	void Start () {
	
	}

	void Update () {
		if (transform.parent.GetComponent<PlanetStatsScript> ().ship == 1) {
			GetComponent<SpriteRenderer>().sprite = playerOrbitSprite;
			GetComponent<Animator>().runtimeAnimatorController = playerOrbitController;
		}
		else if (transform.parent.GetComponent<PlanetStatsScript> ().ship == 2) {
			GetComponent<SpriteRenderer>().sprite = enemyOrbitSprite;
			GetComponent<Animator>().runtimeAnimatorController = enemyOrbitController;
		}
		else {
			GetComponent<SpriteRenderer>().sprite = null;
			GetComponent<Animator>().runtimeAnimatorController = null;
		}
	}
}
