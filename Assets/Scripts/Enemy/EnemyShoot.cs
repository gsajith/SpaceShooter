using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public GameObject shot;
	public float firerate;
	private float nextshot = 0.0F;

	void Update(){
		if (Time.time > nextshot) {
			nextshot = firerate+Time.time;
			Instantiate (shot, transform.position, transform.rotation);

		}

	}
}
