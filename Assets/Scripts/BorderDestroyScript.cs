using UnityEngine;
using System.Collections;

public class BorderDestroyScript : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		SafeDestroy (other.gameObject);
	}

	void SafeDestroy(GameObject doomed) {
		if(doomed.transform.parent != null) {
			SafeDestroy(doomed.transform.parent.gameObject);
		} else {
			if(doomed.gameObject.ToString () != "PlayerPrefab(Clone) (UnityEngine.GameObject)") {
				Destroy(doomed);
			}
		}
	}
}
