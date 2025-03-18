using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IObserver
    {
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
            CurrentHealth = healthIcons.Length;
            UpdateHealthUI();
        }

        public void TakeDamage()
        {
            CurrentHealth--;
            UpdateHealthUI();
            if(CurrentHealth == 0 )
            {
                Death();
            }
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

        private void Death()
        {
            SceneManager.LoadScene("Final");
        }

        public void Update(bool isBonusActive)
        {
            Debug.Log(isBonusActive);
            IsDamage = isBonusActive;
        }
    }
}
