using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public GameObject shot;
	public float firerate;
	private float nextshot = 0.5F;
	private float thisTime = 0.0F;

	void Update(){
		thisTime += Time.deltaTime;
		if (thisTime > nextshot) {
			nextshot = firerate+thisTime+Random.value*.5f;
			Instantiate (shot, transform.position, transform.rotation);
		}
	}
}
