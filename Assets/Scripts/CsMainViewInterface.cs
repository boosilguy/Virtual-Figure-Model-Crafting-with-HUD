using UnityEngine;
using System.Collections;

public class CsMainViewInterface : MonoBehaviour {

	public GameObject EasyLevel;
	public GameObject NormalLevel;
	public GameObject HardLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ReceiveFunction()
	{
		StartCoroutine ("activeBox");
	}

	IEnumerator activeBox()
	{
		yield return new WaitForSeconds (2);

		EasyLevel.GetComponent<BoxCollider> ().enabled = true;
		NormalLevel.GetComponent<BoxCollider> ().enabled = true;
		HardLevel.GetComponent<BoxCollider> ().enabled = true;
	}
}
