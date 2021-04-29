using UnityEngine;

public class MeshDeformerInput : MonoBehaviour {
	
	public float force;
	public float forceOffset;
	public bool Check=true;

	void Start()
	{
		force = 2.0f;
		forceOffset = 0.1f;
	}
	
	void Update () {

	}

	void HandleInput2 (Vector3 hitpoint) 
	{		
		Ray inputRay = Camera.main.ScreenPointToRay(hitpoint);

		RaycastHit hit;
	
		if (Physics.Raycast(inputRay,out hit)) {
			Debug.Log ("충돌감지");
			Debug.Log(hit.transform.name);
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
			Debug.Log(deformer);
			if (deformer) {
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}
}