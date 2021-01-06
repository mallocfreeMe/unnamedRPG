using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimation))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Attribute")]
        public float moveSpeed = 5;
        
        [Header("Weapon")]
        public GameObject sword;
        public GameObject bow;

        [Header("Inventory UI")]
        public Image slot1;
        public TextMeshProUGUI weaponName;
        public Image slot2;
        public Sprite inactiveSprite;
        public Sprite activeSprite;
        
        private Camera _viewCamera;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _viewCamera = Camera.main;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
            
        }

        private void Update()
        {
            LookAtMouse();
            WeaponSwitch();
         
        }

        // movement input
        private void Move()
        {
            var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            var moveVelocity = moveInput.normalized * moveSpeed;
            _rigidbody2D.MovePosition(_rigidbody2D.position + moveVelocity * Time.fixedDeltaTime);
        }
        
        // player look input
        private void LookAtMouse()
        {
            transform.localRotation = _viewCamera.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x
                ? Quaternion.Euler(0, 180, 0)
                : Quaternion.Euler(0, 0, 0);
        }

        // weapon switch, use mouse scroll to control different weapons
        private void WeaponSwitch()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f )
            {
                sword.SetActive(true);
                bow.SetActive(false);
                slot1.sprite = activeSprite;
                slot2.sprite = inactiveSprite;
                weaponName.text = "Wooden Blade";
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
            {
                sword.SetActive(false);
                bow.SetActive(true);
                slot1.sprite = inactiveSprite;
                slot2.sprite = activeSprite;
                weaponName.text = "Wooden Bow";
            }
        }
    }
}