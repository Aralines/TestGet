using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;  // Слайдер для отображения здоровья
    private Health health;                         // Компонент Health для управления здоровьем

    private void Start()
    {
        // Получаем компонент Health
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health не найден на объекте " + gameObject.name);
        }
        else if (healthSlider != null)
        {
            healthSlider.maxValue = health.maxHealth;
            healthSlider.value = health.GetHealthPercentage() * health.maxHealth;
        }
    }

    private void Update()
    {
        // Обновляем слайдер здоровья
        if (healthSlider != null && health != null)
        {
            healthSlider.value = health.GetHealthPercentage() * health.maxHealth;
        }
    }
}
