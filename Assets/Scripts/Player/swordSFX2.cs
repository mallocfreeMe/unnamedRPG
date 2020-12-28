using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSFX2 : MonoBehaviour
{

    //public AudioClip swordSFX_1;
    public AudioClip swordSFX_2;
    //public AudioClip swordSFX_3;

    AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {

        audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        //audioData.PlayOneShot(swordSFX1, 0.1f);
        audioData.PlayOneShot(swordSFX_2, 0.1f);
        //audioData.PlayOneShot(swordSFX3, 0.1f);

        //audioData.Play(0);
    }
}
