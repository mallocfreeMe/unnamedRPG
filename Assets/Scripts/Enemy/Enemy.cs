using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
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

        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private Animator _animator;
        private bool _signIsShown;
        private bool _isDead;

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _animator = GetComponent<Animator>();
            _aiPath.canMove = false;
            _aiPath.maxSpeed = Random.Range(3, maxSpeed);
        }

        private void Update()
        {
            if (_aiPath.canMove)
            {
                transform.localRotation = _aiPath.desiredVelocity.x < 0.01f
                    ? Quaternion.Euler(0, 180, 0)
                    : Quaternion.Euler(0, 0, 0);
            }

            var distance = Vector2.Distance(transform.position, _aiDestinationSetter.target.transform.position);

            if (distance > chaseRange && !_isDead)
            {
                _aiPath.canMove = false;
                _animator.SetBool("isMoving", false);
                _animator.SetBool("isAttacking", false);
            }
            else if (distance < chaseRange && distance > attackRange && !_isDead)
            {
                _aiPath.canMove = true;
                _animator.SetBool("isMoving", true);
                _animator.SetBool("isAttacking", false);
                if (!_signIsShown)
                {
                    StartCoroutine(PlaySign());
                }
            }
            else if (distance <= attackRange && !_isDead)
            {
                _aiPath.canMove = false;
                _animator.SetBool("isMoving", false);
                _animator.SetBool("isAttacking", true);
            }

            if (health <= 0 && !_isDead)
            {
                _aiPath.canMove = false;
                _animator.SetTrigger("isDead");
                _isDead = true;
                StartCoroutine(PlayDeathAnimation());
            }
        }

        private IEnumerator PlaySign()
        {
            sign.SetActive(true);
            yield return new WaitForSeconds(2);
            sign.SetActive(false);
            _signIsShown = true;
        }


        private IEnumerator PlayDeathAnimation()
        {
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Sword"))
            {
                health--;
            }
        }
    }
}