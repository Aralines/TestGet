using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private UnitData unitData; // Подключаем ScriptableObject
    public GameObject warriorPrefab;            // Префаб воина
    public GameObject magePrefab;               // Префаб мага
    public Transform spawnPoint;                // Точка появления юнитов

    private void Start()
    {
        SpawnUnits();
    }

    private void SpawnUnits()
    {
        // Размещение воинов
        for (int i = 0; i < unitData.warriorCount; i++)
        {
            Instantiate(warriorPrefab, spawnPoint.position + Vector3.right * i * 2, Quaternion.identity);
        }

        // Размещение магов
        for (int i = 0; i < unitData.mageCount; i++)
        {
            Instantiate(magePrefab, spawnPoint.position + Vector3.left * i * 2, Quaternion.identity);
        }
    }
}
