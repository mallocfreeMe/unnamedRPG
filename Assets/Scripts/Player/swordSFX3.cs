using UnityEngine;

namespace Player
{
    public class swordSFX3 : MonoBehaviour
    {

        //public AudioClip swordSFX_1;
        //public AudioClip swordSFX_2;
        public AudioClip swordSFX_3;

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
            //audioData.PlayOneShot(swordSFX2, 0.1f);
            audioData.PlayOneShot(swordSFX_3, 0.1f);

            //audioData.Play(0);
        }
    }
}
