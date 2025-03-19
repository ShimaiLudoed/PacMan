using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private TriggerDetector triggerDetector;
        [SerializeField] private float pauseDuration = 1f;
        [SerializeField] private Vector3 playerStartPosition;
        public bool IsDamage;
        public int CurrentHealth;
        [SerializeField] private Image[] healthIcons;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                TakeDamage();
            }
        }

        private void Start()
        {
            triggerDetector.OnPlayerDamaged += TakeDamage;
            playerStartPosition = transform.position;
            CurrentHealth = healthIcons.Length;
            UpdateHealthUI();
        }

        private void UpdateHealthUI()
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                if (i < CurrentHealth)
                {
                    healthIcons[i].enabled = true;
                }
                else
                {
                    healthIcons[i].enabled = false;
                }
            }
        }
        public void TakeDamage()
        {
            StartCoroutine(Take()); 
        }

        public IEnumerator Take()
        {
            CurrentHealth--;
            UpdateHealthUI();
            if (CurrentHealth == 0)
            {
                Death();
            }
            yield return new WaitForSeconds(pauseDuration);
            transform.position = playerStartPosition;

        }

        private void Death()
        {
            SceneManager.LoadScene("Final");
        }
    }
}
