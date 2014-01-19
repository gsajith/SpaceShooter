﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class ButtonMouseoverScript : MonoBehaviour {

	public Sprite sprite;
	public Sprite mouseoverSprite;
	public GameObject particles;
	public GameObject playerPrefab;
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
		var location = "Assets/PlayerPrefab.prefab";
		PrefabUtility.CreatePrefab(location, 
		                           playerPrefab, 
		                           ReplacePrefabOptions.ReplaceNameBased);
		Application.LoadLevel(sceneNum);
		
	}

}
