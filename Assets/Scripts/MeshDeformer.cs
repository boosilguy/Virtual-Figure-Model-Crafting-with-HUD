using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour {

	public float springForce = 20f;
	public float damping = 5f;
	public Color BaseColor;
		Mesh deformingMesh;
	Vector3[] originalVertices, displacedVertices;
	Vector3[] vertexVelocities;

	float uniformScale = 1f;

	void Start () {
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		BaseColor = new Color (1.0f, 1.0f, 1.0f);
		gameObject.GetComponent<Renderer>().material.color = BaseColor;
		//displacedVertices를 original 값으로 초기화한다.
		for (int i = 0; i < originalVertices.Length; i++) {
			displacedVertices[i] = originalVertices[i];
		} 
		vertexVelocities = new Vector3[originalVertices.Length];
	}

	void Update () {
		//uiniform이라는 변수를 MUD의 X 크기 값으로 초기화 한다.
		uniformScale = transform.localScale.x;

		//선택된 Vertex의 Deformation의 범위를 계산하여 변형 수행
		for (int i = 0; i < displacedVertices.Length; i++) {
			UpdateVertex(i);
		}
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
	}

	//실질적인 변환이 일어나는 곳
	void UpdateVertex (int i) {
		Vector3 velocity = vertexVelocities[i];
		Vector3 displacement = displacedVertices[i] - originalVertices[i];
		displacement *= uniformScale;
		velocity -= displacement * springForce * Time.deltaTime;
		velocity *= 1f - damping * Time.deltaTime;
		vertexVelocities[i] = velocity;
		//velocity는 1-Damping(충격완화) 밑에줄에서 변화가 일어난다.	
		displacedVertices[i] += 0.5f*velocity*(Time.deltaTime / uniformScale);
	}

	//힘이 적용되는 범위를 계산 ?
	public void AddDeformingForce (Vector3 point, float force) {

		point = transform.InverseTransformPoint(point);
		for (int i = 0; i < displacedVertices.Length; i++) {
			AddForceToVertex(i, point, force);
		}
	}

	//적용된 힘을 계산한여 vertex에 적용
	void AddForceToVertex (int i, Vector3 point, float force) {
		Vector3 pointToVertex = displacedVertices[i] - point;
		pointToVertex *= uniformScale;
		float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
		float velocity = attenuatedForce * Time.deltaTime;
		vertexVelocities[i] += pointToVertex.normalized * velocity;
	}

	void Print(Vector3 hitpoint)
	{
		Debug.Log (hitpoint);
	}
}	