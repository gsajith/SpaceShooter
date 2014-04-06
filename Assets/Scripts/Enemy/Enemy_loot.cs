using UnityEngine;
using System.Collections;

public class Enemy_loot : MonoBehaviour {

	public float loot_rate;
	public GameObject loot;
	
	// Update is called once per frame
	void Start () {
		Instantiate (loot, this.transform.position, this.transform.rotation);
	}

	void Update() {
		Vector3 pos = this.transform.position;
		pos.y -= 0.02f;
		this.transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "player")
			Destroy(gameObject);
	}
}
