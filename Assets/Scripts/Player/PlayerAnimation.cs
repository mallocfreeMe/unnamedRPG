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
        private AudioSource _audioData;
        public AudioClip swordSlash1, swordSlash2, swordStab1;


        private int _combo = 0;
        private int _timer; // count down timer (1.5s) before attack chain (combo) is stopped

        public int setTimer;

        public bool comboStart; // combo has started

        // private int _counter = 0; //counter for charging up the powerful attack

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _swordAnimator = sword.GetComponent<Animator>();
            _audioData = GetComponent<AudioSource>();
            _timer = setTimer;
        }

        private void Update()
        {
            PlayerMove();
            PlayerAttack();
            ComboTimer();
        }

        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("isMoving", true);
            }
            else
            {
                _animator.SetBool("isMoving", false);
            }
        }

        // player attack
        private void PlayerAttack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (comboStart == false) //if combo has not started
                {
                    comboStart = true; // start combo
                }

                //print("reached");
                _combo += 1;
                //print("attack combo #: " + _combo);

                switch (_combo) // different states of the chain attack poses (combo)
                {
                    case 1:
                        _audioData.PlayOneShot(swordSlash1, 0.07F);
                        _swordAnimator.SetTrigger("isAttacking");
                        _timer = setTimer; //reset countdown timer
                        break;
                    case 2:
                        _audioData.PlayOneShot(swordSlash2, 0.07F);
                        _swordAnimator.SetTrigger("attack2");
                        _timer = setTimer; //reset countdown timer
                        break;
                    case 3:
                        _audioData.PlayOneShot(swordStab1, 0.07F);
                        _swordAnimator.SetTrigger("attack3");
                        _timer = setTimer; //reset countdown timer
                        _combo = 0;
                        break;
                }
            }
        }

        //combo timer countdown
        private void ComboTimer()
        {
            if (comboStart) //if combo has started
            {
                _timer -= 1; // start countdown
            }

            //print("timer: " + _timer);


            if (_timer <= 0) // if timer runs out
            {
                _timer = setTimer; //reset timer
                _combo = 0; //reset combo count
                comboStart = false; // reset combo state
            }
        }
    }
}