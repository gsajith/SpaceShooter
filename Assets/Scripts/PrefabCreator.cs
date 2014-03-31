using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class PrefabCreator : MonoBehaviour {
	public GameObject prefab;
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		GameObject obj = (GameObject)EditorUtility.InstantiatePrefab (prefab);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
