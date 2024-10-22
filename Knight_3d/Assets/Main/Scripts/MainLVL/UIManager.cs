using UnityEngine;
using TMPro;
using YG;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;       // ��������� ���� ��� �����
    [SerializeField] private TextMeshProUGUI warriorText;     // ��������� ���� ��� ���������� ������
    [SerializeField] private TextMeshProUGUI mageText;        // ��������� ���� ��� ���������� �����

    private void Start()
    {
        UpdateUI(); // ��������� ��������� ��� ������
    }

    public void UpdateUI()
    {
        if (YandexGame.savesData != null)
        {
            moneyText.text = $"������: {YandexGame.savesData.money}";
            warriorText.text = $"�����: {YandexGame.savesData.warriorCount}";
            mageText.text = $"����: {YandexGame.savesData.mageCount}";
        }
        else
        {
            Debug.LogWarning("SavesData �� ���������������.");
        }
    }
}