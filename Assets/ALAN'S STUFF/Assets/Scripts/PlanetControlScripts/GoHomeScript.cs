using UnityEngine;
using System.Collections;

public class GoHomeScript : MonoBehaviour {

	public int playerHome;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControlScript.goHome == playerHome  ) {

			GetComponent<PlanetStatsScript>().ship = playerHome;
			PlayerPrefs.SetInt ("Player"+playerHome+"Planet", GetComponent<PlanetStatsScript>().planetNum);

			GameControlScript.goHome = 0;
				}


	
	}
}
