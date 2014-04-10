using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class ButtonMouseoverScript : MonoBehaviour {

	public Sprite sprite;
	public Sprite mouseoverSprite;
	public GameObject particles;
	public GameObject playerPrefab;
	public bool makePrefab;
	public int sceneNum;

	void OnMouseEnter() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = mouseoverSprite;
	}

	void OnMouseExit() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	void OnMouseDown() {
		GameObject newexplosion = (GameObject)Instantiate(particles,transform.position,transform.rotation);
		Destroy(newexplosion,1);
	}

	IEnumerator OnMouseUp(){
		yield return new WaitForSeconds(1);
		if(makePrefab){
			int currentPlayer = 1;
			if(PlayerPrefs.HasKey ("CurrentPlayer")) {
				currentPlayer = PlayerPrefs.GetInt ("CurrentPlayer");
			}
			int i = 0;
			while(PlayerPrefs.HasKey(currentPlayer+"ShipPart"+i)) {
				PlayerPrefs.DeleteKey (currentPlayer+"ShipPart"+i);
				PlayerPrefs.DeleteKey (currentPlayer+"ShipPart"+i+"LocX");
				PlayerPrefs.DeleteKey (currentPlayer+"ShipPart"+i+"LocY");
				PlayerPrefs.DeleteKey (currentPlayer+"ShipPart"+i+"Type");
				i++;
			}

			palletDrag[] drags = playerPrefab.GetComponentsInChildren<palletDrag>();
			foreach(palletDrag drag in drags) {
				Destroy(drag.collider);
				drag.canDrag = false;
			}
			MoveBlock[] moveBlocks = playerPrefab.GetComponentsInChildren<MoveBlock>();
			foreach(MoveBlock moveBlock in moveBlocks) {
				moveBlock.canMove = false;
			}
			i = 0;
			foreach(ShipPart part in ShipMakerScript.shipParts) {
				PlayerPrefs.SetInt (currentPlayer+"ShipPart"+i, 1);
				PlayerPrefs.SetFloat (currentPlayer+"ShipPart"+i+"LocX", part.loc.x );
				PlayerPrefs.SetFloat (currentPlayer+"ShipPart"+i+"LocY", part.loc.y );
				PlayerPrefs.SetInt (currentPlayer+"ShipPart"+i+"Type", part.type);
				Debug.Log ("Setting part " + i + " to type " + part.type);
				i++;

				if(part.obj != null) {
					DestroyImmediate(part.obj.collider);
					part.obj.tag = "Player";
					BoxCollider2D bc =part.obj.AddComponent ("BoxCollider2D") as BoxCollider2D;
					Vector3 t = bc.transform.localScale;
					t.y = 20;
					bc.transform.localScale = t;
				} 
			}
			var location = "Assets/Resources/PlayerPrefab.prefab";
			PrefabUtility.CreatePrefab(location, 
			                           playerPrefab, 
			                           ReplacePrefabOptions.ReplaceNameBased);
			//DontDestroyOnLoad(playerPrefab);
		}
		Application.LoadLevel(sceneNum);
		
	}

}
