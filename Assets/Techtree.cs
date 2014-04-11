using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Techtree : MonoBehaviour {
	public List<Techtree> pre_tech;
	public bool unlock;
	public bool bought;
	// Use this for initialization
	void Start () {
		unlock = true;
		bought = false;
	}
	
	// Update is called once per frame
	void Update () {
		unlock = true;
		if(pre_tech.Count!=0) {
			for(int i=0;i<pre_tech.Count;i++){
				if(!pre_tech[i].bought)
					unlock = false;
			}
		}
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)&&unlock){
			bought = true;
		}
	}
}
