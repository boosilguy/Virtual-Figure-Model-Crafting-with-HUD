using UnityEngine;
using System.Collections;

public class CsAdvancedMuminSceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		Application.LoadLevel("MuminScene");
	}
}
