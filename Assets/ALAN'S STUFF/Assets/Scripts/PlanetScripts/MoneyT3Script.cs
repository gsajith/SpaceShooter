using UnityEngine;
using System.Collections;

public class MoneyT3Script : MonoBehaviour {

	public Sprite nonHighlight;
	public Sprite highlight;
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	void OnMouseEnter() {
		GetComponent<SpriteRenderer> ().sprite = highlight;
	}
	
	void OnMouseExit() {
		GetComponent<SpriteRenderer> ().sprite = nonHighlight;
	}
	
	void OnMouseDown() {
		if (GetComponent<PlanetStatsScript> ().occupy == 1 && 
		    GetComponent<PlanetStatsScript> ().ship == 1 &&
		    GetComponent<PlanetStatsScript> ().destination == false) {
			
			GameControlScript.select = true;
			GameControlScript.selectedPlanet = gameObject;
			
			GetComponentInChildren<UpRightScript>().showArrow = true;
			GetComponentInChildren<UpLeftScript>().showArrow = true;
			GetComponentInChildren<DownRightScript>().showArrow = true;
			GetComponentInChildren<DownLeftScript>().showArrow = true;
		}

		if (GetComponent<PlanetStatsScript> ().destination == true /***&& Ship & Occupation Status Will Set Up the Battle***/) {
			//***The Following Settings Depend on the Outcome of the Battle***//
			GetComponent<PlanetStatsScript>().ship = 1; 
			GetComponent<PlanetStatsScript>().occupy = 1; 
			GetComponent<PlanetStatsScript>().destination = false; 
			
			//Deselecting Start Location Planet
			GameControlScript.selectedPlanet.GetComponentInChildren<DownLeftScript> ().showArrow = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<DownRightScript> ().showArrow = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<UpLeftScript> ().showArrow = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<UpRightScript> ().showArrow = false;
			GameControlScript.selectedPlanet.GetComponent<PlanetStatsScript>().ship = 0; // Ship has Moved Away
			//GameControlScript.selectedPlanet.GetComponent<PlanetStatsScript>().destination = false;

			GameControlScript.selectedPlanet.GetComponentInChildren<DownLeftScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<DownRightScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<UpLeftScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
			GameControlScript.selectedPlanet.GetComponentInChildren<UpRightScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
			
			GameControlScript.select = false;
			GameControlScript.selectedPlanet = null;
		}
	}
}
