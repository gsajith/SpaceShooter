using UnityEngine;
using System.Collections;

public class enemyMineralDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (GameControlScript.enemyMineral.ToString ()) + "(+" + (GameControlScript.enemyMineralAdd.ToString ()) + ")";
		guiText.color = Color.red;
	
	}
}
