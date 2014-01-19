using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

void onCollider2D(Collider2D other){
		Destroy (other);

	}
}
