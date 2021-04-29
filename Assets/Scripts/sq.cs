using UnityEngine;
using System.Collections;

public class sq : MonoBehaviour {
    public ToolModel tool1;
    public ToolModel tool2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "tool1")
        {
            GameObject goa = GameObject.Find("HandControllerSandBox");
            HandController hand = goa.GetComponent<HandController>();
            hand.toolModel = tool2;
        }
        else if(coll.gameObject.tag == "tool2")
        {
            GameObject goa = GameObject.Find("HandControllerSandBox");
            HandController hand = goa.GetComponent<HandController>();
            hand.toolModel = tool1;
        }
    }
}
