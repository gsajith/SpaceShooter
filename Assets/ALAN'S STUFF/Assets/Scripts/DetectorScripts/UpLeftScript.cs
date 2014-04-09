using UnityEngine;
using System.Collections;

public class UpLeftScript : MonoBehaviour {

	public int adjacentPlanetStatus = -1;
	public GameObject thePlanet;
	public bool showArrow = false;
	
	public Sprite neutralArrow;
	public RuntimeAnimatorController neutralController;
	
	public Sprite friendlyArrow;
	public RuntimeAnimatorController friendlyController;
	
	public Sprite enemyArrow;
	public RuntimeAnimatorController enemyController;
	
	void Start () {
		
	}
	
	void Update () {
		if (showArrow == true) {
			thePlanet.GetComponent<PlanetStatsScript>().destination = true; 
			
			if(adjacentPlanetStatus == 0){
				GetComponent<SpriteRenderer>().sprite = neutralArrow;
				GetComponent<Animator>().runtimeAnimatorController = neutralController; 
			}
			if(adjacentPlanetStatus == GameControlScript.currentPlayer){
				if(GameControlScript.currentPlayer == 1)
				{
					GetComponent<SpriteRenderer>().sprite = friendlyArrow;
					GetComponent<Animator>().runtimeAnimatorController = friendlyController;
				}
				if(GameControlScript.currentPlayer == 2)
				{
					GetComponent<SpriteRenderer>().sprite = enemyArrow;
					GetComponent<Animator>().runtimeAnimatorController = enemyController;
				}
			}
			if(adjacentPlanetStatus != GameControlScript.currentPlayer && adjacentPlanetStatus != 0 && adjacentPlanetStatus != -1){
				if(GameControlScript.currentPlayer == 2)
				{
					GetComponent<SpriteRenderer>().sprite = friendlyArrow;
					GetComponent<Animator>().runtimeAnimatorController = friendlyController;
				}
				if(GameControlScript.currentPlayer == 1)
				{
					GetComponent<SpriteRenderer>().sprite = enemyArrow;
					GetComponent<Animator>().runtimeAnimatorController = enemyController;
				}
				
			}
		}
		
		if (showArrow == false) {
			//thePlanet.GetComponent<PlanetStatsScript>().destination = false; 
			GetComponent<SpriteRenderer>().sprite = null;
			GetComponent<Animator>().runtimeAnimatorController = null;	
		}
	}
	
	void OnTriggerStay2D(Collider2D planet) {
		if (planet.tag == "Planet") {
			adjacentPlanetStatus = planet.GetComponent<PlanetStatsScript>().occupy;
			thePlanet = planet.gameObject;
		}		
	}
}
