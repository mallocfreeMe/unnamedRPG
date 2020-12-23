using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        /*if (groundPlane.Raycast(ray, out rayDistance))
        {
            var point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.magenta);
            _controller.LookAt(point);
        }*/
    }
}