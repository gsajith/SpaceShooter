using UnityEngine;
using System.Collections;

public class BossDead : MonoBehaviour {

	GameObject boss;

	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag ("boss");
		if(boss!=null)
			Debug.Log("Found a boss");
	}
	
	// Update is called once per frame
	void Update () {
		if(boss == null)
			Application.LoadLevel("GameScene");
	}
}
