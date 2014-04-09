using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public bool trigger;
	float wait_timer;

	void Start() {
		wait_timer = 0;
	}

	void Update() {
		if(trigger) {
			if(wait_timer<3f)
				wait_timer+=Time.deltaTime;
			else
				Application.LoadLevel("GameScene");
		}
	}
}

