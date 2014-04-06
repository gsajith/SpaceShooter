using UnityEngine;
using System.Collections;

public class MPDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (GameControlScript.playerMP.ToString()) + "(+" + (GameControlScript.playerMPAdd.ToString()) + ")";
	
	}
}
