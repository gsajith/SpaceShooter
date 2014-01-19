﻿using UnityEngine;
using System.Collections;

public class mama_move : MonoBehaviour {

			//mama starts in top-center of map.
			
				//Move right -> Move right -> right diagonal corner, center top,
				//left diagonal corner, top right.  Repeat.
				private Vector2 direction = new Vector2(0,0);
		public float speed = 1;
		public float rightBound, leftBound;
		public float centerX = 3;
		public float centerY;
		private float distCenterX = 0;
		private float distCenterY = 0;
		void moveToWall(float bound, float v){
						if (bound > centerX) {
									while (transform.position.x < bound)
												rigidbody2D.velocity = new Vector2(speed,v);
							} else if (bound < centerX) {
									while (transform.position.x > bound)
												rigidbody2D.velocity = new Vector2(-speed, v);
							}
			}

		void Start(){
			movement ();
				}
		void moveToCenter(){
			float x, y;
			while (transform.position.x != centerX 
		          	       || transform.position.y != centerY){
						distCenterX = centerX - transform.position.x;
						distCenterY = centerY - transform.position.y;
						x = distCenterX / (Mathf.Abs(distCenterX));
			            y = distCenterY / (Mathf.Abs(distCenterY));
			           rigidbody2D.velocity = new Vector2(speed*x, speed*y);
							}
			}
		void movement(){
				//start by going to right wall
				while(true){
									moveToWall (rightBound, 0);
									//yield return new WaitForSeconds (2F);
										moveToWall (leftBound, 0);
									//yield return new WaitForSeconds (2F);
										moveToWall (rightBound, -1);
									//yield return new WaitForSeconds (2F);
										moveToWall (leftBound, 0);
									//yield return new WaitForSeconds (2F);
										moveToWall (rightBound, 1);
								//yield return new WaitForSeconds (2F);
										moveToCenter ();
							}

			}
	}
