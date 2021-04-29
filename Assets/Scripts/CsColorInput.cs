using UnityEngine;
using System.Collections;

public class CsColorInput : MonoBehaviour {

	public Color InputColor; 
	public GameObject IndexFinger;
    public GameObject Clay;
    public Transform PinPoint;
    public Transform Map;
	public bool Attach;
	public bool TouchEnable;
	public bool LeapGestureEnable;

	// Use this for initialization
	void Start () {
		//InputColor=new color(1.0f,1.0f,.1.0f);
		Attach = false;
		TouchEnable = true;
		LeapGestureEnable = true;
	}
	
	// Update is called once per frame
	void Update () {
		Clay = GameObject.FindWithTag ("CLAY");

		if (GameObject.FindGameObjectsWithTag ("IndexFinger").Length>=1) {
			IndexFinger = GameObject.FindWithTag ("IndexFinger");

			if (IndexFinger.activeInHierarchy == true) {
				if (LeapGestureEnable == true) {
					if (Clay.GetComponent<LeapGesture3> ().PareteEnable == true) {
						InputColor = IndexFinger.GetComponent<CsPareteColorPoint> ().PointColor;
					}
				}
			}	

		}
	}

	void LeapGestureEnableFunction(bool parameter)
	{
		LeapGestureEnable = parameter;
	}
		
	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "IndexFinger") {
			Debug.Log("deatch");

			if(Clay.GetComponent<LeapGesture3>().PareteEnable==true)
			{
				gameObject.GetComponent<Renderer>().sharedMaterial.color=InputColor;
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
					StartCoroutine("Deteach");
				}
			}
		}
	}

	IEnumerator Deteach()
	{
		yield return new WaitForSeconds(200);
		Attach = !Attach;
		TouchEnable = true;
	}
}
