using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private UnitData unitData; // ���������� ScriptableObject
    public GameObject warriorPrefab;            // ������ �����
    public GameObject magePrefab;               // ������ ����
    public Transform spawnPoint;                // ����� ��������� ������

    private void Start()
    {
        SpawnUnits();
    }

    private void SpawnUnits()
    {
        // ���������� ������
        for (int i = 0; i < unitData.warriorCount; i++)
        {
            Instantiate(warriorPrefab, spawnPoint.position + Vector3.right * i * 2, Quaternion.identity);
        }

        // ���������� �����
        for (int i = 0; i < unitData.mageCount; i++)
        {
            Instantiate(magePrefab, spawnPoint.position + Vector3.left * i * 2, Quaternion.identity);
        }
    }
}
