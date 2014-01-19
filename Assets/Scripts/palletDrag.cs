using UnityEngine;
using System.Collections.Generic;

public class palletDrag : MonoBehaviour {

	public bool isPaint;
	public bool canDrag;
	public int type;
	public GameObject ShipPrefab;
	public GameObject shotType;
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
			portion.type = type;
			GameObject spawn = new GameObject("ShotSpawn");
			GameObject shotSpawn = new GameObject();
//			GameObject shot = new GameObject("Testshot");
//			Vector3 shotPos = new Vector3(4.8f, 1f, 0f);
//			Quaternion shotRot = new Quaternion(0, 0, 0, 0);
//			Vector3 shotScale = new Vector3(.2f, .2f, 1f);
//			shot.transform.position = shotPos;
//			shot.transform.rotation = shotRot;
//			shot.transform.localScale = shotScale;
//			Vector3[] vertices = new Vector3[4];	
//			vertices[0] = new Vector3(-10.0f, 0.0f, 0.0f);
//			vertices[1] = new Vector3(10.0f, 0.0f, 0.0f);
//			vertices[2] = new Vector3(-10.0f, 50.0f, 0.0f);
//			vertices[3] = new Vector3( 10.0f, 50.0f, 0.0f);
//			shot.AddComponent<MeshFilter>().mesh.vertices = vertices;
//			MeshRenderer rend = shot.AddComponent<MeshRenderer>();
//			rend.materials = new Material[1];
//			rend.materials[0] = new Material("Shader \"Alpha Additive\" {" +
//			                                 "Properties { _Color (\"Main Color\", Color) = (1,1,1,0) }" +
//			                                 "SubShader {" +
//			                                 "	Tags { \"Queue\" = \"Transparent\" }" +
//			                                 "	Pass {" +
//			                                 "		Blend One One ZWrite Off ColorMask RGB" +
//			                                 "		Material { Diffuse [_Color] Ambient [_Color] }" +
//			                                 "		Lighting On" +
//			                                 "		SetTexture [_Dummy] { combine primary double, primary }" +
//			                                 "	}" +
//			                                 "}" +
//			                                 "}");
//			rend.castShadows = false;
//			rend.receiveShadows = false;
//			Instantiate (shot, shot.transform.position, shot.transform.rotation);
			if(type==1) {
				shotSpawn = Instantiate (spawn, clone.transform.position, clone.transform.rotation) as GameObject;
				shotSpawn.transform.parent = clone.transform;
			} else if(type==2) {
				shotSpawn = Instantiate (spawn, clone.transform.position, clone.transform.rotation) as GameObject;
				shotSpawn.transform.parent = clone.transform;
			} else if(type==3) {
				shotSpawn = Instantiate (spawn, clone.transform.position, clone.transform.rotation) as GameObject;
				shotSpawn.transform.parent = clone.transform;
			}
			if(type==1 || type==2 || type==3) {
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
