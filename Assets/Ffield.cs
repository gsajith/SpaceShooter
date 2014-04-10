using UnityEngine;
using System.Collections;

public class Ffield : MonoBehaviour {
	public GameObject lvlCtrl;
	public LevelController controlScript;
	bool enable;
	// Use this for initialization
	void Start () {
		lvlCtrl = GameObject.Find ("LevelController");
		controlScript = lvlCtrl.GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		enable = controlScript.forcefield_trigger;
		if(!enable)
			Destroy(gameObject);
	}
}
