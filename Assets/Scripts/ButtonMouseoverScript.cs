using UnityEngine;
using UnityEditor;
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
			palletDrag[] drags = playerPrefab.GetComponentsInChildren<palletDrag>();
			foreach(palletDrag drag in drags) {
				drag.canDrag = false;
			}
			MoveBlock[] moveBlocks = playerPrefab.GetComponentsInChildren<MoveBlock>();
			foreach(MoveBlock moveBlock in moveBlocks) {
				moveBlock.canMove = false;
			}

			foreach(ShipPart part in ShipMakerScript.shipParts) {
				Debug.Log (part.obj.GetComponent<BoxCollider>());
				DestroyImmediate(part.obj.collider);
				BoxCollider2D bc =part.obj.AddComponent ("BoxCollider2D") as BoxCollider2D;
				Vector3 t = bc.transform.localScale;
				t.y = 20;
				bc.transform.localScale = t;
			}
			var location = "Assets/PlayerPrefab.prefab";
			PrefabUtility.CreatePrefab(location, 
			                           playerPrefab, 
			                           ReplacePrefabOptions.ReplaceNameBased);

		}
		Application.LoadLevel(sceneNum);
		
	}

}
