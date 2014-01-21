using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	static public float score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<GUIText> ().text = ((int)score).ToString ();
	}
}
