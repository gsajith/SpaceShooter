using UnityEngine;
//using System.Collections;
using System;

public class MoveBlock : MonoBehaviour {
	public bool canMove;
	private bool instantiated = true;
	public MultidimensionalInt[] shipModel = new MultidimensionalInt[10];

	// Use this for initialization
	void Start () {
		for(int i = 0; i <= 8; i ++){
			for(int j = 0; j <= 8; j++){
				shipModel[i].intArray = new int[9];
				shipModel[i][j] = -1;
			}
		}
	}

	void OnMouseOver() {
		if(instantiated){
			//OnMouseDrag ();
			instantiated = false;
		}
	}

	void OnMouseDrag() {
		if(canMove) {
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			point.z = 0.0f;
			this.gameObject.transform.position = point;
		}
	}

	private float round(float x) {
		double hold = x / 0.5;
		int hold2 = (int)Math.Round (hold, 0);
		float hold3 = (float)(hold2 * 0.5);
		return hold3;
	}

	void OnMouseUp() {
		if(canMove) {
			
			Vector3 point = gameObject.transform.position;
			point.x = round (point.x);
			point.y = round (point.y);

			if(point.x <= -2.25f || point.x >= 2.25f
			   || point.y <= -1.25f || point.y >= 3.25f)
				{
				point.x = 0f;
				point.y = 3.8f;
				point.z = 0f;
				gameObject.transform.position = point;
				//GUI.Label(new Rect(-3,3,200,100), "Error placing component");
				//square is occupied, dont let them buy or place other parts
			}
			else
			{
				int modelX = (int)(2*(point.x) + 4.05f);
				int modelY = (int)(2*(point.y) + 2.05f);

				palletDrag copy = gameObject.GetComponent<palletDrag>();


				if(copy != null){
					if(modelX >= 0 && modelX <= 8 && modelY >= 0 && modelY <= 8)
					{
						if(LegalPart (modelX, modelY, copy.type, shipModel)){
							//shipModel[modelX].intArray = new int[9];
							shipModel[modelX][modelY] = copy.type;
							Debug.Log (modelX + ", " + modelY + " = " + shipModel[modelX][modelY]);
						}
					}

				}
				gameObject.transform.position = point;
			}
			if(this.gameObject.GetComponent<palletDrag>().portion != null) {
				if(ShipMakerScript.shipParts.Contains(this.gameObject.GetComponent<palletDrag> ().portion)) 
					ShipMakerScript.shipParts.Remove (this.gameObject.GetComponent<palletDrag> ().portion);
				this.gameObject.GetComponent<palletDrag>().portion.loc = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
				Debug.Log (this.gameObject.GetComponent<palletDrag>().portion.loc);
				ShipMakerScript.shipParts.Add (this.gameObject.GetComponent<palletDrag> ().portion);
			}

		}

	}
	// Update is called once per frame
	bool LegalPart (int x, int y, int type, MultidimensionalInt[] shipModel) {
		/*if(shipModel[x][y] == 0 || shipModel[x][y] == 1 || shipModel[x][y] == 2 || shipModel[x][y] == 3) {
			Debug.Log("Already a part there");
			return false;
		}*/
		//if(type == 0) {//Normal Ship parts
		//	if(
		if(type == 1) {//Up Turret
			if(shipModel[x][y-2] != 0){
				Debug.Log("Turret must be placed on a ship part");
				return false;
			}
		}/*
		if(type == 1) {//Up Turret
			if(
		
		if(Type == 2) {//Right Turret
			if(

		if(Type == 3) {//Left Turret
			if(*/
		return true;
	}
}
