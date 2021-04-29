using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DrawLineInSceneRed : MonoBehaviour {
	public bool btnInit = false;
	List<Vector3> posList = new List<Vector3>();
	int length = 0;
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		InitData ();
		DrawLineInScene ();
	}

	void DrawLineInScene(){
		AddingPos();
		length = posList.Count;
		if (length == 1) {

		} else {
			for(int index=0;index<(length-1);index++)
				Debug.DrawLine (posList [index], posList [index + 1], Color.blue);
		}
	}

	void AddingPos(){
		posList.Add (this.transform.position);
	}

	void InitData(){
		if (btnInit == true) {
			CalAllDistances ();
			length = 0;
			posList.Clear ();
			btnInit = false;
		}
	}

	void CalAllDistances(){
		if (length != 0) {
			float xDis = 0;
			float yDis = 0;

			for (int index = 0; index < (length - 1); index++) {
				xDis = xDis + Math.Abs (posList [index].x - posList [index + 1].x);
				yDis = yDis + Math.Abs (posList [index].y - posList [index + 1].y);
			}

			Debug.Log ("All Distances (horizontal) : " + xDis);
			Debug.Log ("All Distances (vertical) : " + yDis);
		} else {
			Debug.Log ("Length is 0");
		}
	}
}
