using System;
using UnityEngine;

namespace Player
{
    public class Bow : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject arrowPrefab;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _audioSource.Play();
                Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
