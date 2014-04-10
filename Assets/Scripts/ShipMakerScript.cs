using UnityEngine;
using System.Collections;
using System;

public class ShipMakerScript : MonoBehaviour {

	static public ArrayList shipParts = new ArrayList();
	
	public GameObject ShipPrefab;

	// Use this for initialization
	void Start () {
		ShipPrefab = this.gameObject;
		int i = 0;
		int currentPlayer = 1;
		if(PlayerPrefs.HasKey ("CurrentPlayer")) {
			currentPlayer = PlayerPrefs.GetInt ("CurrentPlayer");
		}
		shipParts.Clear ();
		while (PlayerPrefs.HasKey (currentPlayer+"ShipPart"+i)) {
			Debug.Log ("loop");
			int type = PlayerPrefs.GetInt (currentPlayer+"ShipPart"+i+"Type");
			Debug.Log ("part " + i + " has type " + type);
			GameObject original = findObjectFromType (type);
			if(original.GetComponent<MoveBlock>() == null) Debug.Log (original.ToString() + " NULL MOVEBLOCK!");
			Vector3 pos = new Vector3(PlayerPrefs.GetFloat (currentPlayer+"ShipPart"+i+"LocX"),
			                          PlayerPrefs.GetFloat (currentPlayer+"ShipPart"+i+"LocY"),
			                          0f);
			GameObject clone = Instantiate(original, pos, original.transform.rotation) as GameObject;
			clone.transform.parent = ShipPrefab.transform;
			MoveBlock script = clone.GetComponent<MoveBlock> ();
			script.canMove = true;
			
			palletDrag colorScript = clone.GetComponent<palletDrag>();
			colorScript.canDrag = false;
			
			
			colorScript.portion = Instantiate (GameObject.Find ("Ship").GetComponent<ShipPart>(), pos, GameObject.Find ("Ship").GetComponent<ShipPart>().transform.rotation) as ShipPart;
			colorScript.portion.obj = clone;
			
			float gridx = (pos.x + 2f)*2f; 
			float gridy = (pos.y + 2f)*2f;
			Vector2 position = new Vector2(gridx, gridy);
			colorScript.portion.loc = new Vector2(pos.x, pos.y);
			colorScript.portion.type = type;
			
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
					pms.shots.Add (findShotTypeFromType(type));
				}
			} else {
				Destroy (spawn);
				Destroy (shotSpawn);
			}

			ShipMakerScript.shipParts.Add(colorScript.portion);
			i++;
		}
	}

	void Update() {
		if(Input.GetKey (KeyCode.F1)) {
			PlayerPrefs.DeleteAll();
		}
	}
	private GameObject findShotTypeFromType(int type) {
		return findObjectFromType (type).GetComponent<palletDrag> ().shotType;
	}

	private GameObject findObjectFromType(int type) {
		switch (type)
		{
		case 0:
			return GameObject.Find ("ShipBody");
			break;
		case 1:
			return GameObject.Find ("GunForward");
			break;
		case 2:
			return GameObject.Find ("GunRight");
			break;
		case 3:
			return GameObject.Find ("GunLeft");
			break;
		case 4:
			return GameObject.Find ("OrangeBody");
			break;
		case 5:
			return GameObject.Find ("YellowBody");
			break;
		default:
			return GameObject.Find ("ShipBody");
			break;
		}
	}
}
