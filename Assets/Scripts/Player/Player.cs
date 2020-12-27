using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerAnimation))]
    public class Player : MonoBehaviour
    {
        //=============Health===================================================================================
        public int playerHealth = 10;

        //=============Player Movement==========================================================================
        public float moveSpeed = 5;


        //=============Player Attack============================================================================ 
        public int powAttkCounter = 10;         //# of times player needs to attack before enpowered attack

        //melee attack damage & enpowere melee attack damage
        public float meleeAttkDmg = 3;          //normal attack
        public float powMeleeAttkDmg = 7;       //enpowered attack

        //ranged attack damage & enpowered ranged attack damage
        public float rangedAttkDmg = 1;         //normal attack
        public float powRangedAttkDmg = 4;      //enpowered attack


        //============Player POV & Other========================================================================
        private Camera _viewCamera;
        private PlayerController _controller;


        //============Player Sword Rotation=====================================================================





        //============Functions=================================================================================

        private void Start()
        {
            _controller = GetComponent<PlayerController>();
            _viewCamera = Camera.main;
        }

        private void Update()
        {
            PlayerMovement();

        }

        private void FixedUpdate()
        {
        }


        private void PlayerMovement() //responsible for all the player movement and look directions
        {
            // movement input
            var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            var moveVelocity = moveInput.normalized * moveSpeed;
            _controller.Move(moveVelocity);

            //player look input
            transform.localRotation = _viewCamera.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x
                ? Quaternion.Euler(0, 180, 0)
                : Quaternion.Euler(0, 0, 0);

        }

        private void PlayerAttckAim()//responsible for the direction the player will be attacking at
        {

        }

        private void PlayerMeleeAttack()//responsible for player melee attack action
        {

        }

        private void PlayerRangedAttack()//responsible for player ranged attack action
        {

        }

        private void PlayerSwitchAttack()//responsible for player switching weapong
        {

        }

    }
}