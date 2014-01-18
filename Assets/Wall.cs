using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

void onTriggerEnter2D(Collider2D other){
		Destroy (other);

	}
}
