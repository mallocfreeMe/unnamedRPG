using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Player;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public GameObject sign;
        public int maxSpeed = 5;
        public int health = 3;
        public float chaseRange = 5;
        public float attackRange = 1;
        public Transform originalTransform;
        public GameObject particleEffect;
        public GameObject bloodSplash;
        public GameObject damageText;

        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private Animator _animator;
        private bool _signIsShown;
        private bool _isDead;
        private Transform _playerTransform;
        private PlayerAnimation _playerAnimationScript;
        private AudioSource _audioSource;
        private GameObject _damageTextPrefab;

        private void Awake()
        {
            originalTransform.SetParent(null, true);
        }

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _playerAnimationScript = GameObject.FindWithTag("Player").GetComponent<PlayerAnimation>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _aiPath.canMove = false;
            _aiPath.maxSpeed = Random.Range(3, maxSpeed);
            _playerTransform = _aiDestinationSetter.target;
        }

        private void Update()
        {
            if (_aiPath.canMove)
            {
                transform.localRotation = _aiPath.desiredVelocity.x < 0.01f
                    ? Quaternion.Euler(0, 180, 0)
                    : Quaternion.Euler(0, 0, 0);
            }

            var distance = Vector2.Distance(transform.position, _playerTransform.position);

            // idle 
            if (distance > chaseRange && Vector2.Distance(transform.position, originalTransform.position) <= 1 &&
                !_isDead)
            {
                _signIsShown = false;
                _aiDestinationSetter.target = _playerTransform;
                _aiPath.canMove = false;
                _animator.SetBool("isMoving", false);
                _animator.SetBool("isAttacking", false);
            }
            // go back to original position
            else if (distance > chaseRange && Vector2.Distance(transform.position, originalTransform.position) > 1 &&
                     !_isDead)
            {
                _signIsShown = false;
                _aiDestinationSetter.target = originalTransform;
                _aiPath.canMove = true;
                _animator.SetBool("isMoving", true);
                _animator.SetBool("isAttacking", false);
            }
            // chase player 
            else if (distance <= chaseRange && distance > attackRange && !_isDead &&
                     _aiDestinationSetter.target.position == _playerTransform.position)
            {
                _aiPath.canMove = true;
                _animator.SetBool("isMoving", true);
                _animator.SetBool("isAttacking", false);
                if (!_signIsShown)
                {
                    StartCoroutine(PlaySign());
                }
            }
            // attack player 
            else if (distance <= attackRange && !_isDead &&
                     _aiDestinationSetter.target.position == _playerTransform.position)
            {
                _aiPath.canMove = false;
                _animator.SetBool("isMoving", false);
                _animator.SetBool("isAttacking", true);
            }

            // death
            if (health <= 0 && !_isDead)
            {
                _aiPath.canMove = false;
                _animator.SetTrigger("isDead");
                _isDead = true;
                StartCoroutine(PlayDeathAnimation());
            }

            // damage text scale animation
            if (_damageTextPrefab != null)
            {
                _damageTextPrefab.transform.localScale += new Vector3(0.02f, 0.02f, 0);
            }
        }

        // play sign when enemy see the player 
        private IEnumerator PlaySign()
        {
            if (!_isDead)
            {
                sign.SetActive(true);
                yield return new WaitForSeconds(2);
                sign.SetActive(false);
                _signIsShown = true;
            }
        }

        // wait 4 seconds then remove the enemy after its death
        private IEnumerator PlayDeathAnimation()
        {
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
            var pos = new Vector3(transform.position.x - 0.3f, transform.position.y, -2);
            Instantiate(bloodSplash, pos, Quaternion.identity);
        }

        // when an enemy takes damages, enemy loses its health
        // displays particle effect
        // displays damage text
        private void DamagedEffect()
        {
            if (!_isDead)
            {
                health--;
                _audioSource.Play();
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                var pos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.5f, -4);
                _damageTextPrefab = Instantiate(damageText, pos, Quaternion.identity);
                _damageTextPrefab.GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.right).normalized;
                _damageTextPrefab.transform.localScale += new Vector3(1f, 1f, 0);
                Destroy(_damageTextPrefab, 0.5f);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Sword") && _playerAnimationScript.comboStart)
            {
                DamagedEffect();
            }

            if (other.gameObject.CompareTag("Arrow"))
            {
                // destroy the arrow
                if (!_isDead)
                {
                    Destroy(other.gameObject);
                }

                DamagedEffect();
            }
        }
    }
}