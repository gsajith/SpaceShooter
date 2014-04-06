using UnityEngine;
using System.Collections;

public class enemyMPDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (GameControlScript.enemyMP.ToString ()) + "(+" + (GameControlScript.enemyMPAdd.ToString ()) + ")";
		guiText.color = Color.red;
	
	}
}
