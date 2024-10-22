using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье
    private float currentHealth;
    private bool isDead = false; // Флаг для проверки, умер ли персонаж

    public delegate void DeathEventHandler();
    public event DeathEventHandler OnDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return; // Если персонаж уже мертв, не выполняем дальнейшие действия
        }

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return; // Предотвращаем повторное выполнение
        }

        isDead = true;

        if (OnDeath != null)
        {
            OnDeath.Invoke(); // Вызываем событие смерти
        }
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetInvulnerable(bool value)
    {
        // Метод для установки неуязвимости персонажа
    }
}
