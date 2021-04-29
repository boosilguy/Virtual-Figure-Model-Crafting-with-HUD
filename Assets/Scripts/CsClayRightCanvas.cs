using UnityEngine;
using System.Collections;

public class CsClayRightCanvas : MonoBehaviour {

	public GameObject Component;
	public GameObject Tools;
	public GameObject Parete;
	public GameObject ComponentBtn;
	public GameObject ToolsBtn;
	public GameObject PareteBtn;
    public GameObject Active;

	// Use this for initialization
	void Start () {
          
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ReceiveRightCanvasFunction(int receive)
	{
		if (receive == 1) {
			Component.SetActive (true);
			Tools.SetActive (false);
			Parete.SetActive (false);
		}
		else if (receive == 2) {
			Component.SetActive (false);
			Tools.SetActive (true);
			Parete.SetActive (false);
		}
		else if (receive == 3) {
			Component.SetActive (false);
			Tools.SetActive (false);
			Parete.SetActive (true);
		}
		ComponentBtn.GetComponent<BoxCollider> ().enabled = false;
		ToolsBtn.GetComponent<BoxCollider> ().enabled = false;
		PareteBtn.GetComponent<BoxCollider> ().enabled = false;
		StartCoroutine ("ColliderActive");

	}

	IEnumerator ColliderActive()
	{
		yield return new WaitForSeconds (2);

		ComponentBtn.GetComponent<BoxCollider> ().enabled = true;
		ToolsBtn.GetComponent<BoxCollider> ().enabled = true;
		PareteBtn.GetComponent<BoxCollider> ().enabled = true;
	}
}
