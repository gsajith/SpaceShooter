using UnityEngine;
using System.Collections.Generic;

public class changeColor : MonoBehaviour {

	public bool isPaint;
	void Start() {

	}
	void OnMouseDown() {
		//GameObject clone = Instantiate((Object)this, this.transform.position, this.transform.rotation);
		//MoveBlock blocky = new MoveBlock();
		//blocky.canMove = true;
		//clone.AddComponent (blocky);
		if (isPaint) {
			renderer.material.color = holdColor.hold;
		} else {
			holdColor.hold = renderer.material.color;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
