using UnityEngine;
using System.Collections;

public class toolchange : MonoBehaviour {
    public ToolModel tool1;
    public ToolModel tool2;
    public GameObject tool1_1;
    public GameObject tool2_1;
    void OnCollisionEnter(Collision coll)
    {
       
        if (coll.gameObject.tag == "Tool1")
        {
            GameObject goa = GameObject.Find("HandControllerSandBox");
            HandController hand = goa.GetComponent<HandController>();
            hand.toolModel = tool2;
            tool2_1.SetActive(false);
            tool1_1.SetActive(true);
            Debug.Log(hand.toolModel);
            Debug.Log("충돌");
        }
        else if (coll.gameObject.tag == "Tool2")
        {
            GameObject goa = GameObject.Find("HandControllerSandBox");
            HandController hand = goa.GetComponent<HandController>();
            hand.toolModel = tool1;
            tool1_1.SetActive(false);
            tool2_1.SetActive(true);
            Debug.Log(hand.toolModel);
            Debug.Log("충돌");
        }
    }
}
