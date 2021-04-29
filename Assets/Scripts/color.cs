using UnityEngine;
using System.Collections;

public class color : MonoBehaviour {
    public Color settingColor = Color.white;
	// Use this for initialization
	void Start () {
        SettingColor();
	}
    public void SettingColor()
    {
        GetComponent<Renderer>().material.color = settingColor;
    }	

}
