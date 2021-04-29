using UnityEngine;
using System.Collections;

public class CsInfo : MonoBehaviour {

	public GameObject Info;
	public GameObject Info1;
	public GameObject Info2;
	public GameObject Info3;

	public bool fo = true;
	public bool fo1;
	public bool fo2;
	public bool fo3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (fo == true) 
		{
			Info.SetActive (true);
			Info1.SetActive (false);
			Info2.SetActive (false);
			Info3.SetActive (false);
		}
		else if (fo1 == true) 
		{
			Info.SetActive (false);
			Info1.SetActive (true);
			Info2.SetActive (false);
			Info3.SetActive (false);
		}
		else if(fo2 == true)
		{
			Info.SetActive (false);
			Info1.SetActive (false);
			Info2.SetActive (true);
			Info3.SetActive (false);
		}
		else if(fo3 == true)
		{
			Info.SetActive (false);
			Info1.SetActive (false);
			Info2.SetActive (false);
			Info3.SetActive (true);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "to1")
		{	
			
			fo = false;
			fo1 = true;
			fo2 = false;
			fo3 = false;

		}
		else if (other.transform.tag == "to2")
		{
			
			fo = false;
			fo1 = false;
			fo2 = true;
			fo3 = false;
		}
		else if (other.transform.tag == "to3")
		{

			fo = false;
			fo1 = false;
			fo2 = false;
			fo3 = true;
		}

	}

}
