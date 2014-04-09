using UnityEngine;
using System.Collections;

public class TurnGreenScript : MonoBehaviour {

	public Texture green;
	public Texture gray;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameControlScript.currentPlayer == 1) {
			guiTexture.texture = green;
		}
		else if (GameControlScript.currentPlayer == 2) {
			guiTexture.texture = gray;
		}
		
	}
}
