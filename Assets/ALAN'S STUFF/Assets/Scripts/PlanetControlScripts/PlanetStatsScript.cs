﻿using UnityEngine;
using System.Collections;

public class PlanetStatsScript : MonoBehaviour {

	public int occupy =0;
	public int ship = 0;
	public bool destination = false;
	public string planetName = "";
	public int planetNum = 0;

	public Sprite nonHighlight;
	public Sprite highlight;

	public int MP;
	public int Money;
	public int Mineral;

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
		if (occupy == GameControlScript.currentPlayer && 
		    ship == GameControlScript.currentPlayer &&
		    destination == false) {
			
			GameControlScript.select = true;
			GameControlScript.selectedPlanet = gameObject;
			
			GetComponentInChildren<UpRightScript>().showArrow = true;
			GetComponentInChildren<UpLeftScript>().showArrow = true;
			GetComponentInChildren<DownRightScript>().showArrow = true;
			GetComponentInChildren<DownLeftScript>().showArrow = true;
		}
		
		if (destination == true && GameControlScript.turnOver == false/***&& Ship & Occupation Status Will Set Up the Battle***/) {
			//***The Following Settings Depend on the Outcome of the Battle***//

			/*if(ship != GameControlScript.currentPlayer && ship != 0)
			{
				if(GameControlScript.currentPlayer == 1)
				{
					GameControlScript.goHome = 2;
				}
				if(GameControlScript.currentPlayer == 2)
				{
					GameControlScript.goHome = 1;
				}
			}*/

			if(occupy != GameControlScript.currentPlayer && occupy != 0)
			{
				if(occupy != 0) {
					PlayerPrefs.SetInt ("AttackingPlayer", GameControlScript.currentPlayer);
					PlayerPrefs.SetInt ("AttackingPlanet", planetNum);
					Application.LoadLevel(4);
				} 
			} else {			
				PlayerPrefs.SetInt ("Player"+GameControlScript.currentPlayer+"Planet", planetNum);
				PlayerPrefs.SetInt ("Planet"+planetNum, GameControlScript.currentPlayer);
				ship = GameControlScript.currentPlayer; 
				occupy = GameControlScript.currentPlayer; 
			}
			destination = false; 
			
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
			
			GameControlScript.turnOver = true;
			if(GameControlScript.currentPlayer == 1)
			{
				GameControlScript.currentPlayer = 2;
				GameControlScript.turnOver = false;
				GameControlScript.updateEnemyRes();
			}
			else if(GameControlScript.currentPlayer == 2)
			{
				GameControlScript.currentPlayer = 1;
				GameControlScript.turnOver = false;
				GameControlScript.updatePlayerRes();
			}
		}		
	}
}
