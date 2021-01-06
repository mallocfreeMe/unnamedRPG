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
        public AudioClip sowrdSlash_1, sowrdSlash_2, sowrdStab_1;


        private int _combo = 0;
        private int _timer; // count down timer (1.5s) before attack chain (combo) is stopped

        public int setTimer;

        private bool _comboStart = false; // combo has started

        private int _counter = 0; //counter for charging up the powerful attack

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

                if (_comboStart == false) //if combo has not started
                {
                    _comboStart = true; // start combo
                }

                //print("reached");
                _combo += 1;
                //print("attack combo #: " + _combo);

                switch (_combo) // different states of the chain attack poses (combo)
                {
                    case 1:
                        _audioData.PlayOneShot(sowrdSlash_1, 0.07F);
                        _swordAnimator.SetTrigger("isAttacking");
                        _timer = setTimer; //reset countdown timer
                        break;
                    case 2:
                        _audioData.PlayOneShot(sowrdSlash_2, 0.07F);
                        _swordAnimator.SetTrigger("attack2");
                        _timer = setTimer; //reset countdown timer
                        break;
                    case 3:
                        _audioData.PlayOneShot(sowrdStab_1, 0.07F);
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

            if (_comboStart == true) //if combo has started
            {
                _timer -= 1; // start countdown
            }
 
            //print("timer: " + _timer);


            if (_timer <= 0) // if timer runs out
            {
                
                _timer = setTimer;  //reset timer
                _combo = 0;  //reset combo count
                _comboStart = false; // reset combo state
            }
        }



    }
}