using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 10;
        public GameObject healthBar;
        public GameObject pausePanel;

        private Slider _slider;

        private void Start()
        {
            _slider = healthBar.GetComponent<Slider>();
            _slider.maxValue = health;
            _slider.value = _slider.maxValue;
            pausePanel.GetComponent<CanvasGroup>().alpha = 0;
        }

        private void Update()
        {
            if (health == 0)
            {
                pausePanel.GetComponent<CanvasGroup>().alpha = 1;
            }
        }

        // player take damage when an enemy hits the player
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.GetComponent<Animator>().GetBool("isAttacking"))
                {
                    health--;
                    _slider.value--;
                }
            }
        }
    }
}