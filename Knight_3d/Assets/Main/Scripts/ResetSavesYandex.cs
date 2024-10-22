using UnityEngine;
using YG; // ���������� ������������ ���� YG ��� ������ � ������������ Yandex Game SDK

public class ResetSavesYandex : MonoBehaviour
{
    // ����� ��� ������ ����������
    public void ResetSaves()
    {
        // ������� ����� ��������� SavesYG � ���������� ����������
        YandexGame.savesData = new SavesYG();

        // ��������� ��������, ����� ��������� �������� � ����
        YandexGame.SaveProgress();

        Debug.Log("��� ���������� �������� � ��������� ���������.");
    }

    // ����� ��� ������, ����� ����� ��� �������� ����� ���������
    public void OnResetButtonClicked()
    {
        ResetSaves();
    }
}
