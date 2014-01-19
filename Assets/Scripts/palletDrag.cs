using UnityEngine;
using System.Collections.Generic;

public class palletDrag : MonoBehaviour {

	public bool isPaint;
	public bool canDrag;
	public GameObject ShipPrefab;
	void Start() {

	}
	void OnMouseDown() {
		if(canDrag) {
			GameObject original = this.gameObject;
			Vector3 pos = original.transform.position;
			pos.y = pos.y + .01f;
			GameObject clone = Instantiate(original, pos, original.transform.rotation) as GameObject;
			clone.transform.parent = ShipPrefab.transform;
			MoveBlock script = clone.GetComponent<MoveBlock> ();
			script.canMove = true;

			palletDrag colorScript = clone.GetComponent<palletDrag>();
			colorScript.canDrag = false;

			ShipPart portion = new ShipPart();
			portion.obj = clone;

			float gridx = (pos.x + 2f)*2f; 
			float gridz = (pos.z + 2f)*2f;
			Vector2 position = new Vector2(gridx, gridz);
			portion.loc = position;

			int type = 0;

			ShipMakerScript.shipParts.Add(portion);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
