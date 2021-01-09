using System;
using UnityEngine;

namespace Player
{
    public class Arrow : MonoBehaviour
    {
        public float speed = 1f;

        private Rigidbody2D _rb;
        private Vector2 _shootingDirection;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _shootingDirection = (transform.rotation * Vector2.right).normalized;
            _rb.velocity = _shootingDirection * speed * -1;
            Destroy(gameObject, 2f);
        }
    }
}