using UnityEngine;
using System.Collections;

public class Camera_PanForward : MonoBehaviour {

	public float limit = 10;
	public float speedMult = 1;

	void Update(){
				if (this.transform.position.y < limit) {
						this.transform.Translate (speedMult * Vector3.up * Time.deltaTime, Space.World);
				}
		}
}
