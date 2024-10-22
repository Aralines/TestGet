using UnityEngine;
using YG; // ���������� ������������ ���� YG ��� ������� � SavesYG
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int warriorCost = 10; // ��������� �����
    [SerializeField] private int mageCost = 15;    // ��������� ����
    [SerializeField] private UIManager uiManager;  // ������ �� UIManager ��� ���������� ����������
    [SerializeField] private UnitSpawnManager unitSpawnManager; // ������ �� UnitSpawnManager ��� ������ ������

    public void BuyWarrior()
    {
        if (YandexGame.savesData.money >= warriorCost && YandexGame.savesData.warriorCount < 5)
        {
            YandexGame.savesData.money -= warriorCost; // ��������� ���������� �����
            YandexGame.savesData.warriorCount++;       // ����������� ���������� ������
            YandexGame.SaveProgress();                 // ��������� ���������

            Debug.Log($"���� ������. ���������� ������: {YandexGame.savesData.money}");

            // ����� ����� �� ����� ����� UnitSpawnManager
            if (unitSpawnManager != null)
            {
                unitSpawnManager.SpawnWarrior();
            }

            // ��������� ���������
            if (uiManager != null)
            {
                uiManager.UpdateUI();
            }
        }
        else if (YandexGame.savesData.warriorCount >= 5)
        {
            Debug.Log("������ ������ ������ 5 ������.");
        }
        else
        {
            Debug.Log("������������ ����� ��� ������� �����.");
        }
    }

    public void BuyMage()
    {
        if (YandexGame.savesData.money >= mageCost && YandexGame.savesData.mageCount < 5)
        {
            YandexGame.savesData.money -= mageCost; // ��������� ���������� �����
            YandexGame.savesData.mageCount++;       // ����������� ���������� �����
            YandexGame.SaveProgress();              // ��������� ���������

            Debug.Log($"��� ������. ���������� ������: {YandexGame.savesData.money}");

            // ����� ���� �� ����� ����� UnitSpawnManager
            if (unitSpawnManager != null)
            {
                unitSpawnManager.SpawnMage();
            }

            // ��������� ���������
            if (uiManager != null)
            {
                uiManager.UpdateUI();
            }
        }
        else if (YandexGame.savesData.mageCount >= 5)
        {
            Debug.Log("������ ������ ������ 5 �����.");
        }
        else
        {
            Debug.Log("������������ ����� ��� ������� ����.");
        }
    }
}