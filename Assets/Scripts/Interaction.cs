using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
	public static bool iSwitch = false;
	static public float hudAngle = 0;
	public GameObject hud;
	public GameObject indexFinger;

	void Awake () {
		hud = this.gameObject;
	}

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		indexFinger = GameObject.FindGameObjectWithTag ("IndexFinger");
	}

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag("IndexFinger")) {
			hudAngle = hud.transform.eulerAngles.x;
			iSwitch = true;
		}
	}

	//float Interaction () {
	//	if(OnTriggerEnter == true){
	//
	//	}
	//}

	
}
