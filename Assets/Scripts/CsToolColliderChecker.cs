using UnityEngine;
using System.Collections;

public class CsToolColliderChecker : MonoBehaviour {

	public float speed = 5.0f;
	public float Distance;
	public GameObject Clay;
	public GameObject Main;
	public bool RedColorPaint;
	public float force = 10f;
	public float forceOffset = 0.1f;
	public Vector3 CollisionPoint;

	public Material redClay;
	public Material BaseClay;

	// Use this for initialization
	void Start () {
		Distance = 0.8f;
		//RedColorPaint = true;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, Vector3.left, out hit, Distance)) {

			Vector3 hitpoint = hit.point;

			Clay = GameObject.FindWithTag("CLAY");

			//Main.GetComponent<MeshDeformerInput>().SendMessage ("HandleInput2",hit.point);
			/*
			MeshDeformer deformer=hit.collider.GetComponent<MeshDeformer>();
			Debug.Log(hitpoint);
			if (deformer) {
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
			*/
		}	
			else {
			Debug.DrawLine(transform.position,Vector3.left,Color.red);
		}
	}

	void OnCollisionStay(Collision coll)
	{
		if (coll.transform.tag == "CLAY") {
			ContactPoint contact = coll.contacts[0];
			Vector3 pos=contact.point;

			MeshDeformer ClayDeformer = coll.collider.GetComponent<MeshDeformer>();

			if(ClayDeformer)
			{
				Debug.Log(pos);
				pos+=pos.normalized*forceOffset;
				ClayDeformer.AddDeformingForce(pos,force);
			}

		}

	}
}
