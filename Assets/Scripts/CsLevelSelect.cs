using UnityEngine;
using System.Collections;

public class CsLevelSelect : MonoBehaviour {

	public GameObject LevelObject;
	public GameObject TutorialObject;
	public GameObject EasyLevel;
	public GameObject NormalLevel;
	public GameObject HardLevel;
	public GameObject Interface;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		LevelObject.SetActive (true);
		Interface.SendMessage ("ReceiveFunction");
		TutorialObject.SetActive (false);
		gameObject.SetActive (false);
	}


}
