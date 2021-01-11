using UnityEngine;

namespace Player
{
    public class Pivot : MonoBehaviour
    {
        public GameObject myPlayer;
        private Camera _viewCamera;

        private void Start()
        {
            _viewCamera = Camera.main;
        }


        private void FixedUpdate()
        {
            Vector3 difference = _viewCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            
            if (myPlayer.transform.eulerAngles.y == 0) //player character looking to the left
            {
                transform.localRotation = Quaternion.Euler(180, 180, rotZ); //flip the arm on X-axis
            }
            else if (myPlayer.transform.eulerAngles.y != 0) //player character looking to the right
            {
                transform.localRotation = Quaternion.Euler(0, 0, -rotZ); //flip the arm on X-axis & Y-axis
            }
        }
    }
}