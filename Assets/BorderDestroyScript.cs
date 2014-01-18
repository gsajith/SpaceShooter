using UnityEngine;
using System.Collections;

public class BorderDestroyScript : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy (other.gameObject);
	}
}
