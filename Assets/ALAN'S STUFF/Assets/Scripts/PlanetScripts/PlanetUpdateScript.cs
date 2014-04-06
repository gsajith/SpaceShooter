using UnityEngine;
using System.Collections;

public class PlanetUpdateScript : MonoBehaviour {

	int numPlanets = 0;
	bool firstTime = true;
	void Start () {
		PlanetStatsScript[] planets = GameObject.Find ("Planets").GetComponentsInChildren<PlanetStatsScript> ();
		int i = 0;
		foreach (PlanetStatsScript planet in planets) {
			planet.planetName = "Planet" + i + "";
			planet.planetNum = i++;
			PlayerPrefs.SetInt (planet.planetName, planet.occupy);
		}
		numPlanets = i;
		if (PlayerPrefs.HasKey ("CurrentPlanet") && PlayerPrefs.HasKey ("AttackingPlayer")) {
			Debug.Log ("setting planet "+ PlayerPrefs.GetInt ("CurrentPlanet") + " " + PlayerPrefs.GetInt ("AttackingPlayer"));
			planets [PlayerPrefs.GetInt ("CurrentPlanet")].ship = PlayerPrefs.GetInt ("AttackingPlayer");
		}
		//PlayerPrefs.DeleteKey ("FirstRun");
		if (!PlayerPrefs.HasKey ("FirstRun")) {
						Debug.Log ("First Time!");
						firstTime = true;
						PlayerPrefs.SetInt ("FirstRun", 1);
						PlayerPrefs.SetInt ("CurrentPlanet", 23);
				} else {
						firstTime = false;
						Debug.Log ("not first time");
				}
	}
	
	// Update is called once per frame
	void Update () {
		if (!firstTime) {
						PlanetStatsScript[] planets = GameObject.Find ("Planets").GetComponentsInChildren<PlanetStatsScript> ();
						int owningPlayer = 0;
			
						for (int i = 0; i < numPlanets; i++) {
							if (PlayerPrefs.HasKey ("Planet" + i)) {
								planets [i].occupy = PlayerPrefs.GetInt ("Planet" + i);
							} else {
								planets [i].occupy = 0;
							}
							planets[i].ship = 0;
						}
						
						if (PlayerPrefs.HasKey ("CurrentPlanet") && PlayerPrefs.HasKey ("AttackingPlayer")) {
								planets [PlayerPrefs.GetInt ("CurrentPlanet")].ship = PlayerPrefs.GetInt ("AttackingPlayer");
						}
				}
	}
}
