using UnityEngine;
using System.Collections;

public class colider : MonoBehaviour {
    
    public string nextSceneName;
    public bool IntermediateCurbi = false;
	public bool IntermediateMinions=false;
	// Use this for initialization
	void Start () {
		IntermediateCurbi = false;
		IntermediateMinions = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (IntermediateCurbi == true)
        {
            Application.LoadLevel("CurbiScene");
			IntermediateCurbi = false;

        }
		else if (IntermediateMinions == true)
		{
			Application.LoadLevel("MinionsScene");
			IntermediateMinions = false;
		}

	}
	void OnCollisionEnter(Collision coll)
    {
		if (coll.transform.tag == "Curbi") {
			Debug.Log ("Curbi");
			IntermediateCurbi = true;
		}

		if (coll.transform.tag == "Minions") {
			Debug.Log ("Minions");
			IntermediateMinions = true;
		}
    }
}
