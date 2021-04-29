using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    float rotateSpeed = 30.0f;

    void Update()
    {

            float rotateAngle = rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotateAngle);
    }
}
