using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {
	public bool activated;
	public float hp;
	int timer = 3;
	// Use this for initialization
	void Start () {
		activated = false;
		hp = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated) {
			if(transform.position.y > 4) {
				Vector2 temp = transform.position;
				temp.y -= 0.3f;
				transform.position = temp;
			}
			if(hp <= 0) {
				waitForSecs(3);
				Application.LoadLevel(1);
			}
		}
	}
	
	IEnumerator waitForSecs(int secs) {
		yield return new WaitForSeconds (secs);
	}

	void OnTriggerEnter2D(Collider2D other) {
		hp-=1f;
	}
}
