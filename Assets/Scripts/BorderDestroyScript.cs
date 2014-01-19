using UnityEngine;
using System.Collections;

public class BorderDestroyScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		}
	void OnTriggerExit2D(Collider2D other) {
		Destroy (other.gameObject);
	}
}
