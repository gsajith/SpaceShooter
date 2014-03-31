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

		//Instantiate(palletDrag.ShipPrefab, palletDrag.ShipPrefab.transform.position, Quaternion.identity);
		GameObject obj = (GameObject)EditorUtility.InstantiatePrefab (prefab);
		//obj.transform.position = prefab.transform.position;
		//obj.transform.rotation = prefab.transform.rotation;
		//obj.transform.parent = prefab.transform.parent;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
