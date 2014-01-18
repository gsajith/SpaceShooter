using UnityEngine;
using System.Collections;

public class LogoSpinScript : MonoBehaviour {
	public float xRot, yRot, zRot;
	float rotAmount = 90.0f;
	public GameObject particles;
	void Update() {
		transform.Rotate (xRot*rotAmount * Time.deltaTime, 
		                  yRot*rotAmount * Time.deltaTime, 
		                  zRot*rotAmount * Time.deltaTime);

	}

	void OnMouseEnter() {
		GameObject newParticles = (GameObject)Instantiate (particles, transform.position, new Quaternion (0, 0, 0, 0));
		Destroy (newParticles, 1);

	}
	// Use this for initialization
	void Start () {
	
	}
}
