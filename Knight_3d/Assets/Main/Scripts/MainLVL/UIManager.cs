using UnityEngine;
using TMPro;
using YG;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;       // Текстовое поле для монет
    [SerializeField] private TextMeshProUGUI warriorText;     // Текстовое поле для количества воинов
    [SerializeField] private TextMeshProUGUI mageText;        // Текстовое поле для количества магов

    private void Start()
    {
        UpdateUI(); // Обновляем интерфейс при старте
    }

    public void UpdateUI()
    {
        if (YandexGame.savesData != null)
        {
            moneyText.text = $"Монеты: {YandexGame.savesData.money}";
            warriorText.text = $"Воины: {YandexGame.savesData.warriorCount}";
            mageText.text = $"Маги: {YandexGame.savesData.mageCount}";
        }
        else
        {
            Debug.LogWarning("SavesData не инициализирован.");
        }
    }
}