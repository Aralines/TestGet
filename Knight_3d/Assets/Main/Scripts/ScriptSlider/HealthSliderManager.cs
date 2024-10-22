using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;  // ������� ��� ����������� ��������
    private Health health;                         // ��������� Health ��� ���������� ���������

    private void Start()
    {
        // �������� ��������� Health
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health �� ������ �� ������� " + gameObject.name);
        }
        else if (healthSlider != null)
        {
            healthSlider.maxValue = health.maxHealth;
            healthSlider.value = health.GetHealthPercentage() * health.maxHealth;
        }
    }

    private void Update()
    {
        // ��������� ������� ��������
        if (healthSlider != null && health != null)
        {
            healthSlider.value = health.GetHealthPercentage() * health.maxHealth;
        }
    }
}
