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
		}
		numPlanets = i;

		if (!PlayerPrefs.HasKey ("Planet23"))
			PlayerPrefs.SetInt ("Planet23", 1);
		if (!PlayerPrefs.HasKey ("Planet2"))
			PlayerPrefs.SetInt ("Planet2", 1);
		if (!PlayerPrefs.HasKey ("Player1Planet"))
			PlayerPrefs.SetInt ("Player1Planet", 23);
		if (!PlayerPrefs.HasKey ("Player2Planet"))
			PlayerPrefs.SetInt ("Player2Planet", 2);
		//if(!PlayerPrefs.HasKey ("CurrentPlanet")) PlayerPrefs.SetInt ("CurrentPlanet", 23);
		/*PlayerPrefs.DeleteKey ("FirstRun");
		if (!PlayerPrefs.HasKey ("FirstRun")) {
						Debug.Log ("First Time!");
						firstTime = true;
						PlayerPrefs.SetInt ("FirstRun", 1);
				} else {
						firstTime = false;
						Debug.Log ("not first time");
				}*/
	}
	
	// Update is called once per frame
	void Update () {
			PlanetStatsScript[] planets = GameObject.Find ("Planets").GetComponentsInChildren<PlanetStatsScript> ();
			

			for (int i = 0; i < numPlanets; i++) {
				if (PlayerPrefs.HasKey ("Planet" + i)) {
					Debug.Log ("Planet"+i+" exists = " + PlayerPrefs.GetInt ("Planet"+i));
					planets [i].occupy = PlayerPrefs.GetInt ("Planet" + i);
				} else {
					Debug.Log ("Planet"+i+" doesn't exist");
					planets [i].occupy = 0;
				}
				planets[i].ship = 0;
			}
			
			if (PlayerPrefs.HasKey ("Player1Planet")) {
				planets [PlayerPrefs.GetInt ("Player1Planet")].ship = 1;
			}
			if (PlayerPrefs.HasKey ("Player2Planet")) {
				planets [PlayerPrefs.GetInt ("Player2Planet")].ship = 2;
			}
		if(Input.GetKey (KeyCode.F1)) {
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt ("Planet23", 1);
			PlayerPrefs.SetInt ("Planet2", 2);
			PlayerPrefs.SetInt ("Player1Planet", 23);
			PlayerPrefs.SetInt ("Player2Planet", 2);
		}
	}
}
