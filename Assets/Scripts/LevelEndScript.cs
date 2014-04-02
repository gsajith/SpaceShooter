using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEndScript : MonoBehaviour {
	public List<GameObject> spawners = new List<GameObject> ();
	public Boss1 boss;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int enemiesLeft = 0;
		foreach(GameObject spawner in spawners) {
			spawnEntity[] spawns = spawner.GetComponents<spawnEntity>();
			foreach(spawnEntity spawn in spawns) {
				if(spawn != null) enemiesLeft += spawn.getNumLeft();
			}
		}
		Debug.Log (enemiesLeft);
		if(enemiesLeft == 0) {
			//Debug.Log ("level done!");	
			//waitForSecs(3);	
			//Application.LoadLevel(1);
			boss.activated = true;
		}
	}

	IEnumerator waitForSecs(int secs) {
		yield return new WaitForSeconds (secs);
	}
}
