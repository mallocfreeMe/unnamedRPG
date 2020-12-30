using System;
using UnityEngine;

namespace Player
{
    public class Arrow : MonoBehaviour
    {
        public float speed = 1f;

        private Rigidbody2D _rb;
        private Camera _viewCamera;
        private Vector3 _targetPos;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _viewCamera = Camera.main;

            if (_viewCamera != null)
            {
                _targetPos = new Vector3(_viewCamera.ScreenToWorldPoint(Input.mousePosition).x,
                    _viewCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
                
                transform.LookAt(_targetPos);
                
                if (_targetPos.x > transform.position.x)
                {
                    _rb.velocity = _viewCamera.ScreenToWorldPoint(Input.mousePosition).normalized * speed * -1;
                }
                else
                {
                    _rb.velocity = _viewCamera.ScreenToWorldPoint(Input.mousePosition).normalized * speed;
                }
            }
        }
    }
}