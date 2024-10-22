using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class UnitSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab; // Префаб воина
    [SerializeField] private GameObject magePrefab;    // Префаб мага
    [SerializeField] private Vector3 spawnAreaCenter;  // Центр области для спавна юнитов
    [SerializeField] private Vector3 spawnAreaSize;    // Размеры области для спавна юнитов
    [SerializeField] private float unitSpacing = 2.0f; // Расстояние между юнитами

    private int currentWarriorCount = 0;
    private int currentMageCount = 0;

    private void Start()
    {
        // Спавн существующих воинов и магов при загрузке сцены
        for (int i = 0; i < YandexGame.savesData.warriorCount; i++)
        {
            SpawnUnit(warriorPrefab, currentWarriorCount++, "warrior");
        }
        for (int i = 0; i < YandexGame.savesData.mageCount; i++)
        {
            SpawnUnit(magePrefab, currentMageCount++, "mage");
        }
    }

    public void SpawnWarrior()
    {
        if (currentWarriorCount < 5)
        {
            SpawnUnit(warriorPrefab, currentWarriorCount++, "warrior");
        }
        else
        {
            Debug.Log("Нельзя купить больше 5 воинов.");
        }
    }

    public void SpawnMage()
    {
        if (currentMageCount < 5)
        {
            SpawnUnit(magePrefab, currentMageCount++, "mage");
        }
        else
        {
            Debug.Log("Нельзя купить больше 5 магов.");
        }
    }

    private void SpawnUnit(GameObject unitPrefab, int unitIndex, string unitType)
    {
        if (unitPrefab == null)
        {
            Debug.LogError("Не задан префаб юнита для спавна.");
            return;
        }

        // Сдвиг спавн-зоны для воинов и магов
        float typeOffset = unitType == "warrior" ? -spawnAreaSize.x / 4 : spawnAreaSize.x / 4;

        // Генерация позиции с учетом индекса, типа юнита и расстояния между юнитами
        Vector3 spawnPosition = spawnAreaCenter + new Vector3(
            typeOffset + (unitIndex % 5) * unitSpacing - (spawnAreaSize.x / 2),
            0,
            (unitIndex / 5) * unitSpacing - (spawnAreaSize.z / 2)
        );

        // Создание юнита на сцене в заданной позиции
        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}