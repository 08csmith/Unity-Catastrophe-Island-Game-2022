using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public enum DamageType
    {
        UNKNOWN,
        FALL_DAMAGE,
        DROWNING
    }
    public class HealthBarScript : MonoBehaviour
    {
        public int maxHealth = 100;

        public int currentHealth = 1;

        public Slider slider;

        private GameManager _gameManager;

        public void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void SetCurrentHealth(int health)
        {
            currentHealth = health;
            slider.value = health;
            
            // Check if the health is below or equal to 0
            if (currentHealth <= 0)
                _gameManager.KillPlayer();
        }
    
        public void TakeDamage(float damage, DamageType type)
        {
            if (_gameManager.playerLifeStatus != PlayerLifeStatus.ALIVE) return;
            _gameManager.lastDamageType = type;
            int newHealth = Mathf.RoundToInt(currentHealth - damage);
            SetCurrentHealth(newHealth);
        }
    }
}
