using UnityEngine;
using YG; // Подключаем пространство имен YG для доступа к SavesYG
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int warriorCost = 10; // Стоимость воина
    [SerializeField] private int mageCost = 15;    // Стоимость мага
    [SerializeField] private UIManager uiManager;  // Ссылка на UIManager для обновления интерфейса
    [SerializeField] private UnitSpawnManager unitSpawnManager; // Ссылка на UnitSpawnManager для спавна юнитов

    public void BuyWarrior()
    {
        if (YandexGame.savesData.money >= warriorCost && YandexGame.savesData.warriorCount < 5)
        {
            YandexGame.savesData.money -= warriorCost; // Уменьшаем количество монет
            YandexGame.savesData.warriorCount++;       // Увеличиваем количество воинов
            YandexGame.SaveProgress();                 // Сохраняем изменения

            Debug.Log($"Войн куплен. Оставшиеся монеты: {YandexGame.savesData.money}");

            // Спавн воина на сцене через UnitSpawnManager
            if (unitSpawnManager != null)
            {
                unitSpawnManager.SpawnWarrior();
            }

            // Обновляем интерфейс
            if (uiManager != null)
            {
                uiManager.UpdateUI();
            }
        }
        else if (YandexGame.savesData.warriorCount >= 5)
        {
            Debug.Log("Нельзя купить больше 5 воинов.");
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки воина.");
        }
    }

    public void BuyMage()
    {
        if (YandexGame.savesData.money >= mageCost && YandexGame.savesData.mageCount < 5)
        {
            YandexGame.savesData.money -= mageCost; // Уменьшаем количество монет
            YandexGame.savesData.mageCount++;       // Увеличиваем количество магов
            YandexGame.SaveProgress();              // Сохраняем изменения

            Debug.Log($"Маг куплен. Оставшиеся монеты: {YandexGame.savesData.money}");

            // Спавн мага на сцене через UnitSpawnManager
            if (unitSpawnManager != null)
            {
                unitSpawnManager.SpawnMage();
            }

            // Обновляем интерфейс
            if (uiManager != null)
            {
                uiManager.UpdateUI();
            }
        }
        else if (YandexGame.savesData.mageCount >= 5)
        {
            Debug.Log("Нельзя купить больше 5 магов.");
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки мага.");
        }
    }
}