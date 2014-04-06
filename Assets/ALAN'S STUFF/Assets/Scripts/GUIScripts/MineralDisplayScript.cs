using UnityEngine;
using System.Collections;

public class MineralDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

						guiText.text = (GameControlScript.playerMineral.ToString ()) + "(+" + (GameControlScript.playerMineralAdd.ToString ()) + ")";
						guiText.color = Color.green;
				
	
	}
}
