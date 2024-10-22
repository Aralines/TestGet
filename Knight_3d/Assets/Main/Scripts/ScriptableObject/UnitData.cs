using UnityEngine;
using YG;

[CreateAssetMenu(fileName = "UnitData", menuName = "Game/UnitData")]
public class UnitData : ScriptableObject
{
    public int warriorCount = 0;
    public int mageCount = 0;

    // ����� ��� ������ ������ (��������, ��� ������ ����� ����)
    public void ResetData()
    {
        warriorCount = 0;
        mageCount = 0;
    }

    // ����� ��� ���������� ������ � �������� ���������� ����� SavesYG
    public void SaveToCloud()
    {
        SavesYG saveData = YandexGame.savesData;
        saveData.warriorCount = warriorCount;
        saveData.mageCount = mageCount;

        YandexGame.SaveProgress(); // ��������� ������ � ������
    }

    // ����� ��� �������� ������ �� �������� ����������
    public void LoadFromCloud()
    {
        SavesYG saveData = YandexGame.savesData;

        warriorCount = saveData.warriorCount;
        mageCount = saveData.mageCount;
    }
}