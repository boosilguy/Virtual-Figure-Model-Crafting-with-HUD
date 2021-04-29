using UnityEngine;
using System.Collections;

public class CsTutorialValueChagen : MonoBehaviour {

	public bool vvalue;
	// Use this for initialization
	void Start () {
		vvalue = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (vvalue == true) {
			StartCoroutine ("ejejejejejejej");
		}
	}

	void valuechange(bool parameter)
	{

		vvalue = parameter;
	}

	IEnumerator ejejejejejejej()
	{
		yield return new WaitForSeconds (2);
		GameObject.FindWithTag ("CLAY").GetComponent<TutorialLeapMotionGesture> ().ReceiveFunction (1);
		Destroy (gameObject);
	}
}
