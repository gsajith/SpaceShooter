using UnityEngine;
using System.Collections.Generic;

public class palletDrag : MonoBehaviour {

	public bool isPaint;
	public bool canDrag;
	void Start() {

	}
	void OnMouseDown() {
		if(canDrag) {
			GameObject original = this.gameObject;
			Vector3 pos = original.transform.position;
			pos.y = pos.y + .01f;
			GameObject clone = Instantiate(original, pos, original.transform.rotation) as GameObject;
			MoveBlock script = clone.GetComponent<MoveBlock> ();
			script.canMove = true;
			palletDrag colorScript = clone.GetComponent<palletDrag>();
			colorScript.canDrag = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
