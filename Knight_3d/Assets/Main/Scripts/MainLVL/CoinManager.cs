using UnityEngine;
using YG; // ���������� ������������ ���� YG ��� ������� � SavesYG
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int coinAmount = 5; // ���������� �����, ������� ����� ����������� ��� ������� �� ������
    [SerializeField] private UIManager uiManager; // ������ �� UIManager ��� ���������� ������

    // ����� ��� ���������� �����
    public void AddCoins()
    {
        YandexGame.savesData.money += coinAmount; // ����������� ���������� �����
        YandexGame.SaveProgress();                // ��������� ���������

        Debug.Log($"��������� {coinAmount} �����. ������� ���������� �����: {YandexGame.savesData.money}");

        // ��������� ����� ����� �� ������
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