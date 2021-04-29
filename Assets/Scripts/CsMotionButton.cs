	using UnityEngine;
using System.Collections;

public class CsMotionButton : MonoBehaviour {

	public bool ButtonEnable;
	public bool buttonPushEnable;
	public GameObject Clay;

	// Use this for initialization
	void Start () {
		ButtonEnable = false;
		buttonPushEnable = true;

		gameObject.transform.position = new Vector3 (2.5f, 2.6f, -6.13f);
		Clay.GetComponent<LeapGesture3> ().enabled = false;
		GameObject.FindWithTag ("CLAY").GetComponent<CsColorInput> ().SendMessage ("LeapGestureEnableFunction", false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "IndexFinger") {
			Debug.Log ("appraprp");
			//버튼 들어가있음
			if (buttonPushEnable == true) {
				if (ButtonEnable == true) {
					gameObject.transform.position = new Vector3 (2.5f, 2.4f, -6.13f);
					Clay.GetComponent<LeapGesture3> ().enabled = true;
					GameObject.FindWithTag ("CLAY").GetComponent<CsColorInput> ().SendMessage ("LeapGestureEnableFunction", true);
				}
			//버튼 나와있음
			else if (ButtonEnable == false) {
					gameObject.transform.position = new Vector3 (2.5f, 2.6f, -6.13f);
					Clay.GetComponent<LeapGesture3> ().enabled = false;
					GameObject.FindWithTag ("CLAY").GetComponent<CsColorInput> ().SendMessage ("LeapGestureEnableFunction", false);
				}

				ButtonEnable = !ButtonEnable;
				buttonPushEnable = false;
				StartCoroutine ("ButtonPush");
			}
		}
	}

	IEnumerator ButtonPush()
	{
		yield return new WaitForSeconds (1);

		buttonPushEnable = true;
	}
}
