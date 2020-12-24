using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerAnimation))]
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5;

        private Camera _viewCamera;
        private PlayerController _controller;

        private void Start()
        {
            _controller = GetComponent<PlayerController>();
            _viewCamera = Camera.main;
        }

        private void Update()
        {
            // movement input
            var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            var moveVelocity = moveInput.normalized * moveSpeed;
            _controller.Move(moveVelocity);

            // look input
        }
    }
}