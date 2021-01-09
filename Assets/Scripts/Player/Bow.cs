using UnityEngine;

namespace Player
{
    public class Bow : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject arrowPrefab;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
