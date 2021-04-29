using UnityEngine;
using System.Collections;

public class CsAdvancedChoiceScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll)
	{
		Application.LoadLevel ("AdvancedChoiceScene");
	}
}
