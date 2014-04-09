using UnityEngine;
using System.Collections;

public class TurnRedScript : MonoBehaviour {

	public Texture red;
	public Texture gray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameControlScript.currentPlayer == 2) {
			guiTexture.texture = red;
				}
		else if (GameControlScript.currentPlayer == 1) {
			guiTexture.texture = gray;
		}
	
	}
}
