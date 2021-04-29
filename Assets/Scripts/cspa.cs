using UnityEngine;
using System.Collections;

public class cspa : MonoBehaviour {
    public GameObject par;
    public GameObject gameobj;
    public Transform SpotPoint;
    public Transform PaintPoint;
    public Transform Parete;
    public color point;
    public GameObject Prefab;
    public GameObject Prefab2;
    public GameObject[] PareteBlock = new GameObject[255];
    public GameObject[] PareteBlock2 = new GameObject[255];
    public GameObject[] PareteBlock3 = new GameObject[255];
    public GameObject[] PareteBlock4 = new GameObject[255];
    public GameObject[] PareteBlock5 = new GameObject[255];
    public GameObject[] PareteBlock6 = new GameObject[255];

    public GameObject[] PareteBlock7 = new GameObject[255];
    public GameObject[] PareteBlock8 = new GameObject[255];
    public GameObject[] PareteBlock9 = new GameObject[255];
    public GameObject[] PareteBlock10 = new GameObject[255];
    public GameObject[] PareteBlock11 = new GameObject[255];

    public Color[] RenderingColor = new Color[255];
    public Color[] RenderingColor2 = new Color[255];
    public Color[] RenderingColor3 = new Color[255];
    public Color[] RenderingColor4 = new Color[255];
    public Color[] RenderingColor5 = new Color[255];
    public Color[] RenderingColor6 = new Color[255];

    public Color[] RenderingColor7 = new Color[255];
    public Color[] RenderingColor8 = new Color[255];
    public Color[] RenderingColor9 = new Color[255];
    public Color[] RenderingColor10 = new Color[255];
    public Color[] RenderingColor11 = new Color[255];
    bool panjung = false;


    public float HorizontalValue = 0.0f;
    public float BParameter = 0;
    public int A = 0;
    public int B = 0;
    public int R = 0;
    public int G = 0;
    public float sum = 0;
    // Use this for initialization
    void Start()
    {
        SpotPoint.transform.position = new Vector3(7.07f, 4.4f, -5.8f);

        for (B = 0; B < 255; B += 40)
        {
            PareteBlock[B] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock[B].transform.parent = Parete;

            RenderingColor[B] = new Color(1.0f, 0.0f, B / 255f);

            PareteBlock[B].SendMessage("RGBValueChange", RenderingColor[B]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
            sum += 0.22f;
        }
		SpotPoint.transform.position = new Vector3(7.07f, 4.4f + sum, -5.8f);

        for (R = 0; R < 255; R += 40)
        {
            PareteBlock2[R] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock2[R].transform.parent = Parete;
            RenderingColor2[R] = new Color(1.0f - R / 255.0f, 0.0f, 1.0f);

            PareteBlock2[R].SendMessage("RGBValueChange", RenderingColor2[R]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
            sum += 0.22f;
        }

		SpotPoint.transform.position = new Vector3(7.07f, 4.4f + sum, -5.8f);

        for (G = 0; G < 255; G += 40)
        {
            PareteBlock3[G] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock3[G].transform.parent = Parete;
            RenderingColor3[G] = new Color(0.0f, G / 255f, 1.0f);

            PareteBlock3[G].SendMessage("RGBValueChange", RenderingColor3[G]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
            sum += 0.22f;
        }

		SpotPoint.transform.position = new Vector3(7.07f, 4.4f + sum, -5.8f);

        for (B = 0; B < 255; B += 40)
        {
            PareteBlock4[B] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock4[B].transform.parent = Parete;
            RenderingColor4[B] = new Color(0.0f, 1.0f, 1.0f - B / 255.0f);

            PareteBlock4[B].SendMessage("RGBValueChange", RenderingColor4[B]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
            sum += 0.22f;
        }

		SpotPoint.transform.position = new Vector3(7.07f, 4.4f + sum, -5.8f);

        for (R = 0; R < 255; R += 40)
        {
            PareteBlock5[R] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock5[R].transform.parent = Parete;
            RenderingColor5[R] = new Color(R / 255f, 1.0f, 0.0f);

            PareteBlock5[R].SendMessage("RGBValueChange", RenderingColor5[R]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
            sum += 0.22f;
        }

		SpotPoint.transform.position = new Vector3(7.07f, 4.4f + sum, -5.8f);

        for (G = 0; G < 255; G += 40)
        {
            PareteBlock6[G] = Instantiate(Prefab, SpotPoint.position, SpotPoint.rotation) as GameObject;
            PareteBlock6[G].transform.parent = Parete;
            RenderingColor6[G] = new Color(1.0f, 1.0f - G / 255.0f, 0.0f);

            PareteBlock6[G].SendMessage("RGBValueChange", RenderingColor6[G]);

			SpotPoint.transform.position = new Vector3(7.07f, SpotPoint.transform.position.y + 0.22f, -5.8f);
        }
        

        par.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (panjung == true)
        {
            if (GameObject.FindGameObjectsWithTag("IndexFinger").Length >= 1)
            {
                RenderingColor7[0] = GameObject.FindWithTag("IndexFinger").GetComponent<CsPareteColorPoint>().PointColor;
                //PareteBlock7[0].GetComponent<CsRGBValue>().SendMessage("RGBValueChange", RenderingColor7[0]);
            }
        }
    }

    void OnTriggerEnter(Collider Col)
    {   
        
        panjung = true;
    }

    // Update is called once per frame

}