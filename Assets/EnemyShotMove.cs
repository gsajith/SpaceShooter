using UnityEngine;
using System.Collections;

public class EnemyShotMove : MonoBehaviour {

	public float speed = 10F;
	public float damage = 1F;
	public Vector2 direction = new Vector2(1,0);

	void Start(){
				collider.enabled = false;
		}
	void OnTriggerEnter2D(Collider2D other){
		if (other.isTrigger) {
			//takeDamage(damage);
			Destroy (this);
		}

	}

}
