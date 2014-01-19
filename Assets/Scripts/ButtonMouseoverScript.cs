using UnityEngine;
using System.Collections;

public class ButtonMouseoverScript : MonoBehaviour {

	public Sprite sprite;
	public Sprite mouseoverSprite;
	public GameObject particles;
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
		
		Application.LoadLevel(sceneNum);
		
	}

}
