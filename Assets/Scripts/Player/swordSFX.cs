using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSFX : MonoBehaviour
{

    public AudioClip swordSFX_1;
    //public AudioClip swordSFX_2;
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

        audioData.PlayOneShot(swordSFX_1, 0.1f);
        //audioData.PlayOneShot(swordSFX2, 0.1f);
        //audioData.PlayOneShot(swordSFX3, 0.1f);

        //audioData.Play(0);
    }
}
