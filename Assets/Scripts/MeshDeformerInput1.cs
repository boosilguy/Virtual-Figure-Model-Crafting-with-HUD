using UnityEngine;

public class MeshDeformerInput1 : MonoBehaviour {
	
	public float force;
	public float forceOffset = 0.1f;
	public bool Check=true;

	void Start()
	{
		force = 5.0f;
	}

	void Update () {

	}

	void HandleInput2 (Vector3 hitpoint) 
	{		
		Ray inputRay = Camera.main.ScreenPointToRay(hitpoint);

		RaycastHit hit;
	
		if (Physics.Raycast(inputRay,out hit)) {
			Debug.Log("홧더");
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();

			if (deformer) {
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}
}