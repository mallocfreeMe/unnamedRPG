using UnityEngine;
using Pathfinding;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private AIPath _aiPath;

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
        }

        private void Update()
        {
            transform.localRotation = _aiPath.desiredVelocity.x < 0.01f
                ? Quaternion.Euler(0, 180, 0)
                : Quaternion.Euler(0, 0, 0);
        }
    }
}
