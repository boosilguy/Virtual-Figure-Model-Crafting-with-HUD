using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDTest : MonoBehaviour {
	public static HUDTest instance;

	[Tooltip("기준이 될 방향벡터입니다.")]
	public Vector3 normalVector;
	public Vector3 directionVector;
	public Vector3 naturalVector;

	private Vector3 DV;
	private Vector3 NV;

	[Tooltip("함수가 실행되는 각도입니다.")]
	public float OnAngle = 45;
	[Tooltip("함수가 종료되는 각도입니다.")]
	public float OffAngle = 60;
	private float naturalAngle;

	public Vector3 handVector;
	public Vector3 normVector;

	bool isTrans;

	bool isActived = false;

	// Set Singleton
	public void Awake() {
		HUDTest.instance = this;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vectors ();
		CheckHUDStatus (GetAngle(this.transform.position-(this.transform.position + directionVector),this.transform.position-(this.transform.position + normalVector)));

		// Get angle to interaction with user naturally
		normVector = this.transform.position-(this.transform.position + directionVector);
		handVector = this.transform.position - (this.transform.position + normalVector);
		naturalAngle = GetAngle(handVector, normVector);
		//Debug.Log (naturalAngle);
		if (handVector.z > normVector.z)
			isTrans = true;
		else
			isTrans = false;
	}

	// Getter and Setter
	public Vector3 GetPalmPosition(){
		return this.transform.position;
	}

	public Vector3 GetNaturalVector(){
		return naturalVector;
	}

	public Vector3 GetDirectionVector(){
		return directionVector;
	}

	public bool IsItActived(){
		return isActived;
	}

	public bool IsItTrans(){
		return isTrans;
	}

	public float GetNaturalAngle(){
		return naturalAngle;
	}



	// vectors to Lines
	void Vectors(){
		directionVector = -transform.up;
		DV = this.transform.position + directionVector * 5.0f;
		NV = this.transform.position + normalVector * 5.0f;

		// Catch your vectors
		// 벡터들의 구성을 인지하기 위한 Line
		//Debug.DrawLine (this.transform.position, DV, Color.green);
		//Debug.DrawLine (this.transform.position, NV, Color.blue);
		//Debug.DrawLine (this.transform.position, CalculateNaturalVector(), Color.red);
	}

	// set naturalVector(Need to natural interaction with user)
	public Vector3 CalculateNaturalVector(){
		naturalVector.x = this.transform.position.x;
		naturalVector.y = this.transform.position.y + directionVector.y * 5.0f;
		naturalVector.z = this.transform.position.z + directionVector.z * 5.0f;

		return naturalVector;
	}

	// Get angle to check HUD On or Off
	float GetAngle (Vector3 First, Vector3 Second){
		Vector3 FirstVector = First;
		Vector3 SecondVector = Second;

		// Normalization Vector
		float sizeF = Mathf.Sqrt((FirstVector.x*FirstVector.x)+(FirstVector.y*FirstVector.y)+(FirstVector.z*FirstVector.z));
		float sizeS = Mathf.Sqrt((SecondVector.x*SecondVector.x)+(SecondVector.y*SecondVector.y)+(SecondVector.z*SecondVector.z));

		FirstVector.x/=sizeF;
		FirstVector.y/=sizeF;
		FirstVector.z/=sizeF;

		SecondVector.x/=sizeS;
		SecondVector.y/=sizeS;
		SecondVector.z/=sizeS;

		// Do Inner Product and Transform Angle
		float innerProduct = (FirstVector.x * SecondVector.x) + (FirstVector.y * SecondVector.y) + (FirstVector.z * SecondVector.z);;
		float radian = Mathf.Acos (innerProduct);
		float OurAngle = radian * 180 / Mathf.PI;
		return OurAngle;
	}

	// Check Status On or Off
	void CheckHUDStatus (float Angle){
		if (isActived != true && Angle <= OnAngle) {
			isActived = true;
		}
		else if(isActived == true && Angle >= OffAngle) {
			isActived = false;
		}
	}

}
