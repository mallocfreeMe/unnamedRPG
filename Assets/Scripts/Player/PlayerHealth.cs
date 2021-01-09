using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 10;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // player take damage when an enemy hits the player
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.GetComponent<Animator>().GetBool("isAttacking"))
                {
                    health--;
                    Debug.Log(health);
                }
            }
        }
    }
}
