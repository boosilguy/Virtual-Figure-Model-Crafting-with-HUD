using UnityEngine;
using System.Collections;

public class CsTool : MonoBehaviour {
	public ToolModel to1;
	public ToolModel to2;
	public ToolModel to3;

	public GameObject handboxModel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("handbox").Length > 0) {
			handboxModel = GameObject.FindWithTag ("handbox");
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "to1") {
			handboxModel.GetComponent<HandController> ().SendMessage ("ToolChangeFunction", to1);
		}
		else if(coll.transform.tag == "to2") {
			handboxModel.GetComponent<HandController> ().SendMessage ("ToolChangeFunction", to2);
		}
		else if(coll.transform.tag == "to3") {
			handboxModel.GetComponent<HandController> ().SendMessage ("ToolChangeFunction", to3);
		}

	}
}
