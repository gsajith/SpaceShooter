using UnityEngine;
using System.Collections.Generic;

public class palletDrag : MonoBehaviour {

	public bool isPaint;
	public bool canDrag;
	public int type;
	public GameObject ShipPrefab;
	public GameObject shotType;

	public void Start(){

	}

	void onMouseUp() {
		//make the portion stay attached to cursor until click
	}

	void OnMouseDown() {
		if(canDrag) {
			GameObject original = this.gameObject;
			Vector3 pos = new Vector3(0f, 3.8f, 0f);//original.transform.position;
			pos.z = 0.0f;
			GameObject clone = Instantiate(original, pos, original.transform.rotation) as GameObject;
			clone.transform.parent = ShipPrefab.transform;
			MoveBlock script = clone.GetComponent<MoveBlock> ();
			script.canMove = true;

			palletDrag colorScript = clone.GetComponent<palletDrag>();
			colorScript.canDrag = false;

			ShipPart portion = new ShipPart();
			portion.obj = clone;

			float gridx = (pos.x + 2f)*2f; 
			float gridy = (pos.y + 2f)*2f;
			Vector2 position = new Vector2(gridx, gridy);
			portion.loc = position;
			portion.type = type;

			GameObject spawn = new GameObject("ShotSpawn");
			GameObject shotSpawn = new GameObject();
			if(type==1 || type==2 || type==3) {
				shotSpawn = Instantiate (spawn, clone.transform.position, clone.transform.rotation) as GameObject;
				shotSpawn.transform.Rotate (90, 0, 0);
				shotSpawn.transform.parent = clone.transform;
				Vector3 spawnPos = shotSpawn.transform.position;
				if(type==1) spawnPos.y += 5.5f/20f;
				if(type==2) spawnPos.x += 5.5f/20f;
				if(type==3) spawnPos.x -= 5.5f/20f;
				shotSpawn.transform.position = spawnPos;

				PlayerMoveScript pms = ShipPrefab.GetComponent<PlayerMoveScript>();
				if(pms != null) {
					pms.shotSpawns.Add (shotSpawn.transform);
					pms.shots.Add (shotType);
				}
			} else {
				Destroy (spawn);
				Destroy (shotSpawn);
			}

			ShipMakerScript.shipParts.Add(portion);
		
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
