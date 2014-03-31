using UnityEngine;
using System.Collections;

public class GridBuilder {
	public static float botLeftX;
	public static float botLeftY;
	public static float width;
	public static float height;
	public static int xGridSize;
	public static int yGridSize;

	/*
	 *  Initializes grid 
	 *  Called when user calls new GridBuilder();
	 *  Doesn't set any of the grid parameters
	 */
	void Start () {
	}

	/*
	 *  Position the grid in global X and Y coordinates
	 *  Position corresponds to bottom left corner of grid
	 */
	public void positionGrid(float botLeftX, float botLeftY) {
		GridBuilder.botLeftX = botLeftX;
		GridBuilder.botLeftY = botLeftY;
	}

	/*
	 *  Size the grid in terms of width and height
	 *  Grid expands out from bottom left corner
	 */
	public void sizeGrid(float width, float height) {
		if(width > 0) GridBuilder.width = width;
		else GridBuilder.width = 1;

		if(height > 0) GridBuilder.height = height;
		else GridBuilder.height = 1;
	}

	/*
	 *  Specify number of rows and columns in the grid
	 *  These can then be referred to as zero-indexed rows
	 *  and columns
	 */
	public void specifyGrid(int xGridSize, int yGridSize) {
		if(xGridSize > 0) GridBuilder.xGridSize = xGridSize;
		else GridBuilder.xGridSize = 1;
		if(yGridSize > 0) GridBuilder.yGridSize = yGridSize;
		else GridBuilder.yGridSize = 1;
	}

	/*
	 *  Place object into certain cell in the grid
	 *  Given row and column number of the cell, as well as 
	 *  Z-position to place the object, calculates the global
	 *  X and Y coordinates to place the object at
	 */
	public Vector3 placeOnGrid(int xGridPos, int yGridPos, float zPos = 0.0f) {
		Vector3 pos = new Vector3 ();
		pos.z = zPos;
		pos.x = botLeftX + xGridPos * (width / xGridSize) + width/(2.0f*xGridSize);
		pos.y = botLeftY + yGridPos * (height / yGridSize) + height / (2.0f * yGridSize);
		pos = alignToGrid (pos);
		return pos;
	}

	/*
	 *  Checks if spherical region within grid cell size at
	 *  given position is free of colliders of tag "tag".
	 *  If so, return true.  Else, return false.  Used for
	 *  collision checking when doing grid movement.
	 */
	public bool checkPos(Vector3 position, string tag) {
		float rad;
		if(height/yGridSize <= width/xGridSize) {
			rad = height/(2.0f*yGridSize);
		} else {
			rad = width/(2.0f*xGridSize);
		}
		
		Collider[] hitColliders = Physics.OverlapSphere(position, rad);
		int i = 0;
		while(i < hitColliders.Length) {
			if(hitColliders[i].tag == tag) return false;			
			i++;
		}
		return true;
	}

	/*
	 *  Align given Vector3 to the grid.  Places it in nearest
	 *  valid grid spot if not within grid bounds, and snaps it
	 *  to the grid if within grid bounds.
	 */
	public Vector3 alignToGrid(Vector3 pos) {
		if(pos.x < botLeftX && pos.y < botLeftY) {
			pos.x = botLeftX + width/(2.0f*xGridSize);
			pos.y = botLeftY + height/(2.0f*yGridSize);
		} else if(pos.x < botLeftX && pos.y > botLeftY + height) {
			pos.x = botLeftX + width/(2.0f*xGridSize);
			pos.y = botLeftY + height - height/(2.0f*yGridSize);
		} else if(pos.x > botLeftX + width && pos.y < botLeftY) {
			pos.x = botLeftX + width - width/(2.0f*xGridSize);
			pos.y = botLeftY + height/(2.0f*yGridSize);
		} else if(pos.x > botLeftX + width && pos.y > botLeftY + height) {
			pos.x = botLeftX + width - width/(2.0f*xGridSize);
			pos.y = botLeftY + height - height/(2.0f*yGridSize);
		} else if(pos.x < botLeftX) {
			pos.x = botLeftX + width/(2.0f*xGridSize);
			//align y to the nearest height/yGridSize
			pos.y = Mathf.Ceil(pos.y * (yGridSize/height)) / (yGridSize/height) - height/(2.0f*yGridSize);
		} else if(pos.x > botLeftX + width - width/(2.0f*xGridSize)) {
			pos.x = botLeftX + width - width/(2.0f*xGridSize);
			pos.y = Mathf.Ceil(pos.y * (yGridSize/height)) / (yGridSize/height) - height/(2.0f*yGridSize);
		} else if(pos.y < botLeftY + height/(2.0f*yGridSize)) {
			pos.x = Mathf.Ceil (pos.x * (xGridSize/width)) / (xGridSize/width) - width/(2.0f*xGridSize);
			pos.y = botLeftY + height/(2.0f*yGridSize);
		} else if(pos.y > botLeftY + height - height/(2.0f*yGridSize)) {
			pos.x = Mathf.Ceil (pos.x * (xGridSize/width)) / (xGridSize/width) - width/(2.0f*xGridSize);
			pos.y = botLeftY + height - height/(2.0f*yGridSize);
		} else {
			pos.x = (Mathf.Ceil (pos.x * (xGridSize/width)) / (xGridSize/width)) - width/(2.0f*xGridSize);
			pos.y = (Mathf.Ceil (pos.y * (yGridSize/height)) / (yGridSize/height)) - height/(2.0f*yGridSize);
		}
		return pos;
	}

	/*
	 *  Checks if given Vector3 is within the grid bounds
	 */
	public bool inGridBounds(Vector3 pos) {
		if(pos.x >= botLeftX && pos.x <= botLeftX + width && pos.y >= botLeftY && pos.y <= botLeftY + height) {
			return true;
		} else {
			return false;
		}
	}

	/*
	 *  Moves given Vector3 to left/right/up/down by 1 cell, returns
	 *  a new position based on grid size.
	 * 
	 * *********************  MOVEMENT FUNCTIONS *********************
	 */
	public Vector3 moveLeft(Vector3 pos) {
		pos.x = pos.x - width / xGridSize;
		pos = alignToGrid (pos);
		return pos;
	}

	public Vector3 moveRight(Vector3 pos) {
		pos.x = pos.x + width / xGridSize;
		pos = alignToGrid (pos);
		return pos;
	}

	public Vector3 moveUp(Vector3 pos) {
		pos.y = pos.y + height / yGridSize;
		pos = alignToGrid (pos);
		return pos;
	}

	public Vector3 moveDown(Vector3 pos) {
		pos.y = pos.y - height / yGridSize;
		pos = alignToGrid (pos);
		return pos;
	}

	/* *************************************************************** */



	/*
	 *  Checks grid cell to the left/right/up/down to see if it is 
	 *  free of colliders with tag "tag".
	 * 
	 *  ********************* COLLISION CHECK FUNCTIONS ************** */
	public bool checkLeft(Vector3 pos, string tag) {
		pos.x = pos.x - width / xGridSize;
		return checkPos (pos, tag);
	}
	
	public bool checkRight(Vector3 pos, string tag) {
		pos.x = pos.x + width / xGridSize;
		return checkPos (pos, tag);
	}
	
	public bool checkUp(Vector3 pos, string tag) {
		pos.y = pos.y + height / yGridSize;
		return checkPos (pos, tag);
	}
	
	public bool checkDown(Vector3 pos, string tag) {
		pos.y = pos.y - height / yGridSize;
		return checkPos (pos, tag);
	}
	/* ************************************************************** */

}













