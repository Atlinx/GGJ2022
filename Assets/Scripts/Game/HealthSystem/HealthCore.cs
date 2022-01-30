using UnityEngine;
using UnityEngine.Events;

namespace Game.HealthSystem
{
    public class HealthCore : MonoBehaviour
    {
        public int MaxHealth;
        public int CurrentHealth;

        public UnityEvent OnDeathEvent;
        public UnityEvent OnDamageEvent;
        public UnityEvent OnHealEvent;
        public UnityEvent OnHealthChange;
        
        public void Damage(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Passed invalid damage amount");
                return;
            }
            
            CurrentHealth -= amount;
            
            OnHealthChange?.Invoke();
            OnDamageEvent?.Invoke();
            
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeathEvent?.Invoke();
                
                Debug.Log("Died");
            }
        }

        
        public void Heal(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Passed invalid heal amount");
                return;
            }

            CurrentHealth += amount;
            
            OnHealthChange?.Invoke();
            OnHealEvent?.Invoke();

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }

        }


        /// <summary>
        /// Resets health, invokes on health changed.
        /// </summary>
        public void ResetHealth(bool invokeChange = true)
        {
            CurrentHealth = MaxHealth;
            
            if(invokeChange) OnHealthChange?.Invoke();
        }
    }
}
