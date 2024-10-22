using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ ��������
    private float currentHealth;
    private bool isDead = false; // ���� ��� ��������, ���� �� ��������

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
            return; // ���� �������� ��� �����, �� ��������� ���������� ��������
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
            return; // ������������� ��������� ����������
        }

        isDead = true;

        if (OnDeath != null)
        {
            OnDeath.Invoke(); // �������� ������� ������
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
        // ����� ��� ��������� ������������ ���������
    }
}
