using UnityEngine;
using YG;

[CreateAssetMenu(fileName = "UnitData", menuName = "Game/UnitData")]
public class UnitData : ScriptableObject
{
    public int warriorCount = 0;
    public int mageCount = 0;

    // Метод для сброса данных (например, для начала новой игры)
    public void ResetData()
    {
        warriorCount = 0;
        mageCount = 0;
    }

    // Метод для сохранения данных в облачные сохранения через SavesYG
    public void SaveToCloud()
    {
        SavesYG saveData = YandexGame.savesData;
        saveData.warriorCount = warriorCount;
        saveData.mageCount = mageCount;

        YandexGame.SaveProgress(); // Сохраняем данные в облако
    }

    // Метод для загрузки данных из облачных сохранений
    public void LoadFromCloud()
    {
        SavesYG saveData = YandexGame.savesData;

        warriorCount = saveData.warriorCount;
        mageCount = saveData.mageCount;
    }
}