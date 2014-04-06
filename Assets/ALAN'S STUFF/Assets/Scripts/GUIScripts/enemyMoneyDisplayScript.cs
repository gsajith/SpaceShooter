using UnityEngine;
using System.Collections;

public class enemyMoneyDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (GameControlScript.enemyMoney.ToString ()) + "(+" + (GameControlScript.enemyMoneyAdd.ToString ()) + ")";
		guiText.color = Color.red;
	
	}
}
