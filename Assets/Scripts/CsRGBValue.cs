using UnityEngine;
using System.Collections;

public class CsRGBValue : MonoBehaviour {

    public Color RGBValue;

    // Use this for initialization
    void Start() {
        //RGBValue = gameObject.GetComponent<CsParete>().RenderingColor[0];
        //		BValue=gameObject.GetComponent<CsParete>().B;
        //		if (BValue == 2) {
        //			gameObject.GetComponent<Renderer>().material.color=Color.red;
        //		}
    }

    // Update is called once per frame
    void Update() {
        //gameObject.GetComponent<Renderer>().sharedMaterial.color = RGBValue;
        //gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_Albedo",RGBValue);

    }

    void RGBValueChange(Color Parameter)
    {
        RGBValue = Parameter;

        gameObject.GetComponent<Renderer>().material.color = RGBValue;
    }
}
