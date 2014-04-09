using UnityEngine;
using System.Collections;

public class UpgradeButtonScript : MonoBehaviour {

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

	void OnMouseDown(){
		Application.LoadLevel ("Menu");
	}
}
