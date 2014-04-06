using UnityEngine;
using System.Collections;

public class MoneyDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = (GameControlScript.playerMoney.ToString()) + "(+" + (GameControlScript.playerMoneyAdd.ToString()) + ")";

	}
}
