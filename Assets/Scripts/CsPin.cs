﻿using UnityEngine;
using System.Collections;

public class CsPin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		transform.parent = GameObject.FindWithTag ("FixPoint").transform;
	}
}
