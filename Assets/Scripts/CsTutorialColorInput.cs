using UnityEngine;
using System.Collections;

public class CsTutorialColorInput : MonoBehaviour {

	public Color InputColor; 
	public GameObject IndexFinger;
    public GameObject Clay;
    public Transform PinPoint;
    public Transform Map;
	public bool Attach;
	public bool TouchEnable;
	int TouchCount;

	// Use this for initialization
	void Start () {
		//InputColor=new color(1.0f,1.0f,.1.0f);
		TouchCount=0;
		Attach = false;
		TouchEnable = true;
	}
	
	// Update is called once per frame
	void Update () {
		Clay = GameObject.FindWithTag ("CLAY");

		if (GameObject.FindGameObjectsWithTag ("IndexFinger").Length>=1) {
			IndexFinger = GameObject.FindWithTag ("IndexFinger");

			if (IndexFinger.activeInHierarchy == true) {
				if (Clay.GetComponent<TutorialLeapMotionGesture> ().PareteEnable == true) {
					InputColor = IndexFinger.GetComponent<CsTutorialPareteColorPoint> ().PointColor;
				}
			}
		}
	}
		
	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "IndexFinger") {
			Debug.Log("deatch");

			if(Clay.GetComponent<TutorialLeapMotionGesture>().PareteEnable==true)
			{
				gameObject.GetComponent<Renderer>().sharedMaterial.color=InputColor;
				if (TouchCount == 0) {
					StartCoroutine ("waitsss");

				}
			}
			if(Attach==true)
			{
				if(TouchEnable==true)
				{
					//Destroy(gameObject.GetComponent<FixedJoint>());
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    transform.parent = Map;
                    StartCoroutine("Deteach");
				}
			}
			TouchCount += 1;
		}
		else if (coll.transform.tag == "FixPoint") {
			if(Attach==false)
			{
				if(TouchEnable==true)
				{
					//gameObject.AddComponent<FixedJoint>();
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    transform.parent = PinPoint;
					TouchEnable=false;
					//StartCoroutine("Deteach");
				}
			}
		}
	}

	IEnumerator waitsss()
	{
		yield return new WaitForSeconds (5);

		gameObject.GetComponent<TutorialLeapMotionGesture> ().ReceiveFunction (3);
		Destroy (GameObject.FindWithTag ("Parete"));
	}

	IEnumerator Deteach()
	{
		yield return new WaitForSeconds(200);
		Attach = !Attach;
		TouchEnable = true;
	}
}
