using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class UnitSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab; // ������ �����
    [SerializeField] private GameObject magePrefab;    // ������ ����
    [SerializeField] private Vector3 spawnAreaCenter;  // ����� ������� ��� ������ ������
    [SerializeField] private Vector3 spawnAreaSize;    // ������� ������� ��� ������ ������
    [SerializeField] private float unitSpacing = 2.0f; // ���������� ����� �������

    private int currentWarriorCount = 0;
    private int currentMageCount = 0;

    private void Start()
    {
        // ����� ������������ ������ � ����� ��� �������� �����
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
            Debug.Log("������ ������ ������ 5 ������.");
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
            Debug.Log("������ ������ ������ 5 �����.");
        }
    }

    private void SpawnUnit(GameObject unitPrefab, int unitIndex, string unitType)
    {
        if (unitPrefab == null)
        {
            Debug.LogError("�� ����� ������ ����� ��� ������.");
            return;
        }

        // ����� �����-���� ��� ������ � �����
        float typeOffset = unitType == "warrior" ? -spawnAreaSize.x / 4 : spawnAreaSize.x / 4;

        // ��������� ������� � ������ �������, ���� ����� � ���������� ����� �������
        Vector3 spawnPosition = spawnAreaCenter + new Vector3(
            typeOffset + (unitIndex % 5) * unitSpacing - (spawnAreaSize.x / 2),
            0,
            (unitIndex / 5) * unitSpacing - (spawnAreaSize.z / 2)
        );

        // �������� ����� �� ����� � �������� �������
        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}