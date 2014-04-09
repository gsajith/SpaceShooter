using UnityEngine;
using System.Collections;

public class SkipTurnScript : MonoBehaviour {

	public Texture nonHighlight;
	public Texture highlight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		guiTexture.texture = highlight;
	}
	
	void OnMouseExit() {
		guiTexture.texture = nonHighlight;
	}

	void OnMouseDown()
	{
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
