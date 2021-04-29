using UnityEngine;
using System.Collections;

public class CsTutoroalPin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "FixPoint") {
			//gameObject.AddComponent<FixedJoint> ();
			//gameObject.GetComponent<FixedJoint> ().connectedBody = GameObject.FindWithTag ("FixPoint").GetComponent<Rigidbody>();
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			transform.parent = GameObject.FindWithTag ("FixPoint").transform;
		}
	}
}
