using UnityEngine;
using System.Collections;

public class CsParete1 : MonoBehaviour {

    public GameObject Interface;
    public GameObject Parete;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll)
	{
        Interface.GetComponent<CsClayRightCanvas>().SendMessage("ReceiveRightCanvasFunction", 3);
        
	}

}
