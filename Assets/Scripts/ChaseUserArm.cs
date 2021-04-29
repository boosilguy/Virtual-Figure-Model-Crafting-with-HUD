using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseUserArm : MonoBehaviour {

	[Tooltip("Set HUD Interface.")]
	public GameObject targetInterface;
	private GameObject HUD; 
	private float anchorValue = 0;

	private float hudAngle;

	private float transAngle;

	private float standardAngle = 30.0f;

	List<float> interList = new List<float>();

	// Use this for initialization
	void Awake(){
		HUD = Instantiate(targetInterface);
		HUD.SetActive (false);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HUDTest.instance != null) {
			//Debug.Log (HUDTest.instance.IsItActived ());
			ActiveHUD ();
		}
	}

	// Chase Object's Position and Rotation
	void ChasePosition(){
		Vector3 ObjectPos = HUDTest.instance.GetPalmPosition ();

		// Calculate
		ObjectPos.x += 5.0f;
		ObjectPos.y += -0.5f;
		ObjectPos.z += 0.0f;

		HUD.transform.position = ObjectPos;
		if (HUDTest.instance.IsItTrans ()) {
			if(Interaction.iSwitch == true)
				standardAngle = 30 + CalLargrange(interList) - Interaction.hudAngle;
			Debug.Log (standardAngle);
			hudAngle = standardAngle + HUD.transform.rotation.x - (2 * transAngle) + HUDTest.instance.GetNaturalAngle ();
			HUD.transform.rotation = Quaternion.Euler (new Vector3 (hudAngle, 0, 0));	

			if (Interaction.iSwitch == true) {
				AddInteraction (HUD.transform.eulerAngles.x);
				Debug.Log ("interaction!");
			}
		} else {
			if(Interaction.iSwitch == true)
				standardAngle = 30 + CalLargrange(interList) - Interaction.hudAngle;
			Debug.Log (standardAngle);
			hudAngle = standardAngle + HUD.transform.rotation.x + - HUDTest.instance.GetNaturalAngle ();
			transAngle = HUDTest.instance.GetNaturalAngle ();
			HUD.transform.rotation = Quaternion.Euler (new Vector3 (hudAngle, 0, 0));

			if (Interaction.iSwitch == true) {
				AddInteraction (HUD.transform.eulerAngles.x);
				Debug.Log ("interaction!");
			}
		}
		//if (hudAngle < 0) {
		//	hudAngle = 30.0f + (-1 * HUD.transform.rotation.x) - HUDTest.instance.GetNaturalAngle ();
		//}


		Interaction.iSwitch = false;

	}

	// Chase Pos and then put to the pos
	void ActiveHUD(){
		if (HUDTest.instance.IsItActived () == true) {
			ChasePosition ();
			HUD.SetActive (true);
			//Debug.Log("ActiveHUD");
		} else {
			HUD.SetActive (false);
		}
	}

	void AddInteraction(float angle){
		interList.Add (angle);
	}

	float CalLargrange(List<float> list){
		float result = 0;
		if (list.Count != 0) {
			foreach (float angle in list) {
				result += angle;
			}
			result = result / list.Count;
		}

		return result;
	}
}
