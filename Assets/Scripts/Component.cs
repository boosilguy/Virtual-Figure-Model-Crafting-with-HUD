using UnityEngine;
using System.Collections;

public class Component : MonoBehaviour
{

    public GameObject Glove;
    public GameObject Shoes;
    public GameObject Gogle;
    public GameObject Dress;
	public GameObject SnowManHat;
	public GameObject SnowArms;
	public GameObject SnowScarf;
	public GameObject SnowCarrot;
	public GameObject SmufHat;
	public GameObject SmufGlass;
	public GameObject AngryBird_Beak;
	public GameObject AngryBird_Tail;
	public GameObject AngryBird_Cockscomb;
    public GameObject[] Step = new GameObject[4];

    public Transform SpotPoint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Step[0] = GameObject.FindWithTag("Step0");
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Glove")
        {
            Destroy(coll.gameObject);
            Instantiate(Glove, SpotPoint.position, SpotPoint.rotation);

            Debug.Log("Glove");
        }

        if (coll.gameObject.tag == "Shoes")
        {
            Destroy(coll.gameObject);
            Instantiate(Shoes, SpotPoint.position, SpotPoint.rotation);

            Debug.Log("Shoes");
        }

        if (coll.gameObject.tag == "Dress")
        {
            Destroy(coll.gameObject);
            Instantiate(Dress, SpotPoint.position, SpotPoint.rotation);

            Debug.Log("Dress");
        }

        if (coll.gameObject.tag == "Gogle")
        {
            Destroy(coll.gameObject);
            Instantiate(Gogle, SpotPoint.position, SpotPoint.rotation);

            Debug.Log("Gogle");
        }

		if (coll.gameObject.tag == "Beak") {
			Destroy (coll.gameObject);
			Instantiate (AngryBird_Beak,SpotPoint.position,SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Tail") {
			Destroy (coll.gameObject);
			Instantiate (AngryBird_Tail,SpotPoint.position,SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Cockscomb") {
			Destroy (coll.gameObject);
			Instantiate (AngryBird_Cockscomb,SpotPoint.position,SpotPoint.rotation);
		}


        if (coll.gameObject.tag == "Step0")
        {
            coll.gameObject.GetComponent<BoxCollider>().enabled = false;

            Step [1].GetComponent<BoxCollider> ().enabled = false;
            Step [2].GetComponent<BoxCollider> ().enabled = false;
            Step [3].GetComponent<BoxCollider> ().enabled = false;
      
            Step[0].GetComponent<CsMovieStep>().SendMessage("StepLevelSelect");
        }
        if (coll.gameObject.tag == "Step1")
        {
            Step[0].GetComponent<BoxCollider>().enabled = false;

            Step [1].GetComponent<BoxCollider> ().enabled = false;
            Step [2].GetComponent<BoxCollider> ().enabled = false;
            Step [3].GetComponent<BoxCollider> ().enabled = false;

            coll.gameObject.GetComponent<CsMovieStep>().SendMessage("MoviePlay", 1);
        }
        if (coll.gameObject.tag == "Step2")
        {
            Step[0].GetComponent<BoxCollider>().enabled = false;

            Step [1].GetComponent<BoxCollider> ().enabled = false;
            Step [2].GetComponent<BoxCollider> ().enabled = false;
            Step [3].GetComponent<BoxCollider> ().enabled = false;

            coll.gameObject.GetComponent<CsMovieStep>().SendMessage("MoviePlay", 2);
        }
        if (coll.gameObject.tag == "Step3")
        {
            Step[0].GetComponent<BoxCollider>().enabled = false;

            Step [1].GetComponent<BoxCollider> ().enabled = false;
            Step [2].GetComponent<BoxCollider> ().enabled = false;
            Step [3].GetComponent<BoxCollider> ().enabled = false;

            coll.gameObject.GetComponent<CsMovieStep>().SendMessage("MoviePlay", 3);
        }

		if (coll.gameObject.tag == "Hat")
		{
			Destroy(coll.gameObject);
			Instantiate(SnowManHat, SpotPoint.position, SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Arms")
		{
			Destroy(coll.gameObject);
			Instantiate(SnowArms, SpotPoint.position, SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Scarf")
		{
			Destroy(coll.gameObject);
			Instantiate(SnowScarf, SpotPoint.position, SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Carrot")
		{
			Destroy(coll.gameObject);
			Instantiate(SnowCarrot, SpotPoint.position, SpotPoint.rotation);
		}
		if (coll.gameObject.tag == "Hat2")
		{
			Destroy(coll.gameObject);
			Instantiate(SmufHat, SpotPoint.position, SpotPoint.rotation);
		}

		if (coll.gameObject.tag == "Glass")
		{
			Destroy(coll.gameObject);
			Instantiate(SmufGlass, SpotPoint.position, SpotPoint.rotation);
		}
    }

    void ActiveStep()
    {
		if (Application.loadedLevelName=="BeginnerScene") 
		{
			Step [0].GetComponent<BoxCollider> ().enabled = true;
			Step [1].GetComponent<BoxCollider> ().enabled = true;
			Step [2].GetComponent<BoxCollider> ().enabled = true;
			Step [3].GetComponent<BoxCollider> ().enabled = true;
		}
		else if (Application.loadedLevelName=="IntermediateScene") 
		{
			Step [0].GetComponent<BoxCollider> ().enabled = true;
			Step [1].GetComponent<BoxCollider> ().enabled = true;
			Step [2].GetComponent<BoxCollider> ().enabled = true;

		}
		else if (Application.loadedLevelName=="AngryBirdScene") 
		{
			Step [0].GetComponent<BoxCollider> ().enabled = true;
			Step [1].GetComponent<BoxCollider> ().enabled = true;
			Step [2].GetComponent<BoxCollider> ().enabled = true;
			Step [3].GetComponent<BoxCollider> ().enabled = true;
		}
    }

}