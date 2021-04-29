using UnityEngine;
using System.Collections;

public class CsObjectAttach : MonoBehaviour {

	public bool Attach;

	// Use this for initialization
	void Start () {
		Attach = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Attach == true) {
			gameObject.GetComponent<FixedJoint> ().connectedBody = GameObject.FindWithTag ("CLAY").GetComponent<Rigidbody> ();

		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "CLAY") {
			gameObject.AddComponent<FixedJoint> ();
			StartCoroutine ("waaad");
			Attach = true;
		}
	}

	IEnumerator waaad()
	{
		yield return new WaitForSeconds (20);
		GameObject.FindWithTag ("CLAY").GetComponent<TutorialLeapMotionGesture> ().ReceiveFunction (5);
	}
}
