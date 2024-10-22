using UnityEngine;
using YG; // Подключаем пространство имен YG для работы с сохранениями Yandex Game SDK

public class ResetSavesYandex : MonoBehaviour
{
    // Метод для сброса сохранений
    public void ResetSaves()
    {
        // Создаем новый экземпляр SavesYG с начальными значениями
        YandexGame.savesData = new SavesYG();

        // Сохраняем прогресс, чтобы изменения вступили в силу
        YandexGame.SaveProgress();

        Debug.Log("Все сохранения сброшены к начальным значениям.");
    }

    // Метод для кнопки, чтобы сброс был доступен через интерфейс
    public void OnResetButtonClicked()
    {
        ResetSaves();
    }
}
