using UnityEngine;
//using System.Collections;
using System;

public class MoveBlock : MonoBehaviour {
	public bool canMove;
	private bool instantiated = true;
	public MultidimensionalInt[] shipModel = new MultidimensionalInt[10];

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseOver() {
		if(instantiated){
			OnMouseDrag ();
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
				Debug.Log (modelX + ", " + modelY);

				ShipPart copy = gameObject.GetComponent<ShipPart>();
				if(copy != null){
					if(modelX >= 0 && modelX <= 8 && modelY >= 0 && modelY <= 8)
					{
						shipModel[modelX].intArray = new int[9];
						shipModel[modelX][modelY] = copy.type; //portion.type.ToString();
					}
				}
				gameObject.transform.position = point;
			}

		}

	}
	// Update is called once per frame
	void Update () {

	}
}
