using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        public GameObject sword;

        private Animator _animator;
        private Animator _swordAnimator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _swordAnimator = sword.GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("isMoving", true);
                if (sword.activeSelf)
                {
                    _swordAnimator.SetBool("isMoving", true);
                }
            }
            else
            {
                _animator.SetBool("isMoving", false);
                if (sword.activeSelf)
                {
                    _swordAnimator.SetBool("isMoving", false);
                }
            }
        }
    }
}