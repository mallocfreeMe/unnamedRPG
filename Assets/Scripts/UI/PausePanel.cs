using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        public Button playAgainButton;
        public Button exitButton;

        private void Start()
        {
            playAgainButton.onClick.AddListener(PlayAgain);
            exitButton.onClick.AddListener(Exit);
        }

        private static void PlayAgain()
        {
            SceneManager.LoadScene("Town", LoadSceneMode.Single);
        }

        private static void Exit()
        {
            Application.Quit();
        }

        private void Update()
        {
            if (gameObject.activeSelf)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}