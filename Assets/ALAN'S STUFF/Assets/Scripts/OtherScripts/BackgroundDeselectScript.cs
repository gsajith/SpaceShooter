using UnityEngine;
using System.Collections;

public class BackgroundDeselectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//Deselecting Start Location Planet
		GameControlScript.selectedPlanet.GetComponentInChildren<DownLeftScript> ().showArrow = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<DownRightScript> ().showArrow = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<UpLeftScript> ().showArrow = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<UpRightScript> ().showArrow = false;
		//GameControlScript.selectedPlanet.GetComponent<PlanetStatsScript>().destination = false;
		
		GameControlScript.selectedPlanet.GetComponentInChildren<DownLeftScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<DownRightScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<UpLeftScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
		GameControlScript.selectedPlanet.GetComponentInChildren<UpRightScript> ().thePlanet.GetComponent<PlanetStatsScript>().destination = false;
		
		GameControlScript.select = false;
		GameControlScript.selectedPlanet = null;


		}
}
