using UnityEngine;
using System.Collections;

public class csFingerPoint : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("IndexFinger").Length >= 1)
        {
            this.GetComponent<Renderer>().material.color = GameObject.FindWithTag("IndexFinger").GetComponent<CsPareteColorPoint>().PointColor;
        }
    }
}
