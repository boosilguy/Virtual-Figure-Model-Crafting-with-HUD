using UnityEngine;
using System.Collections;

public class CsRaycast : MonoBehaviour {

	public float speed = 5.0f;
	public float Distance;
	public GameObject Clay;
	public GameObject Main;
	public bool RedColorPaint;
	public bool Sendd;
	public float force = 10f;
	public float forceOffset = 0.1f;


	public Material redClay;
	public Material BaseClay;

	public GameObject OBJJJ;

	// Use this for initialization
	void Start () {
		Sendd = false;
		Distance = 0.8f;
		//RedColorPaint = true;

	}

	// Update is called once per frame
	void Update () {
		OBJJJ=GameObject.FindWithTag("OBJJJ");
		RaycastHit hit;

		if (Physics.Raycast (transform.position, Vector3.left, out hit, Distance)) {

			Vector3 hitpoint = hit.point;

			Clay = GameObject.FindWithTag("CLAY");

			//Main.GetComponent<MeshDeformerInput>().SendMessage ("HandleInput2",hit.point);

			MeshDeformer deformer=hit.collider.GetComponent<MeshDeformer>();
			//Debug.Log(hitpoint);
			if (deformer) {
				Debug.Log (deformer.name);
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
				if (Application.loadedLevelName == "Tutorial") {
					if (GameObject.FindGameObjectsWithTag ("OBJJJ").Length >= 1) {
						OBJJJ.SendMessage ("valuechange", true);
						//StartCoroutine ("wait");
					}
				} else {
					Debug.Log ("NoTutorial");
				}
			}
		}	
			else {
			Debug.DrawLine(transform.position,Vector3.left,Color.red);
		}
		if (Sendd == true) {

		}

	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (3);
		Sendd = true;

	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "RedBox") {
			Debug.Log("RedBox");
			RedColorPaint=true;
		}

	}
}
