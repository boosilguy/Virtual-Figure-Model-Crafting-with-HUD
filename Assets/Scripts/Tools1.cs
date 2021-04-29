using UnityEngine;
using System.Collections;

public class Tools1 : MonoBehaviour {

	public GameObject Interface;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll)
	{
		Interface.GetComponent<CsClayRightCanvas> ().SendMessage ("ReceiveRightCanvasFunction", 1);
	}

}
