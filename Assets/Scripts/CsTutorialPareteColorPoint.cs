using UnityEngine;
using System.Collections;

public class CsTutorialPareteColorPoint : MonoBehaviour {

	public Color PointColor;

	// Use this for initialization
	void Start () {
		PointColor = new Color (1.0f, 1.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "Pallet") {
			PointColor = coll.gameObject.GetComponent<CsRGBValue> ().RGBValue;
			Debug.Log ("Point");
		} 
	}
}
