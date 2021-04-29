using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class CsMovieStep : MonoBehaviour
{

    public GameObject PlayCanvas;
    public MovieTexture Step;

    private AudioSource audio;

    public int MovieLevel;

    public bool PlayEnble;
    // Use this for initialization
    void Start()
    {
        PlayEnble = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Step.isPlaying == false)
        {
            if (PlayCanvas.activeInHierarchy == true)
            {
                gameObject.GetComponentInChildren<RawImage>().enabled = false;
                PlayEnble = true;
                if (GameObject.FindGameObjectsWithTag("IndexFinger").Length >= 1)
                {   
                    GameObject.FindWithTag("IndexFinger").SendMessage("ActiveStep");
                }
            }
        }
    }

    void MoviePlay()
    {
        if (PlayEnble == true)
        {
            PlayCanvas.SetActive(true);
            PlayEnble = false;
            gameObject.GetComponentInChildren<RawImage>().enabled = true;

            GetComponentInChildren<RawImage>().texture = Step as MovieTexture;
            audio = GetComponentInChildren<AudioSource>();
            audio.clip = Step.audioClip;
            Step.Play();
            audio.Play();
        }
    }

    public void StepLevelSelect()
    {
        PlayEnble = true;
        //MovieLevel = StepNumber;
        MoviePlay();
    }
}