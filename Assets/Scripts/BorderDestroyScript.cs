using UnityEngine;
using System.Collections;

public class BorderDestroyScript : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		Destroy (other.gameObject);
	}
}
