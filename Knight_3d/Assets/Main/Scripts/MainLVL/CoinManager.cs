using UnityEngine;
using YG; // Подключаем пространство имен YG для доступа к SavesYG
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int coinAmount = 5; // Количество монет, которое будет добавляться при нажатии на кнопку
    [SerializeField] private UIManager uiManager; // Ссылка на UIManager для обновления текста

    // Метод для добавления монет
    public void AddCoins()
    {
        YandexGame.savesData.money += coinAmount; // Увеличиваем количество монет
        YandexGame.SaveProgress();                // Сохраняем изменения

        Debug.Log($"Добавлено {coinAmount} монет. Текущее количество монет: {YandexGame.savesData.money}");

        // Обновляем текст монет на экране
        if (uiManager != null)
        {
            uiManager.UpdateUI();
        }
    }
    public void RemoveCoins() {
        if (uiManager != null)
        {
            uiManager.UpdateUI();
        }

    }

}