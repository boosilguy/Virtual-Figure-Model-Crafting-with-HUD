using UnityEngine;
using System.Collections;

public class CsSelectBack : MonoBehaviour {

	public string SceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter()
	{
		Application.LoadLevel (SceneName);
	}
}
