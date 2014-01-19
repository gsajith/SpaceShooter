using UnityEngine;
using System.Collections;

public class Camera_PanForward : MonoBehaviour {

	//public float speedMult = 0;

	void Update(){
		this.transform.Translate (Vector3.up * Time.deltaTime, Space.World);
	}
}
