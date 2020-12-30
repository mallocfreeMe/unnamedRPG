using UnityEngine;

namespace Player
{
    public class Bow : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject arrowPrefab;

        private void Update()
        {
            /*Vector2 bowPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - bowPosition;
            transform.right = direction;*/
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
