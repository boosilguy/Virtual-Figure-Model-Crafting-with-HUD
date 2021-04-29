using UnityEngine;
using System.Collections;

public class Rotate1left : MonoBehaviour
{

    float rotateSpeed = 20.0f;
    public GameObject SnowMan;

    void Update()
    {

    }

	void OnCollisionStay(Collision other)
    {
        float rotateAngle = rotateSpeed * Time.deltaTime;
		SnowMan.transform.Rotate(Vector3.up * rotateAngle);

    }
   
}
